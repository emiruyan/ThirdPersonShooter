using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Movements;
using UnityEngine;

namespace ThirdPersonShooter.Abstracts.Controllers
{
    public interface IEntityController 
    {
        Transform transform { get; }
        
    }
}


