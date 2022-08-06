using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
namespace Alcor 
{
    public class helpcanva_rabbit : MonoBehaviour
    {
        [SerializeField, Header("player")]
        private Transform player;
        [SerializeField,Header("���U��r")]
        private TextMeshProUGUI helptext;
        private Vector3 x=new Vector3(0,0,0);
        public string inputtext;
        private void Awake()
        {
            if (!GameManager_shaft.dead)
            {
                PlayerPrefs.SetFloat("rabbit", 0);
            }
            else 
            {
                x = Vector3.right * PlayerPrefs.GetFloat("rabbit");
                player.position = x; 
            }

            Debug.Log("�ثe��m:"+PlayerPrefs.GetFloat("rabbit"));
        }
        private void Start()
        {
            helptext.text = inputtext;
            
        }
        
        public void ShaftScene()
        {
            PlayerPrefs.SetFloat("rabbit", player.position.x);
            SceneManager.LoadScene(1);
            
        }
        
    }
}

