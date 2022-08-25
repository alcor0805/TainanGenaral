using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alcor 
{
    public class CameraManager : MonoBehaviour
    {
        #region 資料
        #endregion
        #region 功能
        #endregion
        #region 事件
        #endregion
        public float downSpeed;
        private void FixedUpdate()
        {
            transform.Translate(0, -downSpeed * Time.deltaTime, 0);
        }

    }

}
