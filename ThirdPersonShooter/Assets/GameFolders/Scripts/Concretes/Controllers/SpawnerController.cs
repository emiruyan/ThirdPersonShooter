using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.ScriptableObjects;
using UnityEngine;

namespace  ThirdPersonShooter.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] SpawnInfoSO _spawnInfo;
        
        
        float _currentTime = 0f;
        float _maxTime;

        private void Start()
        {
            _maxTime = _spawnInfo.RandomSpawnMaxTime;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _maxTime)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            Instantiate(_spawnInfo.EnemyPrefab, transform.position, Quaternion.identity);

            _currentTime = 0f;
            _maxTime = _spawnInfo.RandomSpawnMaxTime; 
        }
    }
}   


