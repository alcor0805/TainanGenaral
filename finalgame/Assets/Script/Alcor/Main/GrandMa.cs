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
                finaltext.text = "�������֧A���鰷�d�U�Ʀp�N�A���n�Q�¿߽汼";
                FindObjectOfType<person_walk>().enabled = false;
                PlayerPrefs.SetFloat("PlayerPosX", 0);
            }
        }
    }
}

