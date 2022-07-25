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
            //UpdateHintMessage("�п�J 0~99 ���Ʀr");
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
            UpdateHintMessage("�п�J 0~99 ���Ʀr");
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
                UpdateHintMessage("�u���J�Ʀr��");
                return;
            }

            if (playerAnswer == correctAnswer)
            {
                UpdateHintMessage("���ߧA����F");
                restartButton.gameObject.SetActive(true);
            }
            else if (playerAnswer > correctAnswer)
            {
                UpdateHintMessage("�����٭n�p�@�I");
            }
            else if (playerAnswer < correctAnswer)
            {
                UpdateHintMessage("�����٭n�j�@�I");
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


