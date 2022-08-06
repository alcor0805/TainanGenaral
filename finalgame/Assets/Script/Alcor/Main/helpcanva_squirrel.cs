using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
namespace Alcor 
{
    public class helpcanva_squirrel : MonoBehaviour
    {
        [SerializeField, Header("player")]
        private Transform player;
        [SerializeField,Header("幫助文字")]
        private TextMeshProUGUI helptext;
        
        private Vector3 x=new Vector3(0,0,0);
        public string inputtext;
        private void Awake()
        {
            if (!GameManager_shaft.dead && GameManager2.wolf_dead)
            {
                PlayerPrefs.SetFloat("squirrel", 0);
            }
            else if(GameManager_shaft.dead && !GameManager2.wolf_dead )
            {
                x = Vector3.right * PlayerPrefs.GetFloat("squirrel");
                player.position = x; 
            }

            Debug.Log("目前位置:"+PlayerPrefs.GetFloat("squirrel"));
        }
        private void Start()
        {
            helptext.text = inputtext;
        }

        public void Whack()
        {
            PlayerPrefs.SetFloat("squirrel", player.position.x);
            SceneManager.LoadScene(2);
        }
    }
}

