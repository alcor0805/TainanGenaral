using UnityEngine;

namespace Alcor 
{
    public class card : MonoBehaviour
    {
        #region  資料
        public CardState cardstate;
        public GameManager gameManager;
        public CardStyle cardStyle;
        #endregion
        #region  功能
        public enum CardState
        {
            nocard, okcard, sucess
        }
        void OpenCard()
        {
            transform.eulerAngles = new Vector3(0, 181, 0);
            cardstate = CardState.okcard;
        }
        public enum CardStyle 
        {
            none,banana,grape,orange,apple,guava
        }
        #endregion
        #region  事件
        private void Start()
        {
            cardstate = CardState.nocard;
        }
        private void OnMouseDown()
        {
            if (cardstate.Equals(CardState.okcard))
            {
                return;
            }
            if (gameManager.ReadytoCompareCards)
                return;
            OpenCard();
            gameManager.AddCardinCardComparison(this);
            gameManager.CompareCardList();
        }
        #endregion

    }
}

