using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Alcor 
{
    public class Elf_Move : MonoBehaviour
    {
        private int distance=20;
        public GameObject MainRole;
        public List<Vector3> position;
        private person_walk walk;
        public DialogSystem elf_dialog;
        private void Awake()
        {
            walk = MainRole.GetComponent<person_walk>();
        }

        private void Update()
        {
           
                TrackPlayer();
           
            
        }
            
        
        private void TrackPlayer()
        {
            if (walk.faceDirc != 0)
            {
                transform.localScale = new Vector3(walk.faceDirc*0.1f, 0.1f, 0.1f);
                switch (walk.faceDirc)
                {
                    case > 0:
                        position.Add(new Vector3(MainRole.transform.position.x - 3, transform.position.y, transform.position.z));
                        break;
                    case < 0:
                        position.Add(new Vector3(MainRole.transform.position.x + 3, transform.position.y, transform.position.z));
                        break;
                }
            }
            
            
            if (position.Count > distance)
            {
                position.RemoveAt(0);
                transform.position = position[0];
            }
        }
        

    }
}

