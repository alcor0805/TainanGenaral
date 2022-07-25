using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alcor
{
    public class Player : MonoBehaviour
    {
        #region 資料
        #endregion
        #region 功能
        #endregion
        #region 事件
        #endregion
        public float forceX;
        public static bool isDead;
        Rigidbody2D playerRigidbody2D;
        readonly float toLeft = -1;
        readonly float toRight = 1;
        readonly float stop = 0;
        float directionX;
        private void Start()
        {
            playerRigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                directionX = toLeft;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                directionX = toRight;
            }
            else
            {
                directionX = stop;
            }
            Vector2 newDirection = new(directionX, 0);
            playerRigidbody2D.AddForce(newDirection*forceX);
        }
    }
}

