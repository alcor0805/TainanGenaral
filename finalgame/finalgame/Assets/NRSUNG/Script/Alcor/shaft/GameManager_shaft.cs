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
        public GameObject setting_cacnva;
        public GameObject player;
        public CameraManager cameraManager;
        public static bool dead;

        private void Start()
        {
            dead = false;
            setting_cacnva.SetActive(false);
        }
        private void Update()
        {
            if (Player.isDead)
            {
                player.SetActive(false);
                setting_cacnva.SetActive(true);
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

