using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace NRSUNG
{
    public class GameManager_GUESS : MonoBehaviour
    {
        public InputField playerAnswerUI;
        public int playerAnswer;
        public int correctAnswer;
        public Text hintMessage;
        public Text gameOverMessage;
        public Text m_timmer;
        public int m_min;
        public int m_sec;
        public Button restartButton;
        public Button exitButton;
        private bool gameOver;
        private bool timeOut;
        //public TextMesh hintMessage;
        //public Texture hintMessage;


        void Start()
        {
            //UpdateHintMessage("�п�J 0~99 ���Ʀr");
            NewQuestion();
            FocusPlayerAnswerUI();
            StartCoroutine(CountDown());
        }

        private void Update()
        {
            CheckTimeOut();
        }

        void CheckTimeOut()
        {
            if (timeOut)
            {
                UpadteGameOverMessage("�������� !!!");
                hintMessage.gameObject.SetActive(false);
                playerAnswerUI.gameObject.SetActive(false);
                gameOverMessage.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                exitButton.gameObject.SetActive(true);
                //StopAllCoroutines();
            }
        }

        void UpdateHintMessage(string message)
        {
            hintMessage.text = message;
        }

        void UpadteGameOverMessage(string message)
        {
            gameOverMessage.text = message;
        }

        void NewQuestion()
        {

            UpdateHintMessage("�п�J 0~99 ���Ʀr");
            correctAnswer = Random.Range(0, 100);
            restartButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
            gameOverMessage.gameObject.SetActive(false);
            playerAnswerUI.gameObject.SetActive(true);
            gameOver = false;
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
                UpadteGameOverMessage("���ߧA�L���F !!!");
                playerAnswerUI.gameObject.SetActive(false);
                gameOverMessage.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                exitButton.gameObject.SetActive(true);
                StopAllCoroutines();
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

        public void ExitScene()
        {
            SceneManager.LoadScene(0);
        }

        void FocusPlayerAnswerUI()
        {
            playerAnswerUI.ActivateInputField();
        }

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

                if(m_sec<0 && m_min > 0)
                {
                    m_min -= 1;
                    m_sec = 59;
                }
                else if (m_sec<0 && m_min == 0)
                {
                    m_sec = 0;
                }
                m_timmer.text= string.Format($"{m_min.ToString("00")}" + " : " + $"{m_sec.ToString("00")}");
            }
            timeOut = true;
            //yield return new WaitForSeconds(1);
            //Time.timeScale = 0;
        }
    }
}


