using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alcor 
{
    public class monster : MonoBehaviour
    {
        #region ���
        GameManager_whack gameManager;
        public float maxSecondScreen = 2.5f;
        public float currentSecondScreen = 0;
        public bool IsActive => gameObject.activeInHierarchy;
        bool OnScreenTimeUp => currentSecondScreen < 0;
        #endregion
        #region �\��
        private void Hide()
        {
            gameManager.HideMonster(gameObject);
        }
        private void Init()
        {
            gameManager = FindObjectOfType<GameManager_whack>().GetComponent<GameManager_whack>();
            ResetCurrentSecondsOnScreen();
        }
        private void ResetCurrentSecondsOnScreen()
        {
            currentSecondScreen = maxSecondScreen;
        }
        private void CountDownCurrentSecondsOnScreen()
        {
            currentSecondScreen -= Time.fixedDeltaTime;
        }
        private void TryCountDownToHide()
        {
            if (IsActive)
            {
                CountDownCurrentSecondsOnScreen();
            }
            if (OnScreenTimeUp)
            {
                ResetCurrentSecondsOnScreen();
                Hide();
            }
        }
        #endregion
        #region �ƥ�
        private void Start()
        {
            Init();
        }
        private void OnMouseDown()
        {
            gameManager.AddScore();
                ResetCurrentSecondsOnScreen();
                Hide();
            
        }     

        private void FixedUpdate()
        {
            TryCountDownToHide();
        }

        




        #endregion

    }
}

