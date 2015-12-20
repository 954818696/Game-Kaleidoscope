using UnityEngine;
using System.Collections;

namespace GameLogic
{
    public enum EGameMode
    {
        E_Classic = 1,
    }

    public abstract class GameMode
    {
        protected int mPreCountClock;
        protected EGameMode mGameModeType;
    }


}


