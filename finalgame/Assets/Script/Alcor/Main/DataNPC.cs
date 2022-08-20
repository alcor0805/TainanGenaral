using System.Collections.Generic;
using UnityEngine;
namespace Alcor 
{
    [CreateAssetMenu(menuName = "Alcor/Data NPC", fileName = "DataNPC")]
    [System.Serializable]
    public class DataNPC : ScriptableObject
    {
        public int ID;
        public int IndexPart = 0;
        [NonReorderable]
        public List<Dialog_chapter> eachChapter;
    
        
    }
    
}

