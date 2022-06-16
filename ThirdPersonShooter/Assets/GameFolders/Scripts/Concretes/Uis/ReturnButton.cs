using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Uis;
using ThirdPersonShooter.Controllers;
using ThirdPersonShooter.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace ThirdPersonShooter.Uis
{
    public class ReturnButton : MyButton    
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadReturnMenu();
            
        }
    }
}

