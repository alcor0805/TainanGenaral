using TMPro;
using UnityEngine;

namespace Alcor 
{
    public class GrandMa : MonoBehaviour
    {
        private string[] NPC_name = { "兔子", "松鼠", "梅花鹿", "台灣黑熊" };
        public TextMeshProUGUI finaltext;
        private string[] Gift_name = { "胡蘿蔔", "蘋果" };
        public GameObject setting;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                finaltext.text = "阿嬤祝福你身體健康萬事如意，不要被黑貓賣掉";
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

