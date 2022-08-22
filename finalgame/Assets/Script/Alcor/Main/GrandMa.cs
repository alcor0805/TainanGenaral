using TMPro;
using UnityEngine;

namespace Alcor 
{
    public class GrandMa : MonoBehaviour
    {
        private string[] NPC_name = { "�ߤl", "�Q��", "�����", "�x�W�º�" };
        public TextMeshProUGUI finaltext;
        private string[] Gift_name = { "�J�ڽ�", "ī�G" };
        public GameObject setting;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                finaltext.text = "�������֧A���鰷�d�U�Ʀp�N�A���n�Q�¿߽汼";
                FindObjectOfType<person_walk>().enabled = false;
                PlayerPrefs.SetFloat("PlayerPosX", 0);
                ResetStatus();
                ResetGiftStatus();
            }
        }
        private void ResetStatus()
        {
            for (int i = 0; i < NPC_name.Length; i++)
            {
                PlayerPrefs.SetInt(NPC_name[i], 1);
            }
        }
        private void ResetGiftStatus()
        {
            for (int i = 0; i < Gift_name.Length; i++)
            {
                PlayerPrefs.SetInt(Gift_name[i], 0);
            }
        }
    }
}

