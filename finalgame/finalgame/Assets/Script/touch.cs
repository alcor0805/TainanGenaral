using UnityEngine;
using UnityEngine.UI;
namespace Alcor 
{
    public class touch : MonoBehaviour
    {
        #region ���
        private GameObject square;
        [SerializeField]
        private Text dialogtext;
        [SerializeField]
        private GameObject dialog;
        #endregion
        #region �\��
        #endregion
        #region �ƥ�
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CircleCollider2D")
            {
                dialog.SetActive (true);
                dialogtext.text="can you help me??";
            }

        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CircleCollider2D")
            {
                dialog.SetActive(false);
                
            }
        }
        #endregion

    }
}

