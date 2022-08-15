using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace Alcor 
{
    public class SaveData : MonoBehaviour
    {
        private bool rabbit = GameManager_shaft.dead;
        private bool squirell = GameManager2.wolf_dead;
        public static bool[] NPC_FINISH=new bool[4];
        public float PlayerPosX = 0.0f;
        private  GameObject[] NPC;
        
        private void Awake()
        {
            for (int i = 0; i < NPC_FINISH.Length; i++)
            {
                NPC_FINISH[i] = false;
            }
            
            if (!GameManager_shaft.dead || !GameManager2.wolf_dead)
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
        public void SetState(int i)
        {
            NPC_FINISH[i] = true;
        }
        public void SetExists(string NPCname)
        {
            
            for (int i = 0; i < NPC_FINISH.Length; i++)
            {
                if (NPC_FINISH[i])
                {
                    NPC[i]=GameObject.Find(NPCname);
                }
                NPC[i].SetActive(false);
            }
        }

    }
}

