 using JetBrains.Annotations;
 using UnityEngine;

 public class Portal : MonoBehaviour
 {
     [SerializeField] [CanBeNull] private string sceneName;
     
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            
            if (sceneName != null)
            {
                SceneManager.Instance.LoadScene(sceneName);
            }
            else
            {
                SceneManager.Instance.LoadNextScene();
            }
        }
 }
