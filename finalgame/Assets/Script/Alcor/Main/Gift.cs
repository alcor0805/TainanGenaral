using TMPro;
using UnityEngine;
namespace Alcor 
{
    public class Gift : MonoBehaviour
    {
        private TextMeshProUGUI tip;
        private string Gotcha = "變亮";
        private Animator ani;
        private void Awake()
        {
            tip = GameObject.Find("掉落物品提示").GetComponent<TextMeshProUGUI>();
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            ani = GameObject.Find(gameObject.name).GetComponent<Animator>();
            gameObject.SetActive(false);
            tip.text = "撿到掉落物: "+gameObject.name+" ，可以拿去奶奶家做料理了";
            ani.SetBool(Gotcha, true);
            Invoke("NoneText", 3f);
        }
        void NoneText()
        {
            tip.text = "";
        }
    }
}

