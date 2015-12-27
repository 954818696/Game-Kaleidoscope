using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameLogic
{
    public enum EBlockType
    {
        E_None = 0,
        E_Line = 1,
        E_Square = 2,
        E_Z = 3,
        E_Triangle = 4,
    }
    
    public enum EBlockRot
    {
        E_Up = 0,     // Default
        E_Right = 1,
        E_Down= 2,
        E_Left = 3,
    }

    public class BlockPos
    {
        public int x;
        public int y;

        public BlockPos(int a, int b)
        {
            x = a;
            y = b;
        }

    }

    public abstract class BlockBase
    {
        public EBlockType blockType = EBlockType.E_None;
        public EBlockRot  blockRot;

        protected List<BlockPos> generateList = new List<BlockPos>();
        protected BlockPos ancholBlock; 

        public List<BlockPos> GetPointList()
        {
            return generateList;
        }

        public abstract void RotBlock(EBlockRot rotType);
        public abstract void RotBlock();

        public abstract void GenerateBlock(int x, int y);
    }
}


