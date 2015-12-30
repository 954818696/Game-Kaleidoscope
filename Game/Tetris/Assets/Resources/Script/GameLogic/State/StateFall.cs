using UnityEngine;
using System.Collections;
using InputCustom;

namespace GameLogic
{
    public class StateFall : State
    {
        public StateFall()
        {
            mStateName = StateNameSet.Fall;
        }

        public override void Enter(GameMode gameMode)
        {
            base.Enter(gameMode);
        }

        public override void Execute()
        {
            base.Execute();

            ESlideDirection direction = InputController.Instance.GetDirection();
            if (direction == ESlideDirection.E_Click)
            {
                mGameMode.mChessBoard.RotateBlock();
            }
            else if (direction == ESlideDirection.E_Left || direction == ESlideDirection.E_Right)
            {
                mGameMode.mChessBoard.HorizonMoveBlock(direction);
            }

            InputController.Instance.Reset();
            bool fallRlt = mGameMode.mChessBoard.FallBlock();
            mGameMode.mChessBoard.UpdateBoard();

            if (fallRlt)
            {
                StateMachine.Instance.ChangeState(new StateLand());
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

