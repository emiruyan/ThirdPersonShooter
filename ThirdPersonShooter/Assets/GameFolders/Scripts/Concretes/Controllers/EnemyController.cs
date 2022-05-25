using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Controllers;
using ThirdPersonShooter.Abstracts.Movements;
using ThirdPersonShooter.Movements;
using UnityEngine;

namespace ThirdPersonShooter.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] Transform _playerPrefab;

        IMover _mover;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
        }

        private void Update()
        {
            _mover.MoveAction(_playerPrefab.transform.position, 10f);
        }
    }
}


