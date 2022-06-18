using ThirdPersonShooter.Abstracts.Uis;
using ThirdPersonShooter.Managers;
using UnityEngine;

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

