using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Alcor 
{
    public class person_walk : MonoBehaviour
    {
        #region 資料
        private Vector3 move;
        private Animator ani;
        private string varWalk = "走路";
        float MinX=-13, MaxX=160;
        private Elf_Move Elf;
        public float faceDirc;
        private TextMeshProUGUI text_tips;
        #endregion
        #region 功能

        private void OnDisable()
        {

            ani.SetBool(varWalk, false);
            
        }
        /// <summary>
        /// 人物行走與面向
        /// </summary>
       public void run() 
        {
            
            float h = Input.GetAxisRaw("Horizontal");
            faceDirc = Input.GetAxisRaw("Horizontal");
            move.Set(h,0,0);

            if (faceDirc != 0)
            {
                transform.localScale = new Vector3(faceDirc, 1, 1);
            }
            if (move == Vector3.zero)
            {
                ani.SetBool(varWalk, false);
            }
            else
            {
                ani.SetBool(varWalk, true);
            }
            transform.Translate(move * 10 * Time.deltaTime);
            
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), transform.position.y, transform.position.z);
            if (gameObject.transform.position.x <= MinX) text_tips.text = "已經到世界盡頭了喔!快回去吧";

           
        }
        #endregion
        #region 事件
        private void Update()
        {
            run();
        }
    
        private void Awake()
        {
            Elf = FindObjectOfType<Elf_Move>();
            ani = GetComponent<Animator>();
            text_tips = GameObject.Find("掉落物品提示").GetComponent<TextMeshProUGUI>();
        }
        #endregion
    }
}

