using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rendering;
using InputCustom;

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
        private List<BlockPos> stableBlock;
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

            mChessBoardRender = ChessBoardRender.Instance;
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
            SetBoardSlotState(curBlock.GetPointList(), true);
        }

        public void SetBoardSlotState(List<BlockPos> posList, bool isOccupy)
        {
            bool value = isOccupy ? true : false;
            for (int i = 0; i < posList.Count; ++i)
            {
                slotStateArray[posList[i].y, posList[i].x] = value;
            }
        }

        public void UpdateBoard()
        {

            mChessBoardRender.Rendering(curBlock.GetPointList());
        }

        public void RotateBlock()
        {
            SetBoardSlotState(curBlock.GetPointList(), false);
            curBlock.RotBlock();
            SetBoardSlotState(curBlock.GetPointList(), true);

            LogDebug.Log("RotateBlock");
        }

        public void HorizonMoveBlock(ESlideDirection direction)
        {
            List<BlockPos> posList = curBlock.GetPointList();
            SetBoardSlotState(posList, false);
            for (int i = 0; i < posList.Count; ++i)
            {
                posList[i].x = direction == ESlideDirection.E_Left ? posList[i].x - 1 : posList[i].x + 1;
            }
            SetBoardSlotState(posList, true);
        }

        public bool FallBlock()
        {
            List<BlockPos> posList = curBlock.GetPointList();
            SetBoardSlotState(posList, false);
            bool rlt = false ;
            for (int i = 0; i < posList.Count; ++i)
            {
                --posList[i].y;
                if (posList[i].y < 0)
                {
                    posList[i].y = 0;
                    rlt = true;
                    break;
                }
            }

            SetBoardSlotState(posList, true);

            return rlt;
        }
    }
}


