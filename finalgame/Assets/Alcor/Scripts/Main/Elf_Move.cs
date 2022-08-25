using System.Collections.Generic;
using UnityEngine;

namespace Alcor 
{
    public class Elf_Move : MonoBehaviour
    {
        private int distance;
        public GameObject MainRole;
        public List<Vector3> position;
        private void Update()
        {
            
            TrackPlayer();
        }
        private void TrackPlayer()
        {
            position.Add(MainRole.transform.position);
            if (position.Count > distance)
            {
                position.RemoveAt(0);
                transform.position = position[0];
            }
        }
        

    }
}

