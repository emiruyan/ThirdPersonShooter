using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Combats;
using ThirdPersonShooter.Abstracts.Controllers;
using ThirdPersonShooter.Abstracts.Movements;
using ThirdPersonShooter.Animations;
using ThirdPersonShooter.Movements;
using ThirdPersonShooter.States;
using ThirdPersonShooter.States.EnemyStates;
using UnityEngine;
using UnityEngine.AI;

namespace ThirdPersonShooter.Controllers
{
    public class EnemyController : MonoBehaviour, IEntityController
    {
        IHealth _health;
        IMover _mover;
        CharacterAnimation _animation;
        NavMeshAgent _navMeshAgent;
        InventoryController _inventoryController; 
        StateMachine _stateMachine;

        Transform _playerTransform;
        bool _canAttack;

        public bool CanAttack => Vector3.Distance(_playerTransform.position,this.transform.position) < _navMeshAgent.stoppingDistance && _navMeshAgent.velocity==Vector3.zero;


        private void Awake()
        {
            _mover = new MoveWithNavMesh(this);
            _animation = new CharacterAnimation(this);
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
            _inventoryController = GetComponent<InventoryController>();
            _stateMachine = new StateMachine();
        }

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerController>().transform;

            AttackState attackState = new AttackState();
            ChaseState chaseState = new ChaseState();
            DeadState deadState = new DeadState();
            
            _stateMachine.AddState(chaseState, attackState,() => CanAttack);
            _stateMachine.AddState(attackState, chaseState, ()=> !CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.IsDead);
            
            _stateMachine.SetState(chaseState);

        }

        private void Update()
        { 
            if (_health.IsDead ) return;
            
            _mover.MoveAction(_playerTransform.position, 10f); //enemy tam durduğunda attack yapmaya başlıyor

            _stateMachine.Tick();
        }

        private void FixedUpdate()
        {
            if (_canAttack)
            {
                _inventoryController.CurrentWeapon.Attack();
            }
            
        }

        void LateUpdate()
        {
            _animation.MoveAnimation(_navMeshAgent.velocity.magnitude);
            _animation.AttackAnimation(_canAttack);
        }
    }
}

 
