using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Alcor
{
    public class touch : MonoBehaviour
    {
        #region ���



        [SerializeField]
        private person_walk person_Walk;
        [SerializeField]
        private GameObject canvas;
        [SerializeField]
        private DataNPC dataNPC;
        public int Num = 0;
        public int CurrentChapter = 0;

        #endregion
        #region �\��
        public void NOEvent()
        {
            person_Walk.enabled = true;

        private GameObject square;
        [SerializeField]
        private person_walk person_Walk;
        [SerializeField]
        private TextMeshProUGUI dialogtext;
        [SerializeField]

        private GameObject canvas;

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
            if (other.gameObject.CompareTag("Player"))
            {
                dataNPC.ID = Num;
                dataNPC.IndexPart = CurrentChapter;
                person_Walk.enabled = false;
                canvas.SetActive(true);
            }

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.name.Contains("Circle")) ;
            {
                person_Walk.enabled = false;
                canvas.SetActive(true);

                helpcanva.inputtext = "can you help me??";
                helpcanva.enabled = true;




            }

        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CircleCollider2D")
            {

                canvas.SetActive(false);

                canvas.alpha = 0;
                canvas.interactable = false;
                canvas.blocksRaycasts = false;

            }
        }

        #endregion

    }
}


