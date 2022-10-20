using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
        //public Text m_timmerHit;
        public TextMeshProUGUI m_timmerHit;
        
        public int m_min;
        public int m_sec;
        public Button startButton;
        public Button restartButton;
        public Button exitButton;
        private bool timeOut;
        //public TextMesh hintMessage;
        //public Texture hintMessage;

        //public bool isSucessGuessNumber = false;
        public static State state = State.fail;


        void Start()
        {
            InitStart();
        }

        private void Update()
        {
            CheckTimeOut();
        }

        void InitStart()
        {
            UpadteGameOverMessage("請按開始按鈕開始遊戲");
            m_timmer.gameObject.SetActive(true);
            m_timmerHit.gameObject.SetActive(true);
            hintMessage.gameObject.SetActive(false);
            playerAnswerUI.gameObject.SetActive(false);
            gameOverMessage.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);            
        }

        public void WaitForStart()
        {
            NewQuestion();
            FocusPlayerAnswerUI();
            StartCoroutine(CountDown());
        }

        void CheckTimeOut()
        {
            if (timeOut)
            {
                UpadteGameOverMessage("闖關失敗 !!!");
                m_timmer.gameObject.SetActive(true);
                m_timmerHit.gameObject.SetActive(true);
                hintMessage.gameObject.SetActive(false);
                playerAnswerUI.gameObject.SetActive(false);
                gameOverMessage.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                exitButton.gameObject.SetActive(true);
                state = State.fail;
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

            UpdateHintMessage("請輸入 0~99 的數字");
            correctAnswer = Random.Range(0, 100);
            m_timmer.gameObject.SetActive(true);
            m_timmerHit.gameObject.SetActive(true);
            hintMessage.gameObject.SetActive(true);
            playerAnswerUI.gameObject.SetActive(true);
            startButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
            gameOverMessage.gameObject.SetActive(false);
            
            
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
                FocusPlayerAnswerUI();
                return;
            }

            if (playerAnswer == correctAnswer)
            {
                UpdateHintMessage("恭喜你答對了");
                UpadteGameOverMessage("恭喜你過關了 !!!");
                playerAnswerUI.gameObject.SetActive(false);
                gameOverMessage.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                exitButton.gameObject.SetActive(true);
                StopAllCoroutines();
                state=State.sucess;
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

        public void ExitScene()
        {
            SceneManager.LoadScene(1);
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
            yield return new WaitForSeconds(1);
            //Time.timeScale = 0;
        }
        public enum State
        {
            sucess, fail
        }
    }
}


