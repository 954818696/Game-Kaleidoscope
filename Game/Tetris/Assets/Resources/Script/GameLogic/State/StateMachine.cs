using UnityEngine;
using System.Collections;

namespace GameLogic
{
    public class StateNameSet
    {
        public const string GameBegin = "GameBegin";
        public const string GameOver = "GameOver";
        public const string Pause = "Pause";
        public const string Generate = "Generate";
        public const string Fall = "Fall";
        public const string Land = "Land";
        
        
    }
    
    // 用于游戏全局状态总控的状态机
    public class StateMachine : MonoSingleton<StateMachine>
    {
        private State mCurrentState = null;
        private State mPrevState = null;
        
        private GameMode mGameMode = null;
            
        public StateMachine()
        {

        }

        public void Awake()
        {
            mGameMode = new GameModeClassic();
        }

        public void Reset()
        {
            mCurrentState = null;
            mPrevState = null;
            mGameMode = null;
        }
        
        // 初始化状态机方法
        public void SetCurrentState(State tState)
        {
            mCurrentState = tState;
        }
        
        public void SetPrevState(State tState)
        {
            mPrevState = tState;
        }
        
        // 就是喜欢c++写法，任性
        public State GetCurrentState()
        {
            return mCurrentState;
        }
        
        public State GetPrevState()
        {
            return mPrevState;
        }
        
        // 状态变更触发
        public void ChangeState(State newState)
        {
            if (newState == null)
            {
                return ;
            }
            
            mPrevState = mCurrentState;
            mCurrentState.Exit();
            mCurrentState = newState;
            mCurrentState.Enter();
        }
        
        // 回滚到上一个状态
        public void RevertToPrevState()
        {
            ChangeState(mPrevState);
        }
        
        public bool IsInState(string stateName)
        {
            return mCurrentState.mStateName == stateName;
        }
        
        // Use this for initialization
        void Start ()
        {
            
        }
        
        // Update is called once per frame
        void Update ()
        {
            // TouchPhase.
            if (mCurrentState != null)
            {
                mCurrentState.Execute();
            }
        }
    }
}


