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
        public void ExitGame()
        {
            Application.Quit();
        }
        public void InitAllStatus()
        {
            for (int i = 0; i < Gift_name.Length; i++)
            {
                PlayerPrefs.SetInt(Gift_name[i], 0);
            }
            for (int i = 0; i < NPC_name.Length; i++)
            {
                PlayerPrefs.SetInt(NPC_name[i], 1);
            }
            PlayerPrefs.SetFloat("PlayerPosX", 0);
        }
        public void IsInit()
        {
            if (PlayerPrefs.GetFloat("PlayerPosX") == 0)
            {
                InitAllStatus();
            }
        }
 
    }

}
