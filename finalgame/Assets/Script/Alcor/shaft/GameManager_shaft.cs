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
        public GameObject Setting_canva;
        public GameObject player;
        public CameraManager cameraManager;
        public static bool dead;

        private void Start()
        {
            dead = false;
            Setting_canva.SetActive(false);
        }
        private void Update()
        {
            if (Player.isDead)
            {
                player.SetActive(false);
                Setting_canva.SetActive(true);
                cameraManager.enabled = false;
                Player.isDead = false;
            }
        }
        public void ReloadScene() 
        {
            SceneManager.LoadScene(1);
        }
        public void MainScene()
        {
            dead = true;
            SceneManager.LoadScene(0);
        }
        #endregion
    }
}

