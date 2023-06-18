using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI.FSM
{
    public class BaseStateMachine : MonoBehaviour
    {
        [SerializeField] private BaseState  _initialState;
        public BaseState CurrentState { get; set; }
 
        private void Awake()
        {
            CurrentState = _initialState;
        }
 
        private void Start()
        {
            CurrentState.Enter(this);
        }
 
        private void Update()
        {
            CurrentState.Execute(this);
        }
    }
}     
