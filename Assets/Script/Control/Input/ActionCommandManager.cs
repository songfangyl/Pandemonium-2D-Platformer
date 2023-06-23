using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Control 
{
   public class ActionCommandManager : ScriptableObject
   {
    [SerializeField] private List<ActionCommandPair> controlScheme;
   }
}