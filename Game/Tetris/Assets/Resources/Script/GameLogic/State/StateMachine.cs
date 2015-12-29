using UnityEngine;
using System.Collections;
using InputCustom;

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

        private float Speed;
        private float DeltaTime;
            
        public StateMachine()
        {

        }

        public void Awake()
        {
            mGameMode = new GameModeClassic();
            Speed = GameConfig.Instance.GameSpeed;
            DeltaTime = Time.realtimeSinceStartup;
        }

        public void Start()
        {
            SetCurrentState(new StateGenerate());
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
            mCurrentState.Enter(mGameMode);
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
            mCurrentState.Enter(mGameMode);
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
        
        // Update is called once per frame
        void Update ()
        {
            if (Time.realtimeSinceStartup - DeltaTime < Speed)
            {
                return;
            }
            DeltaTime = Time.realtimeSinceStartup;

            InputController.Instance.Update();

            if (mCurrentState != null)
            {
                mCurrentState.Execute();
            }


            // Render. unity ，Unreal无需此次调用
            // 自己实现的Render需在此将游戏逻辑转化为图形输出。
        }
    }
}


