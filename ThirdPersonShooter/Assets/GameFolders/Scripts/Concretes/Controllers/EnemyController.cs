using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Combats;
using ThirdPersonShooter.Abstracts.Controllers;
using ThirdPersonShooter.Abstracts.Movements;
using ThirdPersonShooter.Animations;
using ThirdPersonShooter.Combats;
using ThirdPersonShooter.Movements;
using ThirdPersonShooter.States;
using ThirdPersonShooter.States.EnemyStates;
using UnityEngine;
using UnityEngine.AI;

namespace ThirdPersonShooter.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemyController
    {
        IHealth _health;
        NavMeshAgent _navMeshAgent;
        StateMachine _stateMachine;
        
        bool _canAttack;
        
        public IMover Mover { get;private set; }
        public InventoryController Inventory { get; private set; }
        public CharacterAnimation Animation { get; private set; }
        public Dead Dead { get; private set; }
        public Transform Target { get; set; }
        public float Magnitude => _navMeshAgent.velocity.magnitude;

        public bool CanAttack => Vector3.Distance(Target.position,this.transform.position) < _navMeshAgent.stoppingDistance && _navMeshAgent.velocity==Vector3.zero;


        private void Awake()
        { 
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _health = GetComponent<IHealth>();
            _stateMachine = new StateMachine();
            
            
            Mover = new MoveWithNavMesh(this);
            Animation = new CharacterAnimation(this);
            Inventory = GetComponent<InventoryController>();
            Dead = GetComponent<Dead>(); 

        }

        private void Start() 
        {
            Target = FindObjectOfType<PlayerController>().transform;
            
            ChaseState chaseState = new ChaseState(this);
            AttackState attackState = new AttackState(this);
            DeadState deadState = new DeadState(this);
            
            _stateMachine.AddState(chaseState, attackState,() => CanAttack);
            _stateMachine.AddState(attackState, chaseState, ()=> !CanAttack);
            _stateMachine.AddAnyState(deadState, () => _health.IsDead);
            
            _stateMachine.SetState(attackState);

        }

        private void Update()
        {
            _stateMachine.Tick();
        }

        private void FixedUpdate()
        {
            _stateMachine.TicKFixed();

        }

        void LateUpdate()
        {
            _stateMachine.TickLate();

        }
    }
}

 
