using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Alcor 
{
    public class GameManager_shaft : MonoBehaviour
    {

        #region ���
        #endregion
        #region �\��
        #endregion
        #region �ƥ�
        public Button button;
        public GameObject player;
        public CameraManager cameraManager;
        private void Start()
        {
            button.gameObject.SetActive(false);
        }
        private void Update()
        {
            if (Player.isDead)
            {
                player.SetActive(false);
                button.gameObject.SetActive(true);
                cameraManager.enabled = false;
                Player.isDead = false;
            }
        }
        public void ReloadScene() 
        {
            SceneManager.LoadScene(0);
        }
        #endregion
    }
}

