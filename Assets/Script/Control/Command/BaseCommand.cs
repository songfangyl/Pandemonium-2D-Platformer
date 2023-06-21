using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Control 
{

 public abstract class BaseCommand : ScriptableObject
{
    public abstract void Execute(InputAction action, GameObject player);

}   


}

