﻿using UnityEngine;
using System.Collections;

namespace CommonTools
{
    public class State
    {

        public string mStateName = "null";

        protected StateMachine mStateMachine = null;

        public virtual void Enter()
        {
             LogDebug.Log("Enter State :" + mStateName.ToString());
    
        }

        public virtual void Execute()
        {
             LogDebug.Log("Excute State :" + mStateName.ToString());
        }

        public virtual void Exit()
        {
              LogDebug.Log("Exit State :" + mStateName.ToString());
        }

    }

}
