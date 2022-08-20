using UnityEngine;

namespace Alcor 
{
    public class Elf : MonoBehaviour
    {
        public GameObject elf;
        private void Awake()
        {
            if (PlayerPrefs.GetFloat("PlayerPosX") == 0)
            {
                elf.SetActive(true);
                if (FindObjectOfType<DialogSystem>().isDailog && GameObject.Find("§p∫Î∆F"))
                    FindObjectOfType<person_walk>().enabled = false;
                
            }
        }
    }
}

