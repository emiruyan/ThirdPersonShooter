using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Controllers;
using ThirdPersonShooter.Abstracts.Movements;
using ThirdPersonShooter.Animations;
using ThirdPersonShooter.Controllers;
using UnityEngine;

namespace ThirdPersonShooter.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController
    {
        IMover Mover { get;} 
        InventoryController Inventory { get; }
        CharacterAnimation Animation { get; }

        Transform Target { get; set; } 
        float Magnitude { get; }
    } 
}


