using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control 
{        
    [CreateAssetMenu(menuName = "Control/ActionCommandScheme")]
    public class ActionCommandScheme : ScriptableObject 
    {
        public List<ActionCommandPair> actionCommandList;
    }
}
