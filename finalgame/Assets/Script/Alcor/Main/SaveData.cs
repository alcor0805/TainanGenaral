using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace Alcor
{
    public class SaveData : MonoBehaviour
    {
       
        public static bool[] animator_State = new bool[4];
        public float PlayerPosX = 0.0f;
        private GameObject[] NPC;

        private void Awake()
        {
            PlayerPosX = PlayerPrefs.GetFloat("PlayerPosX");


            gameObject.transform.position = new Vector3(PlayerPosX, -0.5f, 0);

        }
       

    }
}

