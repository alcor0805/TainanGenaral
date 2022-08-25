using UnityEngine;
namespace Alcor 
{
    public class person_walk : MonoBehaviour
    {
        #region ���
        private Rigidbody2D circle;
        private Vector3 move;
        private Animator ani;
        private string varWalk = "����";

        #endregion
        #region �\��
        
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
        #region �ƥ�
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

