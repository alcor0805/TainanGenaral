using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Alcor
{
    public class touch : MonoBehaviour
    {
        #region ���

        private GameObject square;
        [SerializeField]
        private person_walk person_Walk;
        [SerializeField]
        private TextMeshProUGUI dialogtext;
        [SerializeField]
        private helpcanva helpcanva;
        [SerializeField]
        private CanvasGroup canvas;
        #endregion
        #region �\��
        public void YesEvent()
        {
            person_Walk.enabled = true;
            canvas.alpha = 0;
            canvas.interactable = false;
            canvas.blocksRaycasts = false;
        }
        public void NOEvent()
        {
            person_Walk.enabled = true;
            canvas.alpha = 0;
            canvas.interactable = false;
            canvas.blocksRaycasts = false;
        }
        #endregion
        #region �ƥ�

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.name.Contains("Circle")) ;
            {
                person_Walk.enabled = false;
                helpcanva.inputtext = "can you help me??";
                helpcanva.enabled = true;



            }

        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CircleCollider2D")
            {
                canvas.alpha = 0;
                canvas.interactable = false;
                canvas.blocksRaycasts = false;

            }
        }

        #endregion

    }
}

