using UnityEngine;
using System.Collections;

namespace GameLogic
{
    public class StateOver : State
    {

        public override void Execute()
        {
            LogDebug.Log("Game Over!");
            StateMachine.Instance.Stop();
        }
    }
}

