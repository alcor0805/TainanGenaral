using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace Alcor 
{
    public class GameManager_shaft : MonoBehaviour
    {

        #region 資料
        #endregion
        #region 功能
        #endregion
        #region 事件
        public GameObject gameObject;
        public GameObject player;
        public CameraManager cameraManager;
        private void Start()
        {
            gameObject.SetActive(false);
        }
        private void Update()
        {
            if (Player.isDead)
            {
                player.SetActive(false);
                gameObject.SetActive(true);
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
            SceneManager.LoadScene(0);
        }
        #endregion
    }
}

