using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Alcor 
{
    public class DeadZone : MonoBehaviour
    {
        #region ���
        #endregion
        #region �\��
        #endregion
        #region �ƥ�
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

