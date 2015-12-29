using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rendering;

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
        public bool[,]         slotStateArray;
        private BlockBase curBlock;
        private ChessBoardRender mChessBoardRender;
        
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

        public void SetCurFallBlock(BlockBase newBlock)
        {
            curBlock = newBlock;
            SetBoardSlotState(curBlock.GetPointList());
        }

        public void SetBoardSlotState(List<BlockPos> posList)
        {
            for (int i = 0; i < posList.Count; ++i)
            {
                slotStateArray[posList[i].y, posList[i].x] = true;
            }
        }

        public void UpdateBoard()
        {

            mChessBoardRender.Rendering(this);
        }
    }
}


