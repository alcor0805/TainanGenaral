using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Alcor 
{
    public class GameManager_shaft : MonoBehaviour
    {

        #region ���
        #endregion
        #region �\��
        #endregion
        #region �ƥ�
        public GameObject gameObject;
        public GameObject player;
        public CameraManager cameraManager;
        private GroundManager groundManager;
        [SerializeField, Header("���D��r")]
        private TextMeshProUGUI text;
        public static State state=State.fail;
        public static bool dead;

        private void Awake()
        {
            state = State.fail;
            groundManager = GetComponent<GroundManager>();
        }
        private void Start()
        {
            
            dead = false;

            gameObject.SetActive(false);

        }
        private void Update()
        {
            if (Player.isDead||groundManager.CountLowerGroundFloor()>=10)
            {
                player.SetActive(false);
                gameObject.SetActive(true);
                cameraManager.enabled = false;
                if (groundManager.CountLowerGroundFloor() >= 10)
                {
                    Player.isDead = false;
                    state = State.sucess;
                    text.text = "���\�L���F!!!";
                }
                else 
                {
                    Player.isDead = false;
                    state = State.fail;
                    text.text = "�A�դ@���a!!";
                }
                
            }
        }
        public void SetIsDead()
        {
            dead = true;
        }
        public enum State 
        {
            sucess,fail
        }
        #endregion
    }
}

