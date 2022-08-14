using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

namespace Alcor
{
    public class GameManager2 : MonoBehaviour
    {
        #region 資料
        private float showMonsterIntervalSeconds = 1;
        private float countDownShowMonsterSeconds;
        int MAX_MONSTERS_ON_SCREEN = 3;
        public List<monster> monsters;
        public static bool wolf_dead;
        public GameObject setting;
        private List<monster> HiddenMonsters
        {
            get
            {
                var result = new List<monster>();
                foreach (var m in monsters)
                {
                    if (!m.IsActive)
                    {
                        result.Add(m);

                    }
                }
                return result;
            }
        }
        public Text score;
        int scoreNumber = 0;
        [SerializeField, Header("標題文字")]
        private TextMeshProUGUI final_text;
        [SerializeField, Header("已過去時間文字")]
        private TextMeshProUGUI Time_text;
        private float Timing;
        public static wolfState wolfstate=wolfState.fail;
        #endregion
        #region 功能
        public void HideMonster(GameObject monster)
        {
            monster.SetActive(false);
        }
        private void InitScore()
        {

            score.text = "0";
        }
        public void AddScore()
        {
            scoreNumber += 10;
            score.text = scoreNumber.ToString();
        }
        private void HideAllMonsters()
        {
            foreach (var m in monsters)
            {
                HideMonster(m.gameObject);
            }
        }
        private void ShowMonster(GameObject monster)
        {
            monster.SetActive(true);
        }
        private void ShowRandomMonster()
        {
            int r = Random.Range(0, HiddenMonsters.Count);
            monster m = HiddenMonsters[r];
            ShowMonster(m.gameObject);
        }
        private void InitMonsterList()
        {
            monsters = GameObject.FindObjectsOfType<monster>().ToList();
        }
        #endregion
        #region 事件
        private void Start()
        {
            InvokeRepeating("CountTime", 1f, 1f);
            wolfstate = wolfState.fail;
            wolf_dead = false;
            InitScore();
            InitMonsterList();
            HideAllMonsters();
            ResetShowMonsterSeconds();
        }
        /// <summary>
        /// 計時器
        /// </summary>
        private void CountTime()
        {
            Timing += 1;
            Time_text.text = "已過去 "+Timing.ToString()+" 秒";
        }
        private void ResetShowMonsterSeconds()
        {
            countDownShowMonsterSeconds = showMonsterIntervalSeconds;
        }
        int MonsterCountOnScreen
        {
            get
            {
                int result = 0;
                foreach (var m in monsters)
                {
                    if (m.IsActive)
                    {
                        result += 1;
                    }
                }
                return result;
            }
        }
        private void FixedUpdate()
        {
            TryCountDownToShowMonster();
            if(scoreNumber==100||Timing>=20)
            {
                setting.SetActive(true);
                if (scoreNumber==100)
                {
                    wolfstate = wolfState.sucess;
                    final_text.text = "恭喜過關";
                }
                else
                {
                    wolfstate = wolfState.fail;
                    final_text.text = "失敗啦!再重來一次吧!";
                }
            }
        }
        bool CountDownShowMonsterTimeUp => countDownShowMonsterSeconds <= 0;
        bool MonstersOnScreenAreFull => MonsterCountOnScreen >= MAX_MONSTERS_ON_SCREEN;
        private void TryCountDownToShowMonster()
        {
            countDownShowMonsterSeconds -= Time.fixedDeltaTime;
            if (CountDownShowMonsterTimeUp)
            {
                ResetShowMonsterSeconds();
                if (! MonstersOnScreenAreFull)
                    ShowRandomMonster();
            }
        }


        public enum wolfState {sucess,fail }

        public void SetIsDead()
        {
          wolf_dead = true;
        }

        #endregion
    }
}

