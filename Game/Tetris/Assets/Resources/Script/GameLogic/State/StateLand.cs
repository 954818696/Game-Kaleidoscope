using UnityEngine;
using System.Collections;

namespace GameLogic
{
    public class StateLand : State
    {
        public StateLand()
        {
            mStateName = StateNameSet.Generate;
        }


        public override void Execute()
        {
            base.Execute();

            if (mGameMode.mChessBoard.ReduceLine())
            {
                mGameMode.mChessBoard.UpdateReduce();
            }
            else
            {
                StateMachine.Instance.ChangeState(new StateGenerate());
            }
            
        }
    }

}
