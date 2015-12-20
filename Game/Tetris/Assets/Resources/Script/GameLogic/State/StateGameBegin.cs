using UnityEngine;
using System.Collections;

namespace GameLogic
{
    public class StateGameBegin : State
    {
        public bool mBCountOver = false;
        
        public StateGameBegin()
        {
            mStateName = StateNameSet.GameBegin;
        }
        
        public override void Enter()
        {
            base.Enter();
        }
        
        public override void Execute()
        {
            base.Execute();
            // 游戏开始倒计时等等
            // 倒计时结束
            mBCountOver = true;
            
            if (mBCountOver)
            {
                StateMachine.Instance.ChangeState(new StateGenerate());
            }
        }
        
        public override void Exit()
        {
            base.Exit();
            mBCountOver = false;
        }
    }
}


