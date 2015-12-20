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
            //Random.Range();
        }
        
        public override void Exit()
        {
            base.Exit();
        }
    }
}

