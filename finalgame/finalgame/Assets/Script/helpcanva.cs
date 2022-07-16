using UnityEngine;
using TMPro;
namespace Alcor 
{
    public class helpcanva : MonoBehaviour
    {
        [SerializeField,Header("À°§U¤å¦r")]
        private TextMeshProUGUI helptext;
        [SerializeField]
        private CanvasGroup helpcanvas;
        public string inputtext;
        private void Start()
        {
            helptext.text = inputtext;
            InvokeRepeating("Fadein",0,0.1f);
        }
        private void Fadein()
        {
            helpcanvas.alpha += 0.2f;
            if (helpcanvas.alpha  >= 1)
            {
                helpcanvas.interactable = true;
                helpcanvas.blocksRaycasts = true;
                CancelInvoke("Fadein");
            }
        }
    }
}

