using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace Alcor
{
    public class SaveData : MonoBehaviour
    {
       
        
        public float PlayerPosX = 0.0f;
        private GameObject[] NPC;
        private string[] NPC_name = { "�ߤl", "�Q��", "�����", "�x�W�º�" };
        private string[] Gift_name = { "�J�ڽ�", "ī�G" };
        private Animator[] ani=new Animator[2];
        private void Awake()
        {
            
            SetPosition();
            SetNpcStatue();
            SetGIft();
        }

        private void SetPosition()
        {
            PlayerPosX = PlayerPrefs.GetFloat("PlayerPosX");
            gameObject.transform.position = new Vector3(PlayerPosX, -0.5f, 0);
        }
        private void SetNpcStatue()
        {
            for (int i = 0; i < NPC_name.Length; i++)
            {
                bool status=PlayerPrefs.GetInt(NPC_name[i])==0 ? true : false;
                if (status)
                {
                    GameObject.Find(NPC_name[i]).SetActive(false);

                }
            }
        }
        private void SetGIft()
        {
            for (int i = 0; i < Gift_name.Length; i++)
            {
                bool gift_status = PlayerPrefs.GetInt(Gift_name[i]) == 1 ? true : false;
                ani[i] = GameObject.Find(Gift_name[i]).GetComponent<Animator>();
                if (gift_status)
                {
                    ani[i].SetBool("�ܫG", true);
                }
            }
        }

    }
}

