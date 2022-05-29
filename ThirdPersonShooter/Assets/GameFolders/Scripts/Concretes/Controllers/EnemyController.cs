using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Combats;
using ThirdPersonShooter.Abstracts.Controllers;
using ThirdPersonShooter.Abstracts.Movements;
using ThirdPersonShooter.Animations;
using ThirdPersonShooter.Movements;
using UnityEngine;
using UnityEngine.AI;

namespace ThirdPersonShooter.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        [SerializeField] Transform _playerPrefab;

        IHealth _health;
        IMover _mover;
        CharacterAnimation _animation;
        NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
        }

        private void Update()
        {
            if (_health.IsDead ) return;

            _mover.MoveAction(_playerPrefab.transform.position, 10f);
        }

        void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
        }
    }
}


