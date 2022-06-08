using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Controllers;
using UnityEngine;

namespace ThirdPersonShooter.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Spawner Info", menuName = "Combat/Spawner Information/Create New")]
    public class SpawnInfoSO : ScriptableObject
    {
        [SerializeField] EnemyController _enemyPrefab;
        [SerializeField] float _maxSpawnTime = 15f;       //kaç saniyede bir enemy spawn edeceğimiz.
        [SerializeField] float _minSpawnTime = 3f;

        public EnemyController EnemyPrefab => _enemyPrefab;
        public float RandomSpawnMaxTime => Random.Range(_minSpawnTime, _maxSpawnTime);
    }

}

