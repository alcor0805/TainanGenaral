using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Alcor
{
    public delegate void FinishDialogue();
    [System.Serializable]
    public class DialogSystem : MonoBehaviour
    {
        public Dictionary<int, DataNPC> System_npc = new Dictionary<int, DataNPC>();
        public List<DataNPC> all_Dialog;
        public TextMeshProUGUI visible_message;
        public TextMeshProUGUI visivle_name;
        public string current_content;
        public bool isDailog = false;
        public int Npc_ID;
        public GameObject button_event;
        public CanvasGroup canvasGroup;
        int index_Chapter = 0;
        int index_sentence = 0;
        int index_chapter_sentence = 0;
        public GameObject dialog;
        private GameObject NPC;
        private person_walk Role;
        /// <summary>
        /// 判斷是誰的名字，如果符合就使用儲存的static state抉擇讀取章節
        /// </summary>
        public void TheChapter()
        {
            switch (dialog.name)
            {
                case "兔子":
                    {
                        NPC = GameObject.Find(dialog.name);
                        if (GameManager_shaft.state == GameManager_shaft.State.fail)
                        {
                            index_Chapter = 0;
                        }
                        if (GameManager_shaft.state == GameManager_shaft.State.sucess)
                        {
                            index_Chapter = 1;
                        }
                        break;
                    }
                case "松鼠":
                    {
                        NPC = GameObject.Find(dialog.name);
                        if (GameManager2.wolfstate == GameManager2.wolfState.fail)
                        {
                            index_Chapter = 0;
                        }
                        if (GameManager2.wolfstate == GameManager2.wolfState.sucess)
                        {
                            index_Chapter = 1;
                        }
                        break;
                    }

            }


        }


        /// <summary>
        /// 將劇本內容全部存入dictionary中
        /// </summary>
        private void Awake()
        {
            Role = GameObject.FindGameObjectWithTag("Player").GetComponent<person_walk>();
            TheChapter();
            isDailog = true;
            foreach (DataNPC data in all_Dialog)
            {
                if (!System_npc.ContainsKey(data.ID))
                    System_npc.Add(data.ID, data);
            }

        }
        /// <summary>
        /// 如果在對話中，列出文本內容
        /// </summary>
        private void Update()
        {
            if (isDailog)
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                StartDialog();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    index_sentence++;
                }
            }
        }
        /// <summary>
        /// 抓取文本的npc名字與說話句子
        /// </summary>
        void StartDialog()
        {
            visivle_name.text = System_npc[Npc_ID].eachChapter[index_Chapter].eachPart_Sentences[index_chapter_sentence].speaker;
            visible_message.text = ChapterSentence();
        }
        /// <summary>
        /// 列出文本內容
        /// </summary>
        string ChapterSentence()
        {
            int Max_sentence = System_npc[Npc_ID].eachChapter[index_Chapter].eachPart_Sentences[index_chapter_sentence].sentence.Count;
            int Max_Chapter_sentence = System_npc[Npc_ID].eachChapter[index_Chapter].eachPart_Sentences.Count;
            if (index_sentence < Max_sentence)
            {
                current_content = System_npc[Npc_ID].eachChapter[index_Chapter].eachPart_Sentences[index_chapter_sentence].sentence[index_sentence];

            }
            else
            {
                index_sentence = 0;
                index_chapter_sentence++;
            }
            if (index_chapter_sentence >= Max_Chapter_sentence)
            {
                if (index_Chapter == 0)
                {
                    isDailog = false;
                    button_event.SetActive(true);
                }
                else if (index_Chapter == 1)
                {
                    isDailog = false;
                    dialog.SetActive(false);
                    NPC.SetActive(false);
                    Role.enabled = true;
                    Gift();
                }

            }
            return current_content;
        }
        private void Gift()
        {
            switch (dialog.name)
            {
                case "兔子":

                    GameObject carrot = Instantiate(Resources.Load<GameObject>("carrot"));
                    carrot.transform.position = new Vector3(NPC.transform.position.x,-3.15f,0);
                    carrot.name = "胡蘿蔔";
                    break;
                case "松鼠":

                    GameObject apple = Instantiate(Resources.Load<GameObject>("apple"));
                    apple.transform.position = new Vector3(NPC.transform.position.x, -3.9f, 0);
                    apple.name = "蘋果";
                    break;
            }
        }

    }
}

