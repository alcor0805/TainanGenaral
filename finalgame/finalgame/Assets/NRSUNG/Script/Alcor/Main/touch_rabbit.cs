using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Alcor
{
    public class touch_rabbit : MonoBehaviour
    {
        #region ���

        private GameObject square;
        [SerializeField]
        private person_walk person_Walk;
        [SerializeField]
        private TextMeshProUGUI dialogtext;
        [SerializeField]
        private helpcanva_rabbit helpcanva;
        [SerializeField]
        private GameObject canvas;
        #endregion
        #region �\��
        public void NOEvent()
        {
            person_Walk.enabled = true;
            canvas.SetActive(false);
           
        }
        #endregion
        #region �ƥ�

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.name.Contains("���p�f")) 
            {
                person_Walk.enabled = false;
                helpcanva.inputtext = "can you help me??";
                
                helpcanva.enabled = true;
                canvas.SetActive(true);


            }

        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CircleCollider2D")
            {
                canvas.SetActive(false) ;

            }
        }

        #endregion

    }
}

