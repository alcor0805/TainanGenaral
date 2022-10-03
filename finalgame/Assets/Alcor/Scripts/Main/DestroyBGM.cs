
using UnityEngine;

namespace Alcor 
{
    public class DestroyBGM : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
}

