using UnityEngine;
using System.Collections;

namespace GameLogic
{
    public enum EChessBoardSlot
    {
        E_OutOfRange = 0,
        E_Empty      = 1,
        E_Full       = 2,
    }

    public class ChessBoard
    {
        private bool[,] slotStateArray;
        
        public ChessBoard()
        {
            int width  = GameConfig.Instance.Width;
            int height = GameConfig.Instance.Height;
            slotStateArray = new bool[height, width];
            
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    slotStateArray[y, x] = false;
                }
            }
        }
        
        public Vector3 GetSlotPos(int x, int y)
        {
            Vector3 pos = new Vector3(GameConfig.Instance.mLeftBottomPos.localPosition.x + x * GameConfig.Instance.blockWidth, 
                                      GameConfig.Instance.mLeftBottomPos.localPosition.y + y * GameConfig.Instance.blockHeight, 
                                      0);
            
            return pos;
        }
        
        public EChessBoardSlot GetSlotState(int x, int y)
        {
            if (x < 0 || x >= GameConfig.Instance.Width ||
                y < 0 || y >= GameConfig.Instance.Height)
            {
                return EChessBoardSlot.E_OutOfRange;
            }

            if (slotStateArray [y, x])
            {
                return EChessBoardSlot.E_Full;
            }
            else
            {
                return EChessBoardSlot.E_Empty;
            }
        }
    }
}


