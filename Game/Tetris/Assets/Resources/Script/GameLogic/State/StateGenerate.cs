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

        public override void Enter(GameMode gameMode)
        {
            base.Enter(gameMode);
        }



        public override void Execute()
        {
            base.Execute();
            EBlockType blockType = (EBlockType)Random.Range((int)EBlockType.E_Line, (int)EBlockType.E_Triangle);
            EBlockRot rotType = (EBlockRot)Random.Range(1, 4);

            switch (blockType)
            {
                case EBlockType.E_Line:
                    ;
                    break;
                case EBlockType.E_Square:
                    ;
                    break;
                case EBlockType.E_Triangle:
                    ;
                    break;
                case EBlockType.E_Z:;
                    break;

            }


        }
        
        public override void Exit()
        {
            base.Exit();
        }
    }
}

