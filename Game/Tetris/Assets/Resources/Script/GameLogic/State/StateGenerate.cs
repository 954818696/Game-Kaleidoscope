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

            if (mGameMode.IsOver())
            {
                StateMachine.Instance.ChangeState(new StateOver());
            }
            else
            {
                BlockBase newBlock = BlockFactory.GenerateBlock(4, 10);
                mGameMode.mChessBoard.SetCurFallBlock(newBlock);
                mGameMode.mChessBoard.UpdateBoard();
                StateMachine.Instance.ChangeState(new StateFall());
            }

        }
        
        public override void Exit()
        {
            base.Exit();
        }
    }
}

