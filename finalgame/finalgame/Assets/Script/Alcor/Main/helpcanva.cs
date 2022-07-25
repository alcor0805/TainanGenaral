using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
namespace Alcor 
{
    public class helpcanva : MonoBehaviour
    {
        [SerializeField, Header("player")]
        private Transform player;
        [SerializeField,Header("幫助文字")]
        private TextMeshProUGUI helptext;
        [SerializeField]
        private CanvasGroup helpcanvas;
        private Vector3 x=new Vector3(0,0,0);
        public string inputtext;
        private void Awake()
        {
            if (!GameManager_shaft.dead)
            {
                PlayerPrefs.SetFloat("square", 0);
            }
            else
            {
                x = Vector3.right * PlayerPrefs.GetFloat("square");
                player.position = x; 
            }

            Debug.Log("目前位置:"+PlayerPrefs.GetFloat("Square"));
        }
        private void Start()
        {
            helptext.text = inputtext;
            InvokeRepeating("Fadein",0,0.1f);
        }
        private void Fadein()
        {
            helpcanvas.alpha += 0.2f;
            if (helpcanvas.alpha  >= 1)
            {
                helpcanvas.interactable = true;
                helpcanvas.blocksRaycasts = true;
                CancelInvoke("Fadein");
            }
        }
        public void ShaftScene()
        {
            PlayerPrefs.SetFloat("square", player.position.x);
            SceneManager.LoadScene(1);
            

        }
        public void Card()
        {
            PlayerPrefs.SetFloat("square", player.position.x);
            SceneManager.LoadScene(4);
        }
    }
}

