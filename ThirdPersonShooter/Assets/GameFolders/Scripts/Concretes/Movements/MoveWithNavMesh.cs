using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Controllers;
using ThirdPersonShooter.Abstracts.Movements;
using UnityEngine;
using UnityEngine.AI;

namespace ThirdPersonShooter.Movements
{
    public class MoveWithNavMesh : IMover
    {
         NavMeshAgent _navMeshAgent;

         public MoveWithNavMesh(IEntityController entityController)
         {
             _navMeshAgent = entityController.transform.GetComponent<NavMeshAgent>();
         }
        
        
        public void MoveAction(Vector3 direction, float _moveSpeed)
        {
             
            _navMeshAgent.SetDestination(direction); //set destination gidilecek hedef nokta
        }

        public float Velocity { get; }
    }

}

