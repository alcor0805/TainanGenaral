using UnityEngine;
using UnityEngine.SceneManagement;

namespace Alcor 
{
    public class ChanegeScene : MonoBehaviour
    {
        public void ChanageScene(string name)
        {
            PlayerPrefs.SetFloat("PlayerPosX",GameObject.FindGameObjectWithTag("Player").transform.position.x );
            SceneManager.LoadScene(name);
            
        }
    }

}
