using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Controllers;
using ThirdPersonShooter.Abstracts.States;
using UnityEngine;

namespace ThirdPersonShooter.States.EnemyStates
{
    public class ChaseState : IState
    {
         float _speed = 10f;
         IEntityController _entityController;
         Transform _target;
        
        public ChaseState(IEntityController entityController,Transform target)
        {
            _entityController = entityController;
            _target = target;
        }

        public void OnEnter()
        {
            Debug.Log($"{nameof(ChaseState)} {nameof(OnEnter)}");
        }

        public void OnExit()
        {
            Debug.Log($"{nameof(ChaseState)} {nameof(OnExit)}");
        }

        public void Tick()
        {
          _entityController.Mover.MoveAction(_target.position, _speed);
        }
    }
}


