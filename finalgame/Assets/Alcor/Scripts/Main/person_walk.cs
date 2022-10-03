using UnityEngine;
using UnityEngine.UIElements;

namespace Alcor 
{
    public class person_walk : MonoBehaviour
    {
        #region ���
        private Vector3 move;
        private Animator ani;
        private string varWalk = "����";
        float MinX=-13, MaxX=111;
        private Elf_Move Elf;
        public float faceDirc;
       
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
            faceDirc = Input.GetAxisRaw("Horizontal");
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
            ani = GetComponent<Animator>();
        }
        #endregion
    }
}

