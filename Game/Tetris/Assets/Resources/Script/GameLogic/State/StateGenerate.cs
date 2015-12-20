using UnityEngine;
using System.Collections;

namespace GameLogic
{
    public class StateGenerate : State
    {
        public StateGenerate()
        {
            mStateName = StateNameSet.Generate;
        }
        
        public override void Enter()
        {
            base.Enter();
        }
        
        public override void Execute()
        {
            base.Execute();
        }
        
        public override void Exit()
        {
            base.Exit();
        }
    }
}

