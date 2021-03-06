﻿using UnityEngine;
using System.Collections;

namespace GameLogic
{
    public class State
    {
        public string mStateName = "null";
        public GameMode mGameMode;
        
        public virtual void Enter(GameMode gameMode)
        {
           // LogDebug.Log("Enter State :" + mStateName.ToString());
            mGameMode = gameMode;
        }
        
        public virtual void Execute()
        {
           // LogDebug.Log("Excute State :" + mStateName.ToString());
        }
        
        public virtual void Exit()
        {
          //  LogDebug.Log("Exit State :" + mStateName.ToString());
        }
    }
}


