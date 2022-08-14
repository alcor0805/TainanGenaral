using TMPro;
using UnityEngine;
namespace Alcor 
{
    public class Gift : MonoBehaviour
    {
        private TextMeshProUGUI tip;
        private void Awake()
        {
            tip = GameObject.Find("掉落物品提示").GetComponent<TextMeshProUGUI>();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            gameObject.SetActive(false);
            tip.text = "撿到掉落物: "+gameObject.name+" ，可以拿去奶奶家做料理了";
            Invoke("NoneText", 3f);
        }
        void NoneText()
        {
            tip.text = "";
        }
    }
}

