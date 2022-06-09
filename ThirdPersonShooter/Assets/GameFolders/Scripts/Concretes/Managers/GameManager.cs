
using System.Collections;
using ThirdPersonShooter.Abstracts.Helpers;
using UnityEngine.SceneManagement;

namespace ThirdPersonShooter.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
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
    }
}


