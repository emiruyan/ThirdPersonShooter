using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.States;
using UnityEngine;

namespace ThirdPersonShooter.States.EnemyStates
{
    public class DeadState : IState
    {
        public void OnEnter()
        {
            Debug.Log($"{nameof(AttackState)} {nameof(OnEnter)}");
        }
        public void OnExit()
        {
            Debug.Log($"{nameof(AttackState)} {nameof(OnExit)}");
        }
        public void Tick()
        {
            Debug.Log(nameof(DeadState));
        }
    }

}

