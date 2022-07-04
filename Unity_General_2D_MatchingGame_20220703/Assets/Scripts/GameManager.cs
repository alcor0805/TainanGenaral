using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("���d�P�M��")]
    public List<Card> cardComparison;

    void Start()
    {
        
    }

    void AddNewCard(CardPattern cardPattern, int positionIndex)
    {
        GameObject card = Instantiate(Resources.Load<GameObject>("Prefabs/�P"));
        card.GetComponent<Card>().cardPattern = cardPattern;
        card.name = "�P_" + cardPattern.ToString();
        //card.transform.position = positions[positionIndex].position;

        GameObject graphic = Instantiate(Resources.Load<GameObject>("Prefabs/��"));



        graphic.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Graphics/" + cardPattern.ToString());



        graphic.transform.SetParent(card.transform);//�ܦ��P���l����
        graphic.transform.localPosition = new Vector3(0, 0, 0.1f);//�]�w�y��
        graphic.transform.eulerAngles = new Vector3(0, 180, 0);//����Y�b��180�� ½�P�ɤ��|���k�A��
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
                foreach(var card in cardComparison)
                {
                    card.cardState = CardState.�t�令�\;
                }
                cardComparison.Clear();
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

    void ClearCardComparison()  //�M��½�P�M��
    {
        cardComparison.Clear();     
    }

    void TurnBackCards()    //��P½�^�h
    {
        foreach(var card in cardComparison)
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

}
