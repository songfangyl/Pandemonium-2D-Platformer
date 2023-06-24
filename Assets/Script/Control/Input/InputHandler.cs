using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Control
{
    // to assign each key binding to some command 
    [System.Serializable]
    public class ActionCommandPair {
        public InputAction action;
        public BaseCommand command;

        public ActionCommandPair (InputAction action, BaseCommand command)
        {
            this.action = action;
            this.command = command;
        }
    }

    // handles the input-command behavior
    public class InputHandler : MonoBehaviour
    {
        
        List<ActionCommandPair> actionCommandList = new List<ActionCommandPair>();

        Dictionary<InputAction,BaseCommand> binding = new Dictionary<InputAction,BaseCommand>();
        Dictionary<BaseCommand, InputAction> reversed_binding = new Dictionary<BaseCommand, InputAction>();

        GameObject player;

        public static InputHandler inputHandler;

        
        public void UpdateActionCommandBindings()
        {
            binding.Clear();
            reversed_binding.Clear();

            foreach (var bind in actionCommandList) 
            {
                binding[bind.action] = bind.command;
                reversed_binding[bind.command] = bind.action;
                bind.action.Enable();
            }
        }

        public void UpdateActionCommandList(List<ActionCommandPair> list) 
        {
            this.actionCommandList = list;
        }

        void Awake() 
        {
            if (inputHandler == null) 
            {
                inputHandler = this;
                DontDestroyOnLoad(this);
            }
            else 
            {
                Destroy(this.gameObject);
            }
        }


        void onEnable() 
        {
            UpdateActionCommandBindings();
            Debug.Log("enabled");
        }

        void OnDisable() 
        {
            foreach (var bind in binding) 
            {
                bind.Key.Disable();
            }
        }

        void Start() {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        void Update() 
        {

            foreach (var action in binding) 
            {
                action.Value.Execute(action.Key, player);
            }
        }
    }
}

