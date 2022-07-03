using UnityEngine;
namespace Alcor 
{
    public class person_walk : MonoBehaviour
    {
        #region 資料
        private Rigidbody2D circle;
        private Vector3 move;
        
        #endregion
        #region 功能
        private void run() 
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            move.Set(h,0f,v);
            move = move.normalized * 50 * Time.deltaTime;
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

