using System;
using System.Collections;
using System.Collections.Generic;
using ThirdPersonShooter.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace ThirdPersonShooter.Uis
{
    public class StartButton : MonoBehaviour
    { 
        Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClick);
        }

        private void HandleOnButtonClick()
        {
            GameManager.Instance.LoadLevel("Game");
        }
    }

}

