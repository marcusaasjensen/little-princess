 using DialogueSystem.Runtime.Interaction;
 using JetBrains.Annotations;
 using UnityEngine;

 public class Portal : MonoBehaviour, IInteractable
 {
     [SerializeField] [CanBeNull] private string sceneName;
     [Header("Hint")]
     [SerializeField] private Transform player;
     [SerializeField] private float hintRadius;
     [SerializeField] private GameObject hint;

     public GameObject InteractionHint => hint;
     public bool CanInteract { get; } = true;
    
     private bool _hintNull;

     private void Update()
     {
         ShowHint();
     }

     // private void OnTriggerEnter(Collider other)
     // {
     //     if (!other.CompareTag("Player"))
     //     {
     //         return;
     //     }
     //        
     //     if (sceneName != null)
     //     {
     //         SceneManager.Instance.LoadScene(sceneName);
     //     }
     //     else
     //     {
     //         SceneManager.Instance.LoadNextScene();
     //     }
     // }

        public void Interact()
        {
            if (sceneName != null)
            {
                SceneManager.Instance.LoadScene(sceneName);
            }
            else
            {
                SceneManager.Instance.LoadNextScene();
            }
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
