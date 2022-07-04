using UnityEngine;
namespace Alcor 
{
    public class person_walk : MonoBehaviour
    {
        #region 資料
        private Rigidbody2D circle;
        private Vector3 move;
<<<<<<< Updated upstream
        
        #endregion
        #region 功能
=======

        #endregion
        #region 功能
        private void OnDisable()
        {
            circle.MovePosition(circle.transform.position);
            circle.velocity = Vector3.zero;
        }
>>>>>>> Stashed changes
        private void run() 
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            move.Set(h,0f,v);
<<<<<<< Updated upstream
            move = move.normalized * 50 * Time.deltaTime;
=======
            move = move.normalized * 10 * Time.deltaTime;
>>>>>>> Stashed changes
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
        }
        #endregion
    }
}

