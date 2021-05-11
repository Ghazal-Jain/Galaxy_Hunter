using UnityEngine;

namespace Galaxy_Hunter.Scripts.Core
{
    public class DestroyTimer : MonoBehaviour
    {
        [SerializeField] private float destroyTime = 1.5f;

        private void Start()
        {
            Invoke(nameof(DestroyGameObject),destroyTime);
        }

        private void DestroyGameObject()
        {
            Destroy(gameObject);
        }
    }
}
