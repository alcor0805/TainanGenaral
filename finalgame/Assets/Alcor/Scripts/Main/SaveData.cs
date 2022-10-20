using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using NRSUNG;
namespace Alcor
{
    public class SaveData : MonoBehaviour
    {
       
        
        public float PlayerPosX = 0.0f;
        private GameObject[] NPC;
        private string[] NPC_name = { "¨ß¤l", "ªQ¹«","±öªá³À","¥xÆW¶Âºµ" };
        private string[] Gift_name = { "­JÅÚ½³", "Ä«ªG","³·¾õ","¸Á»e" };
        private Animator[] ani=new Animator[4];
       
        private void Awake()
        {
            
            SetPosition();
            SetNpcStatue();
            SetGIft();
            if (PlayerPrefs.GetFloat("PlayerPosX") == 0)
            {
                InitGame();
            }    
        }

        private void SetPosition()
        {
            PlayerPosX = PlayerPrefs.GetFloat("PlayerPosX");
            gameObject.transform.position = new Vector3(PlayerPosX, -2f, 0);
        }
        private void SetNpcStatue()
        {
            for (int i = 0; i < NPC_name.Length; i++)
            {
               
                bool status=PlayerPrefs.GetInt(NPC_name[i])==0 ? true : false;
                if (status)
                {
                    GameObject.Find(NPC_name[i]).SetActive(false);

                }
            }
        }
        private void SetGIft()
        {
            for (int i = 0; i < Gift_name.Length; i++)
            {
                bool gift_status = PlayerPrefs.GetInt(Gift_name[i]) == 1 ? true : false;
                ani[i] = GameObject.Find(Gift_name[i]).GetComponent<Animator>();
                if (gift_status)
                {
                    ani[i].SetBool("ÅÜ«G", true);
                }
            }
        }
        private void InitGame()
        {

            
            GameManager2.wolfstate=GameManager2.wolfState.fail;
            GameManager_shaft.state = GameManager_shaft.State.fail;
            GameManager.state = GameManager.State.fail;
            GameManager_GUESS.state = GameManager_GUESS.State.fail;
        }

    }
}

