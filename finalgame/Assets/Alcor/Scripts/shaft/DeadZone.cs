using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alcor 
{
    public class DeadZone : MonoBehaviour
    {
        #region 資料
        #endregion
        #region 功能
        #endregion
        #region 事件
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Player.isDead = true;
                //Debug.Break();
            }
        }
        #endregion
    }
}

