using UnityEngine;
using UnityEngine.Rendering;

namespace Alcor 
{
    public class PlayerPosition : MonoBehaviour
    {
        private bool rabbit = GameManager_shaft.dead;
        private bool squirell = GameManager2.wolf_dead;
        public float PlayerPosX = 0.0f;
        private void Awake()
        {

            if (!GameManager_shaft.dead)
            {
                PlayerPrefs.SetFloat("PlayerPosX", 0);
            }
            else if (GameManager2.wolf_dead)
            {
                PlayerPrefs.SetFloat("PlayerPosX", 0);
            }
            PlayerPosX = PlayerPrefs.GetFloat("PlayerPosX");

            if(PlayerPosX==0.0f)
            {
                gameObject.transform.position = new Vector3(0, 0, 0);
            }
            if (PlayerPosX != 0.0f)
            {
                gameObject.transform.position = new Vector3(PlayerPosX, 0, 0);
            }
        }

    }
}

