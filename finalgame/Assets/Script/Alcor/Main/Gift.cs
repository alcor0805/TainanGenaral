using TMPro;
using UnityEngine;
namespace Alcor 
{
    public class Gift : MonoBehaviour
    {
        private TextMeshProUGUI tip;
        private string Gotcha = "�ܫG";
        private Animator ani;
        private void Awake()
        {
            tip = GameObject.Find("�������~����").GetComponent<TextMeshProUGUI>();
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            ani = GameObject.Find(gameObject.name).GetComponent<Animator>();
            gameObject.SetActive(false);
            tip.text = "�ߨ챼����: "+gameObject.name+" �A�i�H���h�����a���Ʋz�F";
            ani.SetBool(Gotcha, true);
            Invoke("NoneText", 3f);
        }
        void NoneText()
        {
            tip.text = "";
        }
    }
}

