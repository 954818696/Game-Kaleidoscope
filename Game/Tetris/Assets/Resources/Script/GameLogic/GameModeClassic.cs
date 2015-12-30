using UnityEngine;
using System.Collections;

namespace GameLogic
{
    public class GameModeClassic : GameMode
    {
        public GameModeClassic()
        {
            mPreCountClock = 0;
            mGameModeType = EGameMode.E_Classic;
        }


        public override bool IsOver()
        {
            return mChessBoard.GetHeight() >= 10;
        }
    }

}
