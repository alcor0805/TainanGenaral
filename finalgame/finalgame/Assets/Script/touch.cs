using UnityEngine;
using UnityEngine.UI;
<<<<<<< Updated upstream
namespace Alcor 
=======
using TMPro;
namespace Alcor
>>>>>>> Stashed changes
{
    public class touch : MonoBehaviour
    {
        #region 資料
<<<<<<< Updated upstream
        private GameObject square;
        [SerializeField]
        private Text dialogtext;
        [SerializeField]
        private GameObject dialog;
        #endregion
        #region 功能
        #endregion
        #region 事件
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CircleCollider2D")
            {
                dialog.SetActive (true);
                dialogtext.text="can you help me??";
=======

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
        #region 功能
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
        #region 事件

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.name.Contains("Circle")) ;
            {
                person_Walk.enabled = false;
                helpcanva.inputtext = "can you help me??";
                helpcanva.enabled = true;



>>>>>>> Stashed changes
            }

        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CircleCollider2D")
            {
<<<<<<< Updated upstream
                dialog.SetActive(false);
                
            }
        }
=======
                canvas.alpha = 0;
                canvas.interactable = false;
                canvas.blocksRaycasts = false;

            }
        }

>>>>>>> Stashed changes
        #endregion

    }
}

