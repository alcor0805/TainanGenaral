using UnityEngine;

namespace Alcor
{
    public class Tips : MonoBehaviour
    {
        public GameObject How_Tips;
        public void callTips()
        {
            How_Tips.SetActive(true);
            Invoke("TipsClick_Close", 3f);
        }
        private void TipsClick_Close()
        {
            How_Tips.SetActive(false);
        }
    }
}

