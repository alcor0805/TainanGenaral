using TMPro;
using UnityEngine;
namespace Alcor 
{
    public class Gift : MonoBehaviour
    {
        private TextMeshProUGUI tip;
        private void Awake()
        {
            tip = GameObject.Find("�������~����").GetComponent<TextMeshProUGUI>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            gameObject.SetActive(false);
            tip.text = "�ߨ챼����: "+gameObject.name+" �A�i�H���h�����a���Ʋz�F";
            Invoke("NoneText", 3f);
        }
        void NoneText()
        {
            tip.text = "";
        }
    }
}

