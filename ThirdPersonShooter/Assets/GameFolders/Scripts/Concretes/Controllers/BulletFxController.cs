
using System;
using UnityEngine;

namespace  ThirdPersonShooter.Controllers
{
    public class BulletFxController : MonoBehaviour
    {
        [SerializeField] float maxLifeTime = 5f;
        [SerializeField] float _moveSpeed = 100f;

        Rigidbody _rigidbody;
        ParticleSystem _particleSystem;

        float _currentLifeTime = 0f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _particleSystem = GetComponentInChildren<ParticleSystem>();
        }

        private void Start()
        { 
            _particleSystem.Play();
        }

        private void Update() //bir Game Object'e  çarparsa bu kadar sürede yok olsun
        {
            _currentLifeTime += Time.deltaTime;

            if (_currentLifeTime > maxLifeTime)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter(Collider other) //bir Game Object'e çarparsa yok olsun
        {
            Destroy(this.gameObject);
        }

        public void SetDirection(Vector3 direction)
        {
            _rigidbody.velocity = direction * _moveSpeed;
        }
    }
}



