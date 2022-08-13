using System.Collections;
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
        DataNPC current_dataNPC;
        /// <summary>
        /// 設置文本資訊為dictionary(0,0)
        /// </summary>
        public void SetDialogInfo(int NPC, int Chapter)
        {
            Npc_ID = NPC;
            index_Chapter = Chapter;
            current_dataNPC = System_npc[NPC];
            Initialize();
            isDailog = true;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            index_sentence = 0;
            index_chapter_sentence = 0;
        }
        /// <summary>
        /// 將劇本內容全部存入dictionary中
        /// </summary>
        private void Awake()
        {
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
        /*public IEnumerator StartDialog(DataNPC _dataNPC)
         {
             _dataNPC = current_dataNPC;
             if (isDailog)
             {
                 StartDialog();
                 for (int i = 0; i < ChapterSentence().Length; i++)
                 {
                     yield return StartCoroutine(TypeEffect(i));
                     while(!Input.GetKeyDown(KeyCode.E))
                     {
                         yield return null;
                     }

                 }

             }
         }*/
        private void Update()
        {
            if(isDailog)
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
                isDailog = false;
                button_event.SetActive(true);
            }
            return current_content;
        }


    }
}

