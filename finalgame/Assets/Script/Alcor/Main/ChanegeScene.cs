using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alcor 
{
    public class ChanegeScene : MonoBehaviour
    {
        public void ChanageScene(string name)
        {
            
            SceneManager.LoadScene(name);
        }
        public void GetPlayerPosition()
        {
            PlayerPrefs.SetFloat("PlayerPosX", GameObject.FindGameObjectWithTag("Player").transform.position.x);
        }
    }

}
