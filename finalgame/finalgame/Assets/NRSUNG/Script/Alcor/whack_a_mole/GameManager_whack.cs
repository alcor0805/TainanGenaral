using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
namespace Alcor
{
    public class GameManager_whack : MonoBehaviour
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
            wolf_dead = false;
            InitScore();
            InitMonsterList();
            HideAllMonsters();
            //ShowRandomMonster();
            ResetShowMonsterSeconds();
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
            if(scoreNumber==100)
            {
                setting.SetActive(true);
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

        public void Main()
        {
            wolf_dead = true;
            SceneManager.LoadScene(0);
        }
        public void reload_wolf()
        {
            SceneManager.LoadScene(2);
        }





        #endregion
    }
}

