using UnityEngine;
using System.Collections;
using CommonTools;

public class StateCheckLocal : State
{
    private bool mbNeedUpdate = false;
    public StateCheckLocal(StateMachine stateMachine)
    {
        mStateMachine = stateMachine;
        mStateName = UpdateModule.UpdateStateNameSet.stateCheckLocal;
    }

    public override void Enter()
    {

    }

    public override void Execute()
    {
        LoadLocalVersionInfo();

        if (mbNeedUpdate)
        {
            mStateMachine.ChangeToState(UpdateModule.UpdateStateNameSet.stateDownloadRes);
        }
        else
        {
            mStateMachine.ChangeToState(UpdateModule.UpdateStateNameSet.stateUpdateStateOver);
        }
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void LoadLocalVersionInfo()
    {
        
    }
}
