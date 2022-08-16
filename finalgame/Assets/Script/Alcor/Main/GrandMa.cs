using TMPro;
using UnityEngine;

namespace Alcor 
{
    public class GrandMa : MonoBehaviour
    {
        public TextMeshProUGUI finaltext;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                finaltext.text = "阿嬤祝福你身體健康萬事如意，不要被黑貓賣掉";
                FindObjectOfType<person_walk>().enabled = false;
                PlayerPrefs.SetFloat("PlayerPosX", 0);
            }
        }
    }
}

