using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Abstracts.Uis;
using ThirdPersonShooter.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace ThirdPersonShooter.Uis
{
    public class StartButton : MyButton 
    {
        protected override void HandleOnButtonClicked()
        {
            GameManager.Instance.LoadLevel("Game");
        }
    }

}

