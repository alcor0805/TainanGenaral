using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace NRSUNG
{
    public class GameManager : MonoBehaviour
    {
        public InputField playerAnswerUI;
        public int playerAnswer;
        public int correctAnswer;
        public Text hintMessage;
        public Button restartButton;
        //public TextMesh hintMessage;
        //public Texture hintMessage;


        void Start()
        {
            //UpdateHintMessage("請輸入 0~99 的數字");
            NewQuestion();
            FocusPlayerAnswerUI();
        }

        void Update()
        {

        }

        void UpdateHintMessage(string message)
        {
            hintMessage.text = message;
        }

        void NewQuestion()
        {
            UpdateHintMessage("請輸入 0~99 的數字");
            correctAnswer = Random.Range(0, 100);
            restartButton.gameObject.SetActive(false);
        }

        bool CanGetInputNumber()
        {
            return int.TryParse(playerAnswerUI.text, out playerAnswer);
        }

        public void CompareNumbers()
        {
            //playerAnswer = int.Parse(playerAnswerUI.text);
            if (!CanGetInputNumber())
            {
                UpdateHintMessage("只能輸入數字喔");
                return;
            }

            if (playerAnswer == correctAnswer)
            {
                UpdateHintMessage("恭喜你答對了");
                restartButton.gameObject.SetActive(true);
            }
            else if (playerAnswer > correctAnswer)
            {
                UpdateHintMessage("答案還要小一點");
            }
            else if (playerAnswer < correctAnswer)
            {
                UpdateHintMessage("答案還要大一點");
            }
            FocusPlayerAnswerUI();
        }

        public void ClearHintMessage()
        {
            UpdateHintMessage("");
        }

        public void ReloadScene()
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        void FocusPlayerAnswerUI()
        {
            playerAnswerUI.ActivateInputField();
        }
    }
}


