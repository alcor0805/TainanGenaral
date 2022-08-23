using UnityEngine;
namespace Alcor 
{
    public class person_walk : MonoBehaviour
    {
        #region 資料
        private Rigidbody2D circle;
        private Vector3 move;
        private Animator ani;
        private string varWalk = "走路";

        #endregion
        #region 功能
        
        private void OnDisable()
        {

            ani.SetBool(varWalk, false);
            
        }
        private void run() 
        {
            
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            move.Set(Mathf.Abs( h),0f,v);
            move = move.normalized * 6 * Time.deltaTime;
            if (move == Vector3.zero)
            {
                ani.SetBool(varWalk, false);
            }
            else
            {
                ani.SetBool(varWalk, true);
            }
            circle.MovePosition(circle.transform.position+move);
           
        }
        #endregion
        #region 事件
        private void Update()
        {
            run();
        }
    
        private void Awake()
        {
            circle = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }
        #endregion
    }
}

