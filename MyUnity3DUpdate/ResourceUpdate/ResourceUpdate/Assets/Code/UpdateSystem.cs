using UnityEngine;
using System.Collections;
using CommonTools;

// 资源更新总控

namespace UpdateModule
{
    public class UpdateStateNameSet
    {
        public const string stateCheckLocal = "CheckLocal";
        public const string stateDownloadRes = "DownloadRes";
        public const string stateUpdateLocalVersionInfo = "UpdateVersionInfo";
        public const string stateUpdateStateOver = "UpdateStageOver";

    }
    public class UpdateSystem : MonoBehaviour
    {

        private StateMachine mUpdateStateMachine;
	
	    void Start ()
        {
            mUpdateStateMachine = new StateMachine();
            mUpdateStateMachine.AddState(UpdateStateNameSet.stateCheckLocal, new StateCheckLocal(mUpdateStateMachine));
            mUpdateStateMachine.AddState(UpdateStateNameSet.stateDownloadRes, new StateDownloadRes(mUpdateStateMachine));
            mUpdateStateMachine.AddState(UpdateStateNameSet.stateUpdateLocalVersionInfo, new StateUpdateVersionInfo(mUpdateStateMachine));
            mUpdateStateMachine.AddState(UpdateStateNameSet.stateUpdateStateOver, new StateUpdateStageOver());

            mUpdateStateMachine.SetCurrentState(UpdateStateNameSet.stateCheckLocal);
	    }
	    void Update ()
        {
            mUpdateStateMachine.Update();
	    }
     }

}
