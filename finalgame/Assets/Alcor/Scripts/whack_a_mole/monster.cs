using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alcor 
{
    public class monster : MonoBehaviour
    {
        #region ���
        GameManager2 gameManager;
        public float maxSecondScreen = 2.5f;
        public float currentSecondScreen = 0;
        public bool IsActive => gameObject.activeInHierarchy;
        bool OnScreenTimeUp => currentSecondScreen < 0;
        public AudioClip soundbark;
        private AudioSource aud;
        #endregion
        #region �\��
        private void Hide()
        {
            gameManager.HideMonster(gameObject);
           
        }
        private void Init()
        {
            gameManager = FindObjectOfType<GameManager2>().GetComponent<GameManager2>();
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
		private void Awake()
		{
           
            aud = GetComponent<AudioSource>();
		}
		private void Start()
        {
            Init();
        }
        private void OnMouseDown()
        {
            gameManager.AddScore();
                ResetCurrentSecondsOnScreen();
                Hide();
            Instantiate(gameManager.effect,gameObject.transform.position,gameManager.effect.transform.rotation);
            
        }     

        private void FixedUpdate()
        {
            TryCountDownToHide();
        }

        




        #endregion

    }
}

