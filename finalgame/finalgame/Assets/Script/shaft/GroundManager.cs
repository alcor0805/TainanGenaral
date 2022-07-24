using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Alcor
{
    public class GroundManager : MonoBehaviour
    {
        #region 資料
        #endregion
        #region 功能
        #endregion
        #region 事件
        public List<Transform> grounds;
        readonly float leftBorder = -3;
        readonly float rightBorder = 3;
        readonly float initPosotionY = 0;
        readonly int MIN_GROUND_COUNT_UNDER_PLAYER = 3;
        [Range(2, 6)] public float spacingY;
        [Range(1, 20)] public float singleFloorHeight;
        readonly int MAX_GROUND_COUNT = 10;
        static int groundNumber = -1;
        public Transform player;
        public Text displayCountFloor;
        private void Start()
        {
            grounds = new List<Transform>();
            for (int i = 0; i < MAX_GROUND_COUNT; i++)
            {
                SpawGround();
            }

        }
        private void Update()
        {
            ControlSpawnGround();
            DisplayCountFloor();
        }
        public void ControlSpawnGround() 
        {
            int groundsCounterUnderPlayer = 0;
            foreach (Transform ground in grounds)
            {
                if (ground.position.y < player.transform.position.y)
                {
                    groundsCounterUnderPlayer++;
                }
                
            }
            if (groundsCounterUnderPlayer < MIN_GROUND_COUNT_UNDER_PLAYER)
            {
                SpawGround();
                ControlGroundCount();
            }

        }
        public void ControlGroundCount() 
        {
            if (grounds.Count > MAX_GROUND_COUNT)
            {
                Destroy(grounds[0].gameObject);
                grounds.RemoveAt(0);
            }
            
        }
        private void SpawGround()
        {
            GameObject newGround = Instantiate(Resources.Load<GameObject>("floor"));
            newGround.transform.position = new Vector3(NewGroundPositionX(), NewGroundPositionY(), 0);
            grounds.Add(newGround.transform);
            groundNumber++;
            newGround.name = "地板" + groundNumber;
        }
        float CountLowerGroundFloor() 
        {
            float playerPositionY = player.transform.position.y;
            float deep = Mathf.Abs(initPosotionY - playerPositionY);
            return (deep / singleFloorHeight) + 1;
        }

        void DisplayCountFloor() 
        {
            displayCountFloor.text = "地下" + CountLowerGroundFloor().ToString() ;
        }
        float NewGroundPositionX ()
        {
            if (grounds.Count == 0)
            {
                return 0;
            }

            return Random.Range(leftBorder, rightBorder);
        }
        float NewGroundPositionY() 
        {
            if (grounds.Count == 0)
            {
                return initPosotionY;
            }
            int lowerIndex = grounds.Count - 1;
            return grounds[lowerIndex].transform.position.y - spacingY;
        }
        #endregion
    }
}

