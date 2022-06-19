using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Helpers;
using ThirdPersonShooter.Controllers;
using UnityEngine;

namespace ThirdPersonShooter.Managers
{
    public class EnemyManager : SingletonMonoBehaviour<EnemyManager>
    {
        [SerializeField] int _maxCountOnGame = 50;   //oyun ekranın toplamda 50 enemy olacak ve bittikce 50ye tamamlancank şekilde spawnlanacak
        [SerializeField] List<EnemyController> _enemies;
        
        public  List<Transform> Targets { get; private set; }

        public bool CanSpawn => _maxCountOnGame > _enemies.Count;
        public bool IsListEmpty => _enemies.Count <= 0;   
        

        private void Awake()
        {
            SetSingletonThisGameObject(this);
            _enemies = new List<EnemyController>();
            Targets = new List<Transform>();
        }

        public void AddEnemyController(EnemyController enemyController)
        {
            enemyController.transform.parent = this.transform;
            _enemies.Add(enemyController);
        }

        public void RemoveEnemyController(EnemyController enemyController)
        {
            _enemies.Remove(enemyController);
            GameManager.Instance.DecreaseWaveCount(); 
        }

        public void DestroyAllEnemies()
        {
            foreach (EnemyController enemyController in _enemies)
            {
                Destroy(enemyController.gameObject);
            }
            _enemies.Clear();
        }
    }
}


