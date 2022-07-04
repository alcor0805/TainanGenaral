using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    [Header("比對卡牌清單")]
    public List<Card> cardComparison;

    [Header("卡牌種類清單")]
    public List<CardPattern> cardsToBePutIn;

    void Start()
    {
        //SetupCardsToBePutIn();
        //AddNewCard(CardPattern.水蜜桃);
        GenerateRandomCards();
    }

    void SetupCardsToBePutIn() //Enum 轉 List
    {
        Array array = Enum.GetValues(typeof(CardPattern));
        foreach(var item in array)
        {
            cardsToBePutIn.Add((CardPattern)item);
        }
        cardsToBePutIn.RemoveAt(0); //刪掉 CardPattern.無
    }

    void GenerateRandomCards() //發牌
    {
        // 準備卡牌
        SetupCardsToBePutIn();

        // 最大亂數不超過8
        int maxRandomNumber = cardsToBePutIn.Count;

        // 0到8之間產生亂數,最小是0 & 最大是7
        int randomNumber = UnityEngine.Random.Range(0, maxRandomNumber);

        // 抽牌
        AddNewCard(cardsToBePutIn[randomNumber]);
        cardsToBePutIn.RemoveAt(randomNumber);
    }

    void AddNewCard(CardPattern cardPattern)
    {
        GameObject card = Instantiate(Resources.Load<GameObject>("Prefabs/牌"));
        card.GetComponent<Card>().cardPattern = cardPattern;
        card.name = "牌_" + cardPattern.ToString();
        //card.transform.position = positions[positionIndex].position;

        GameObject graphic = Instantiate(Resources.Load<GameObject>("Prefabs/圖"));



        graphic.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Graphics/" + cardPattern.ToString());



        graphic.transform.SetParent(card.transform);//變成牌的子物件
        graphic.transform.localPosition = new Vector3(0, 0, 0.1f);//設定座標
        graphic.transform.eulerAngles = new Vector3(0, 180, 0);//順著Y軸轉180度 翻牌時不會左右顛倒
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
                foreach(var card in cardComparison)
                {
                    card.cardState = CardState.配對成功;
                }
                cardComparison.Clear();
            }
            else
            {
                Debug.Log("兩張牌不一樣");
                StartCoroutine(MissMatchCards());
                //TurnBackCards();
                //cardComparison.Clear();
            }
        }
    }

    void ClearCardComparison()  //清除翻牌清單
    {
        cardComparison.Clear();     
    }

    void TurnBackCards()    //把牌翻回去
    {
        foreach(var card in cardComparison)
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

}
