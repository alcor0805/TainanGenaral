using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Alcor
{
    public class touch : MonoBehaviour
    {
        #region 資料


        [SerializeField]
        private person_walk person_Walk;
        [SerializeField]
        private GameObject canvas;
        [SerializeField]
        private DataNPC dataNPC;
        public int Num = 0;
        public int CurrentChapter = 0;

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
                dataNPC.ID = Num;
                dataNPC.IndexPart = CurrentChapter;
                person_Walk.enabled = false;
                canvas.SetActive(true);
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
