using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alcor 
{
    public class CameraManager : MonoBehaviour
    {
        #region ���
        #endregion
        #region �\��
        #endregion
        #region �ƥ�
        #endregion
        public float downSpeed;
        private void FixedUpdate()
        {
            transform.Translate(0, -downSpeed * Time.deltaTime, 0);
        }

    }

}
