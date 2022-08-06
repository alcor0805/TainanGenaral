using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Alcor
{
    public class touch_rabbit : MonoBehaviour
    {
        #region 資料

       
        [SerializeField]
        private person_walk person_Walk;
        [SerializeField]
        private TextMeshProUGUI dialogtext;
        [SerializeField]
        private helpcanva_rabbit helpcanva;
        [SerializeField]
        private GameObject canvas;
        #endregion
        #region 功能
        public void NOEvent()
        {
            person_Walk.enabled = true;
            canvas.SetActive(false);
        }
        #endregion
        #region 事件

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player")) 
            {
                person_Walk.enabled = false;
                helpcanva.inputtext = "can you help me??";
                canvas.SetActive(true);
                helpcanva.enabled = true;



            }

        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CircleCollider2D")
            {
                canvas.SetActive(false);
            }
        }

        #endregion

    }
}

