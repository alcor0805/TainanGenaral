using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Alcor
{
    public class GameManager : MonoBehaviour
    {
        #region 資料
        public List<card> cardComparison;
 
        #endregion
        #region 功能
        void AddNewCard(card.CardStyle cardstyle)
        {
            GameObject card = Instantiate(Resources.Load<GameObject>("prefebs/back"));
            card.GetComponent<card>().cardStyle = cardstyle;
            card.name = "牌_" ;
            /*GameObject graphic = Instantiate(Resources.Load<GameObject>("prefebs/picture"));
            graphic.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("practice/" + cardstyle.ToString());
            
            graphic.transform.SetParent(card.transform);
            graphic.transform.localPosition = new Vector3(0, 0, 0.1f);
            graphic.transform.eulerAngles = new Vector3(0, 180, 0);*/
        }
        public void AddCardinCardComparison(card card)
        {
            cardComparison.Add(card);
        }
        public bool ReadytoCompareCards
        {
            get
            {
                if (cardComparison.Count == 2)
                    return true;
                else
                    return false;
            }
        }
        public void CompareCardList()
        {
            if (cardComparison[0].cardStyle == cardComparison[1].cardStyle)
            {
                Debug.Log("same");
                foreach (var card in cardComparison)
                {
                    card.cardstate = card.CardState.sucess;
                }
                ClearCard();
            }

            else
            {
                Debug.Log("different");
                StartCoroutine( MissMatchCards());
                
            }
                
        }
        private void ClearCard()
        {
            cardComparison.Clear();
        }
        private void TurnBackCards() 
        {
            foreach (var card in cardComparison)
            {
                card.gameObject.transform.eulerAngles = Vector3.zero;
                card.cardstate = card.CardState.nocard;
            }
        }
        IEnumerator MissMatchCards()
        {
            yield return new WaitForSeconds(1f);
            TurnBackCards();
            ClearCard();
        }
        #endregion
        #region 事件
        private void Start()
        {
            AddNewCard(card.CardStyle.banana);
        }
        #endregion
    }
}

