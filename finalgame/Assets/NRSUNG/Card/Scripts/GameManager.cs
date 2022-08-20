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
    /// 遊戲管理程式
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
        
        [Header("比對卡牌清單")]
        public List<Card> cardComparison;  //欲比對的卡牌清單

        [Header("卡牌種類清單")]
        public List<CardPattern> cardsToBePutIn; //水果清單

        public Transform[] positions;

        [Header("已配對的卡牌數量")]
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
            UpdateHintMessage("請按開始鍵啟動遊戲");
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

        void SetupCardsToBePutIn() //Enum 轉 List
        {
            Array array = Enum.GetValues(typeof(CardPattern));
            foreach (var item in array)
            {
                cardsToBePutIn.Add((CardPattern)item);
                //print(item);
            }
            
            cardsToBePutIn.RemoveAt(0); //刪掉 CardPattern.無
            
        }

        void AddNewCard(CardPattern cardPattern, int positionIndex)
        {
            GameObject card = Instantiate(Resources.Load<GameObject>("Prefabs/牌"));
            card.GetComponent<Card>().cardPattern = cardPattern;
            card.name = "牌_" + cardPattern.ToString();
            card.transform.position = positions[positionIndex].position;            
            GameObject graphic = Instantiate(Resources.Load<GameObject>("Prefabs/圖"));
            graphic.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Graphics/" + cardPattern.ToString());
            graphic.transform.SetParent(card.transform);//變成牌的子物件
            graphic.transform.localPosition = new Vector3(0, 0, 0.1f);//設定座標
            graphic.transform.eulerAngles = new Vector3(0, 180, 0);//順著Y軸轉180度 翻牌時不會左右顛倒            
        }

        public void GenerateRandomCards() //發牌
        {
            int positionIndex = 0;
            for (int i = 0; i < 2; i++)
            {
                // 準備卡牌
                SetupCardsToBePutIn();

                // 最大亂數不超過8
                int maxRandomNumber = cardsToBePutIn.Count;
                for (int j = 0; j < maxRandomNumber; maxRandomNumber--)
                {
                    // 抽牌
                    // 0到8之間產生亂數,最小是0 & 最大是7
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
                //Debug.Log("可以比對卡牌了");
                if (cardComparison[0].cardPattern == cardComparison[1].cardPattern)
                {
                    Debug.Log("兩張牌一樣");
                    UpdateHintMessage("好棒喔 !");
                    foreach (var card in cardComparison)
                    {
                        card.cardState = CardState.配對成功;
                    }
                    //cardComparison.Clear();

                    ClearCardComparison();
                    matchedCardsCount = matchedCardsCount + 2;
                    if (matchedCardsCount >= positions.Length)
                    {
                        //StartCoroutine(ReloadScene());
                        //isSucessCard = true;
                        print("恭喜過關");
                        //UpdateHintMessage("恭喜過關 !!");
                        //StopAllCoroutines();
                        Success();
                    }
                }
                else
                {
                    Debug.Log("兩張牌不一樣");
                    UpdateHintMessage("喔喔, 不一樣耶 !");
                    StartCoroutine(MissMatchCards());                    
                }
            }
        }

        void AddAllCardsToList(Card card)
        {
            cardComparison.Add(card);
        }

        void ClearCardComparison()  //清除翻牌清單
        {
            cardComparison.Clear();
        }

        void TurnBackCards()    //把牌翻回去
        {
            foreach (var card in cardComparison)
            {
                card.gameObject.transform.eulerAngles = Vector3.zero;
                card.cardState = CardState.未翻牌;
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
                UpdateHintMessage("闖關失敗 !!!");
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
            UpdateHintMessage("恭喜過關 !!");
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


