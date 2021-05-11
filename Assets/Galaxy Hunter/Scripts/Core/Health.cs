using System;
using UnityEngine;

namespace Galaxy_Hunter.Scripts.Core
{
    public class Health : MonoBehaviour
    {
        private Transform _transform;
        private bool _isDeathParticlesNotNull;

        public bool destroyObject = true;
        public GameObject deathParticles;

        [SerializeField] private float healthValue = 100.0f;

        public float HealthValue
        {
            get => healthValue;
            set => healthValue = value;
        }

        private void Awake()
        {
            _isDeathParticlesNotNull = deathParticles != null;
            _transform = GetComponent<Transform>();
        }

        private void Update()
        {
            CheckHealth();
        }

        private void CheckHealth()
        {
            if (healthValue <= 0)
            {
                //Console.log
                Debug.Log(gameObject.name + " dead!");

                //play Death Particles
                if (_isDeathParticlesNotNull)
                {
                    Instantiate(deathParticles, _transform.position, deathParticles.transform.rotation);
                }

                //Die
                if (destroyObject)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}