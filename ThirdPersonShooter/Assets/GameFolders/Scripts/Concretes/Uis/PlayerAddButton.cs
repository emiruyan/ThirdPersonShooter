using ThirdPersonShooter.Abstracts.Uis;
using ThirdPersonShooter.Managers;
using UnityEngine;
using Button = UnityEngine.UI.Button;


namespace ThirdPersonShooter.Uis
{
    public class PlayerAddButton : MyButton
    {
        protected override void HandleOnButtonClicked() //Tıkladığımızda player indexi artacak
        {
            GameManager.Instance.IncreasePlayerCount();
        }
    }
}
