using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
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
        public GameObject ShouldbeDes;
        /// <summary>
        /// �P�_�O�֪��W�r�A�p�G�ŦX�N�ϥ��x�s��static state���Ū�����`
        /// </summary>
        public void TheChapter()
        {
            switch (dialog.name)
            {
                case "�ߤl":
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
                case "�Q��":
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
        /// �N�@�����e�����s�Jdictionary��
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
        /// �p�G�b��ܤ��A�C�X�奻���e
        /// </summary>
        private void Update()
        {
            if (isDailog)
            {
                StartDialog();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    index_sentence++;
                }
            }
        }
        /// <summary>
        /// ����奻��npc�W�r�P���ܥy�l
        /// </summary>
        void StartDialog()
        {
            visivle_name.text = System_npc[Npc_ID].eachChapter[index_Chapter].eachPart_Sentences[index_chapter_sentence].speaker;
            visible_message.text = ChapterSentence();
        }
        /// <summary>
        /// �C�X�奻���e
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
                if (System_npc[Npc_ID].eachChapter.Count >= 2)
                {
                    switch (index_Chapter)
                    {
                        case 0:
                            isDailog = false;
                            button_event.SetActive(true);
                            
                                
                            break;
                        case 1:
                            
                            isDailog = false;
                            dialog.SetActive(false);
                            NPC.SetActive(false);
                            Role.enabled = true;
                            Gift();
                            break;
                    }
                }
                else if(System_npc[Npc_ID].eachChapter.Count ==1)
                {
                    
                    isDailog = false;
                    dialog.SetActive(false);
                    Role.enabled = true;
                }



            }
            switch (dialog.name)
            {
                case "�ߤl":
                    if (current_content == System_npc[Npc_ID].eachChapter[1].eachPart_Sentences[1].sentence[0])
                    {
                        ShouldbeDes.SetActive(false);
                    }
                    break;
                case "�Q��":
                    if (current_content == System_npc[Npc_ID].eachChapter[1].eachPart_Sentences[2].sentence[0])
                    {
                        ShouldbeDes.SetActive(false);
                    }
                    break;
            }
            return current_content;
        }
        private void Gift()
        {
            switch (dialog.name)
            {
                case "�ߤl":

                    GameObject carrot = Instantiate(Resources.Load<GameObject>("carrot"));
                    carrot.transform.position = new Vector3(NPC.transform.position.x, -3.15f, 0);
                    carrot.name = "�J�ڽ�";
                    PlayerPrefs.SetInt(dialog.name, 0);
                    break;
                case "�Q��":

                    GameObject apple = Instantiate(Resources.Load<GameObject>("apple"));
                    apple.transform.position = new Vector3(NPC.transform.position.x, -3.9f, 0);
                    apple.name = "ī�G";
                    PlayerPrefs.SetInt(dialog.name, 0);
                    break;
            }
        }

    }
}

