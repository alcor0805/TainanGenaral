using UnityEngine;
using UnityEngine.UIElements;

namespace Alcor 
{
    public class person_walk : MonoBehaviour
    {
        #region ���
        private Rigidbody2D person;
        private Vector3 move;
        private Animator ani;
        private string varWalk = "����";
        private int distance = 10;
        float MinX=-10, MaxX=66;
        private Elf_Move Elf;
        #endregion
        #region �\��
        
        private void OnDisable()
        {

            ani.SetBool(varWalk, false);
            
        }
        /// <summary>
        /// �H���樫�P���V
        /// </summary>
       public void run() 
        {
            
            float h = Input.GetAxisRaw("Horizontal");
            float faceDirc = Input.GetAxisRaw("Horizontal");
            move.Set(h,0,0);

            if (faceDirc != 0)
            {
                transform.localScale = new Vector3(faceDirc, 1, 1);
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
            
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), transform.position.y, transform.position.z);
           
        }
        #endregion
        #region �ƥ�
        private void Update()
        {
            run();
        }
    
        private void Awake()
        {
            Elf = FindObjectOfType<Elf_Move>();
            person = GetComponent<Rigidbody2D>();
            ani = GetComponent<Animator>();
        }
        #endregion
    }
}

