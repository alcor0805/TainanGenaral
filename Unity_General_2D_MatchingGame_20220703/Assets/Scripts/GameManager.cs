using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
namespace NRSUNG
{
    /// <summary>
    /// �C���޲z�{��
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [Header("�d�P�M��")]
        public List<Card> cardList;  //���ͥX�Ӫ�16�i�d�P�M��

        [Header("���d�P�M��")]
        public List<Card> cardComparison;  //����諸�d�P�M��

        [Header("�d�P�����M��")]
        public List<CardPattern> cardsToBePutIn; //���G�M��

        public Transform[] positions;

        [Header("�w�t�諸�d�P�ƶq")]
        public int matchedCardsCount = 0;

        void Start()
        {
            //SetupCardsToBePutIn();
            //AddNewCard(CardPattern.���e��);
            GenerateRandomCards();
        }

        void SetupCardsToBePutIn() //Enum �� List
        {
            Array array = Enum.GetValues(typeof(CardPattern));
            foreach (var item in array)
            {
                cardsToBePutIn.Add((CardPattern)item);
                print(item);
            }
            
            cardsToBePutIn.RemoveAt(0); //�R�� CardPattern.�L
            
        }

        void AddNewCard(CardPattern cardPattern, int positionIndex)
        {
            GameObject card = Instantiate(Resources.Load<GameObject>("Prefabs/�P"));
            card.GetComponent<Card>().cardPattern = cardPattern;
            card.name = "�P_" + cardPattern.ToString();
            card.transform.position = positions[positionIndex].position;
            //AddCardInCardComparision(this);
            GameObject graphic = Instantiate(Resources.Load<GameObject>("Prefabs/��"));
            graphic.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Graphics/" + cardPattern.ToString());
            graphic.transform.SetParent(card.transform);//�ܦ��P���l����
            graphic.transform.localPosition = new Vector3(0, 0, 0.1f);//�]�w�y��
            graphic.transform.eulerAngles = new Vector3(0, 180, 0);//����Y�b��180�� ½�P�ɤ��|���k�A��
            
        }

        void GenerateRandomCards() //�o�P
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
                    //AddCardInCardComparision();
                    //cardList.Add(cardsToBePutIn[randomNumber]);
                    //print(cardsToBePutIn[randomNumber]);
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
                    foreach (var card in cardComparison)
                    {
                        card.cardState = CardState.�t�令�\;
                    }
                    //cardComparison.Clear();

                    ClearCardComparison();
                    matchedCardsCount = matchedCardsCount + 2;
                    if (matchedCardsCount >= positions.Length)
                    {
                        StartCoroutine(ReloadScene());
                    }
                }
                else
                {
                    Debug.Log("��i�P���@��");
                    StartCoroutine(MissMatchCards());
                    //TurnBackCards();
                    //cardComparison.Clear();
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

        void TurnOpenAllCards()    //������P½�쥿��
        {
            foreach (var card in cardList)
            {
                //card.gameObject.transform.eulerAngles = Vector3.zero;
                card.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                card.cardState = CardState.�w½�P;
            }
        }

        void TurnBackAllCards()    //������P½��I��
        {
            foreach (var card in cardList)
            {
                //card.gameObject.transform.eulerAngles = Vector3.zero;
                card.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                card.cardState = CardState.��½�P;
            }
        }

        IEnumerator MissMatchCards()
        {
            yield return new WaitForSeconds(1.5f);
            TurnBackCards();
            ClearCardComparison();
        }

        IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}


