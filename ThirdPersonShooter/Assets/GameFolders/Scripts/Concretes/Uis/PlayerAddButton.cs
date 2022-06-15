using ThirdPersonShooter.Managers;
using UnityEngine;
using Button = UnityEngine.UI.Button;


namespace ThirdPersonShooter.Uis
{
    public class PlayerAddButton : MonoBehaviour
    { 
        Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }
        
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }
        
        private void OnButtonClicked() //Tıkladığımızda player indexi artacak
        {
            GameManager.Instance.IncreasePlayerCount();
        }
        
        
    }
}
