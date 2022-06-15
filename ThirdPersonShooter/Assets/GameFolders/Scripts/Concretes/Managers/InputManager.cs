
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ThirdPersonShooter.Managers
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] GameObject[] _prefabs;
        
        PlayerInputManager _playerInputManager; 
        int _playerIndex;
 
        private void Awake()
        {
            _playerInputManager = GetComponent<PlayerInputManager>();
            _playerInputManager.playerPrefab = _prefabs[_playerIndex]; 
        }
        
        void OnEnable() //onenableda olmasını istediğimiz şey oyuncuları çağırması, getirmesi
        {
            StartCoroutine(LoadPlayersAsync());
        }

        IEnumerator LoadPlayersAsync()
        {   
            WaitForSeconds waitForSeconds = new WaitForSeconds(1f); //for döngüsü burada arka arkaya çalışacağı için performans kaybı olur. Bunu önlemek ve Garbage Collectoru sıkıştırmamak adına WaitForSeconds'u burada kullanıyoruz. BU sayede newleme sadece bir kere olur.
           
                for (int i = 0; i < GameManager.Instance.PlayerCount; i++) //kaç oyuncu katıldıysa o kadar oyuncu eklemesini istiyoruz
            {
                _playerInputManager.JoinPlayer(_playerIndex);
                yield return waitForSeconds; 
            }
        }
        
        public void HandleOnJoin()
        {
            _playerIndex++;
            _playerInputManager.playerPrefab = _prefabs[_playerIndex]; 
            
        }

        public void HandleOnLeft()
        {
            _playerIndex--;
            _playerInputManager.playerPrefab = _prefabs[_playerIndex];
            
        }
    }
}







