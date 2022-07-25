using UnityEngine;
namespace Alcor 
{
    public class person_walk : MonoBehaviour
    {
        #region ���
        private Rigidbody2D circle;
        private Vector3 move;

        #endregion
        #region �\��
        private void OnDisable()
        {
            circle.MovePosition(circle.transform.position);
            circle.velocity = Vector3.zero;
        }
        private void run() 
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            move.Set(h,0f,v);
            move = move.normalized * 10 * Time.deltaTime;
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
        }
        #endregion
    }
}

