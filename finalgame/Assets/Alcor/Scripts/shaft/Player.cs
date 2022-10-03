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
        public float faceDirc;
        private Vector3 move;
        private Animator ani;
        private string varWalk = "走路";
        private void Start()
        {
            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            run();
        }
        public void run()
        {

            float h = Input.GetAxisRaw("Horizontal");
            faceDirc = Input.GetAxisRaw("Horizontal");
            move.Set(h, 0, 0);

            if (faceDirc != 0)
            {
                transform.localScale = new Vector3(faceDirc*0.3f, transform.localScale.y, transform.localScale.z);
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

           

        }
    }
}

