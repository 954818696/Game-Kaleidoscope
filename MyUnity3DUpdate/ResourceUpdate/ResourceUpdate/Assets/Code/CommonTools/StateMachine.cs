using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommonTools
{
    public class StateMachine
    {
        private State mCurrentState = null;
        private State mPrevState = null;
        

        private float Speed = 1;
        private float DeltaTime;

        private Dictionary<string, State> mDictState = new Dictionary<string, State>();
        public void AddState(string stateName, State state)
        {
            if (!mDictState.ContainsKey(stateName))
            {
                mDictState.Add(stateName, state);
            }
            else
            {
                mDictState[stateName] = state; 
            }
        }
            
        public StateMachine()
        {

        }

        public void Reset()
        {
            mCurrentState = null;
            mPrevState = null;

        }
        
        public void SetCurrentState(string stateName)
        {
            if (mDictState.ContainsKey(stateName))
            {
                mCurrentState = mDictState[stateName];
                mCurrentState.Enter();
            }
            else
            {
                UnityEngine.Debug.LogWarning("state " + stateName + "dosen't exist in SetCurrentState.");
            }
        }
        
        public State GetCurrentState()
        {
            return mCurrentState;
        }

        public void ChangeToState(string newState)
        {
            if (mDictState.ContainsKey(newState))
            {
                mPrevState = mCurrentState;
                mCurrentState.Exit();
                mCurrentState = mDictState[newState];
                mCurrentState.Enter();
            }
            else
            {
                UnityEngine.Debug.LogWarning("state " + newState + "dosen't exist in ChangeToState.");
            }
        }
        
        public bool IsInState(string stateName)
        {
            return mCurrentState.mStateName == stateName;
        }
        

        public void Update ()
        {
            if (Time.realtimeSinceStartup - DeltaTime < Speed)
            {
                return;
            }
            DeltaTime = Time.realtimeSinceStartup;

            if (mCurrentState != null)
            {
                mCurrentState.Execute();
            }
        }

        public void Stop()
        {
            mCurrentState = null;
        }
    }
}

