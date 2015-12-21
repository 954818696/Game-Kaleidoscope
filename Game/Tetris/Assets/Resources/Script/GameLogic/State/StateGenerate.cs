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

        enum EBlockType
        {
            E_Line = 1,
            E_Square = 2,
            E_Z = 3,
            E_Triangle = 4,
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

