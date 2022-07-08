using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NRSUNG
{
    /// <summary>
    /// �d�P�޲z�{��
    /// </summary>
    public class Card : MonoBehaviour
    {
        public CardState cardState;
        public CardPattern cardPattern;
        public GameManager gameManager;

        private void Start()
        {
            cardState = CardState.��½�P;
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        }

        private void OnMouseUp()
        {
            if (cardState.Equals(CardState.�w½�P))
            {
                return;
            }

            if (gameManager.ReadyToCompareCards)
            {
                return;
            }
            OpenCard();
            gameManager.AddCardInCardComparision(this);
            gameManager.CompareCardsInList();
            
        }

        void OpenCard()
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            cardState = CardState.�w½�P;
        }

    }

    public enum CardState
    {
        ��½�P, �w½�P, �t�令�\
    }


    public enum CardPattern
    {
        �L, �_���G, �h��, ��l, ���e��, �ݼ�, ����, ī�G, ���
    }
}

