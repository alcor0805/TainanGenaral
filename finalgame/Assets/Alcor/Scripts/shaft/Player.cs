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
        /*public float forceX;
        
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
            
            Vector2 newDirection = new(directionX, 0);
            playerRigidbody2D.AddForce(newDirection*forceX);
        }
    }*/
        private float Move;
        private Rigidbody2D rig;
        private float Speed = 3f;
        public static bool isDead;
        private void Start()
        {
            rig = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            Move = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(Move*Speed*Time.deltaTime,0, 0));
        }
    }
}

