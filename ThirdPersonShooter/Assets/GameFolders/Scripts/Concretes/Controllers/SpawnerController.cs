using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Managers;
using ThirdPersonShooter.ScriptableObjects;
using UnityEngine;

namespace  ThirdPersonShooter.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] SpawnInfoSO _spawnInfo;
        [SerializeField] float _maxTime;
        
        float _currentTime = 0f;
        
        private void Start()
        {
            _maxTime = _spawnInfo.RandomSpawnMaxTime;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _maxTime && EnemyManager.Instance.CanSpawn && !GameManager.Instance.IsWaveFinished)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
           EnemyController enemyController = Instantiate(_spawnInfo.EnemyPrefab, transform.position, Quaternion.identity);
           EnemyManager.Instance.AddEnemyController(enemyController);
           

            _currentTime = 0f;
            _maxTime = _spawnInfo.RandomSpawnMaxTime; 
        }
    }
}   


