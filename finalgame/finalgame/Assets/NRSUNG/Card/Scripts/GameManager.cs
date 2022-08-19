using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace NRSUNG
{
    /// <summary>
    /// �C���޲z�{��
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public int m_min;
        public int m_sec;
        public Button startButton;
        public Button restartButton;
        public Button exitButton;
        public TextMeshProUGUI m_timmerHit;
        public TextMeshProUGUI m_timmer;
        public TextMeshProUGUI hintmessage;
        private bool timeOut;
        public static bool isSucessCard;

        public GameManager gameManager;
        
        [Header("���d�P�M��")]
        public List<Card> cardComparison;  //����諸�d�P�M��

        [Header("�d�P�����M��")]
        public List<CardPattern> cardsToBePutIn; //���G�M��

        public Transform[] positions;

        [Header("�w�t�諸�d�P�ƶq")]
        public int matchedCardsCount = 0;

        void Start()
        {
            //GenerateRandomCards();
            StopAllCoroutines();
            InitStart();            
        }

        private void Update()
        {
            CheckTimeOut();
        }

        public void InitStart()
        {
            startButton.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
            m_timmer.gameObject.SetActive(true);
            m_timmerHit.gameObject.SetActive(true);
            hintmessage.gameObject.SetActive(true);
            UpdateHintMessage("�Ы��}�l��ҰʹC��");
        }

        public void WaitForStart()
        {
            UpdateHintMessage("");
            startButton.gameObject.SetActive(false);
            StartCoroutine(CountDown());
            GenerateRandomCards();
        }

        void UpdateHintMessage(string message)
        {
            hintmessage.text = message;
        }

        void SetupCardsToBePutIn() //Enum �� List
        {
            Array array = Enum.GetValues(typeof(CardPattern));
            foreach (var item in array)
            {
                cardsToBePutIn.Add((CardPattern)item);
                //print(item);
            }
            
            cardsToBePutIn.RemoveAt(0); //�R�� CardPattern.�L
            
        }

        void AddNewCard(CardPattern cardPattern, int positionIndex)
        {
            GameObject card = Instantiate(Resources.Load<GameObject>("Prefabs/�P"));
            card.GetComponent<Card>().cardPattern = cardPattern;
            card.name = "�P_" + cardPattern.ToString();
            card.transform.position = positions[positionIndex].position;            
            GameObject graphic = Instantiate(Resources.Load<GameObject>("Prefabs/��"));
            graphic.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Graphics/" + cardPattern.ToString());
            graphic.transform.SetParent(card.transform);//�ܦ��P���l����
            graphic.transform.localPosition = new Vector3(0, 0, 0.1f);//�]�w�y��
            graphic.transform.eulerAngles = new Vector3(0, 180, 0);//����Y�b��180�� ½�P�ɤ��|���k�A��            
        }

        public void GenerateRandomCards() //�o�P
        {
            int positionIndex = 0;
            for (int i = 0; i < 2; i++)
            {
                // �ǳƥd�P
                SetupCardsToBePutIn();

                // �̤j�üƤ��W�L8
                int maxRandomNumber = cardsToBePutIn.Count;
                for (int j = 0; j < maxRandomNumber; maxRandomNumber--)
                {
                    // ��P
                    // 0��8�������Ͷü�,�̤p�O0 & �̤j�O7
                    int randomNumber = UnityEngine.Random.Range(0, maxRandomNumber);
                    
                    AddNewCard(cardsToBePutIn[randomNumber], positionIndex);
                    
                    cardsToBePutIn.RemoveAt(randomNumber);
                    positionIndex++;
                }
            }            
        }       

        public void AddCardInCardComparision(Card card)
        {
            cardComparison.Add(card);
        }

        public bool ReadyToCompareCards
        {
            get
            {
                if (cardComparison.Count == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void CompareCardsInList()
        {
            if (ReadyToCompareCards)
            {
                //Debug.Log("�i�H���d�P�F");
                if (cardComparison[0].cardPattern == cardComparison[1].cardPattern)
                {
                    Debug.Log("��i�P�@��");
                    UpdateHintMessage("�n�γ� !");
                    foreach (var card in cardComparison)
                    {
                        card.cardState = CardState.�t�令�\;
                    }
                    //cardComparison.Clear();

                    ClearCardComparison();
                    matchedCardsCount = matchedCardsCount + 2;
                    if (matchedCardsCount >= positions.Length)
                    {
                        //StartCoroutine(ReloadScene());
                        //isSucessCard = true;
                        print("���߹L��");
                        //UpdateHintMessage("���߹L�� !!");
                        //StopAllCoroutines();
                        Success();
                    }
                }
                else
                {
                    Debug.Log("��i�P���@��");
                    UpdateHintMessage("���, ���@�˭C !");
                    StartCoroutine(MissMatchCards());                    
                }
            }
        }

        void AddAllCardsToList(Card card)
        {
            cardComparison.Add(card);
        }

        void ClearCardComparison()  //�M��½�P�M��
        {
            cardComparison.Clear();
        }

        void TurnBackCards()    //��P½�^�h
        {
            foreach (var card in cardComparison)
            {
                card.gameObject.transform.eulerAngles = Vector3.zero;
                card.cardState = CardState.��½�P;
            }
        }

        IEnumerator MissMatchCards()
        {
            yield return new WaitForSeconds(1.5f);
            TurnBackCards();
            ClearCardComparison();
        }
        /*
        IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }*/

        IEnumerator CountDown()
        {
            timeOut = false;
            m_timmer.text = string.Format($"{m_min.ToString("00")}" + " : " + $"{m_sec.ToString("00")}");
            int m_seconds = (m_min * 60) + m_sec;
            while (m_seconds > 0 && !timeOut)
            {
                yield return new WaitForSeconds(1);
                m_seconds--;
                m_sec--;

                if (m_sec < 0 && m_min > 0)
                {
                    m_min -= 1;
                    m_sec = 59;
                }
                else if (m_sec < 0 && m_min == 0)
                {
                    m_sec = 0;
                }
                m_timmer.text = string.Format($"{m_min.ToString("00")}" + " : " + $"{m_sec.ToString("00")}");
            }
            timeOut = true;
            yield return new WaitForSeconds(1);
            //Time.timeScale = 0;
        }

        void CheckTimeOut()
        {
            if (timeOut)
            {
                UpdateHintMessage("�������� !!!");
                m_timmer.gameObject.SetActive(true);
                m_timmerHit.gameObject.SetActive(true);                
                restartButton.gameObject.SetActive(true);
                exitButton.gameObject.SetActive(true);
                isSucessCard = false;
                StopAllCoroutines();
            }
        }

        void Success()
        {
            UpdateHintMessage("���߹L�� !!");
            m_timmer.gameObject.SetActive(true);
            m_timmerHit.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
            isSucessCard = true;
            StopAllCoroutines();
        }

        public void ReloadScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        public void ExitScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}


