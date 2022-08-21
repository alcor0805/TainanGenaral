using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alcor 
{
    public class ChanegeScene : MonoBehaviour
    {
        private string[] NPC_name = { "¨ß¤l", "ªQ¹«" };
        private string[] Gift_name = { "­JÅÚ½³", "Ä«ªG" };
        public void ChanageScene(string name)
        {
            
            SceneManager.LoadScene(name);
        }
        public void GetPlayerPosition()
        {
            PlayerPrefs.SetFloat("PlayerPosX", GameObject.FindGameObjectWithTag("Player").transform.position.x);
        }
        public void GetPlayerPosition(int position)
        {
            PlayerPrefs.SetFloat("PlayerPosX", position);
        }
        public void GetGiftStatus()
        {
            for (int i = 0; i < Gift_name.Length; i++)
            {
                PlayerPrefs.SetInt(Gift_name[i], 0);
            }
            
        }
        public void InitNPCStatues()
        {
            for (int i = 0; i < NPC_name.Length; i++)
            {
               PlayerPrefs.SetInt( NPC_name[i],1);
            }
        }
 
    }

}
