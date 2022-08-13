using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Alcor 
{[System.Serializable]
    public class Dialog_eachPart_sentence 
    {
        [NonReorderable]
        public string speaker;
        [NonReorderable]
        public List<string> sentence;
    }
}

