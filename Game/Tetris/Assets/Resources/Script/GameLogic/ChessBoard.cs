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
        private List<BlockPos> stableBlockList = new List<BlockPos>();
        private List<int> reduceLines = new List<int>();
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
            mChessBoardRender.Rendering(curBlock.GetPointList(), stableBlockList);
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
            int offset = direction == ESlideDirection.E_Left ? -1 : 1;
            for (int i = 0; i < posList.Count; ++i)
            {
                posList[i].x += offset;
            }
            curBlock.GetAncholBlockPos().x += offset; 
            SetBoardSlotState(posList, true);
        }

        public bool FallBlock()
        {
            List<BlockPos> posList = curBlock.GetPointList();
            bool rlt = false ;
            stableBlockList.Clear();
            SetBoardSlotState(posList, false);
            if (CanVerticalFall(posList))
            {
                for (int i = 0; i < posList.Count; ++i)
                {
                    --posList[i].y;
                }

                curBlock.GetAncholBlockPos().y -= 1;
            }
            else
            {
                rlt = true;
                stableBlockList.AddRange(posList);
            }
			SetBoardSlotState(posList, true);

            return rlt;
        }

        public bool ReduceLine()
        {
            reduceLines.Clear();
            for (int y = 0; y < GameConfig.Instance.Height; ++y)
            {
                bool bCanReduce = true;
                for (int x = 0; x < GameConfig.Instance.Width; ++x)
                {
                    if (slotStateArray[y, x] == false)
                    {
                        bCanReduce = false;
                        break;
                    }
                }

                if (bCanReduce)
                {
                    reduceLines.Add(y);
                }
            }

            if (reduceLines.Count > 0)
            {
                for (int i = 0; i < reduceLines.Count; ++i)
                {
                    for (int y = reduceLines[i]; y < GameConfig.Instance.Height - 1; ++y)
                    {
                        for (int x = 0; x < GameConfig.Instance.Width; ++x)
                        {
                            slotStateArray[y, x] = slotStateArray[y + 1, x];
                        }
                        
                    }
                }

                stableBlockList.Clear();
                for (int y = 0; y < GameConfig.Instance.Height; ++y)
                {
                    for (int x = 0; x < GameConfig.Instance.Width; ++x)
                    {
                        if (slotStateArray[y, x])
                        {
                            stableBlockList.Add(new BlockPos(x, y));
                        }
                    }

                }
                return true;
            }

            return false;
        }

        public void UpdateReduce()
        {
            mChessBoardRender.RenderingForReduce(reduceLines);
        }

        public List<int> GetReduceLine()
        {
            return reduceLines;
        }

        private bool CanVerticalFall(List<BlockPos> posList)
        {
            for (int k = 0; k < posList.Count; ++k)
            {
                if (posList[k].y == 0)
                {
                    return false;
                }

				if (slotStateArray[posList[k].y - 1, posList[k].x])
                {
                    return false;
                }
            }

            return true;
        }

        public int GetHeight()
        {
            int maxHeight = 0;
            for (int y = 0; y <GameConfig.Instance.Height; ++y)
            {
                for (int x = 0; x < GameConfig.Instance.Width; ++x)
                {
                    if (slotStateArray[y, x] && y > maxHeight)
                    {
                        maxHeight = y;
                    }
                }
            }

            return maxHeight;
        }

    }
}


