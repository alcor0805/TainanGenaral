
using UnityEngine;

namespace Alcor 
{
    public class BGM : MonoBehaviour
    {
        [Header("BGM")]
        public GameObject BackGroundMusic;
        private void Start()
        {
            if (GameObject.FindGameObjectsWithTag("BGM").Length <= 0)
            {
                Instantiate(BackGroundMusic);
            }
        }

    }
}

