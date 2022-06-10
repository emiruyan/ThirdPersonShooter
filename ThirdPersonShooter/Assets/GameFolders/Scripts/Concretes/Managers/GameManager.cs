
using System.Collections;
using ThirdPersonShooter.Abstracts.Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThirdPersonShooter.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] int _waveMaxCount = 100;

        
        public bool IsWaveFinished => _waveMaxCount <= 0; 

        private void Awake()
        {
            SetSingletonThisGameObject(this); 
        }

        public void LoadLevel(string name)
        {
            StartCoroutine(LoadLevelAsync(name));
        }

        private IEnumerator LoadLevelAsync(string name)
        {
            yield return SceneManager.LoadSceneAsync(name);
        }

        public void DecreaseWaveCount()
        {
            if (IsWaveFinished)
            {
                return;
            }
            
            _waveMaxCount--;
        }
    }
}


