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
        [SerializeField] int _maxCountOnGame = 50;  //oyun ekranın toplamda 50 enemy olacak ve bittince 50ye tamamlancank şekilde spawnlanacak
        [SerializeField] List<EnemyController> _enemies;

        public bool CanSpawn => _maxCountOnGame > _enemies.Count;
        

        private void Awake()
        {
            SetSingletonThisGameObject(this);

            _enemies = new List<EnemyController>();
        }

        public void AddEnemyController(EnemyController enemyController)
        {
            enemyController.transform.parent = this.transform;
            _enemies.Add(enemyController);
        }

        public void RemoveEnemyController(EnemyController enemyController)
        {
            _enemies.Remove(enemyController);
        }
    }
}


