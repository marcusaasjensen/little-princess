using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DialogueSystem.Runtime.Interaction
{
    public class InteractableDialogue : DialogueMonoBehaviour, IInteractable
    {
        [SerializeField] private bool stopInteractAtNarrativeEnd;
        [SerializeField] private UnityEvent onInteract;
        [SerializeField] private UnityEvent onInteractEnd;
        
        [Header("Hint")]
        [SerializeField] private Transform player;
        [SerializeField] private float hintRadius;
        [SerializeField] private GameObject hint;
        [SerializeField] private float lerpSpeed;

        public GameObject InteractionHint => hint;
    
        private bool _hintNull;
        private Quaternion _originalRotation;

        public bool CanInteract =>
            !((stopInteractAtNarrativeEnd && (narrativeScriptableObject is { IsNarrativeEndReached: true })) ||
              narrativeController.IsNarrating);

        private void Update()
        {
            SkipDialogueWithInput();
            ShowHint();
        }

        private void Awake()
        {
            _originalRotation = transform.rotation;
            _hintNull = hint == null;
        }

        public void Interact()
        {
            narrativeController.OnNarrativeEnd.AddListener(InvokedEndEvent);
            onInteract.Invoke();
            StartDialogue();
        }

        private void InvokedEndEvent()
        {
            onInteractEnd.Invoke();
            narrativeController.OnNarrativeEnd.RemoveListener(InvokedEndEvent);
        }

        public void TurnCharacterTowardsPlayerCoroutine() => StartCoroutine(TurnCharacterTowardsPlayer());

        private IEnumerator TurnCharacterTowardsPlayer()
        {
            var targetDirection = player.position - transform.position;
            targetDirection.y = 0f;

            if (targetDirection == Vector3.zero) yield break;

            var targetRotation = Quaternion.LookRotation(targetDirection);

            while (Quaternion.Angle(transform.rotation, targetRotation) > 0.05f)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, lerpSpeed * Time.deltaTime);
                yield return null;
            }
        }

        public void ResetCharacterRotationCoroutine() => StartCoroutine(ResetCharacterRotation());
        
        private IEnumerator ResetCharacterRotation()
        {
            var currentRotation = transform.rotation;
            var elapsedTime = 0f;
            
            while (elapsedTime < 1f)
            {
                transform.rotation = Quaternion.Lerp(currentRotation, _originalRotation, elapsedTime);
                elapsedTime += Time.deltaTime * lerpSpeed;
                yield return null;
            }
            
            transform.rotation = _originalRotation;
        }

        private void ShowHint()
        {
            if (_hintNull)
            {
                return;
            }
        
            if (!CanInteract)
            {
                hint.SetActive(false);
                return;
            }
            var distance = CalculateHintDistance(player.position, transform.position);
            hint.SetActive(distance <= hintRadius);
        }

        private static float CalculateHintDistance(Vector3 hintPosition, Vector3 playerPosition)
            => Mathf.Sqrt(Mathf.Pow((playerPosition.x - hintPosition.x),2) + Mathf.Pow((playerPosition.z - hintPosition.z),2));
    
        private void OnDrawGizmos()
        {
            var position = transform.position;
            var distance = CalculateHintDistance(player.position, position);
            Gizmos.color = distance <= hintRadius ? Color.green : Color.yellow;
            Gizmos.DrawWireSphere(position, hintRadius);
        }
    }
}