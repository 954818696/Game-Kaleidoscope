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
        E_None = 0,
        E_Up = 1,
        E_Right = 2,
        E_Down = 3,
        E_Left = 4,
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
        public EBlockRot  blockRot = EBlockRot.E_None;

        protected List<BlockPos> generateList = new List<BlockPos>();

        public List<BlockPos> GetPointList()
        {
            return generateList;
        }

        public virtual void RotBlock()
        {

        }

        public virtual void GenerateBlock(int x, int y)
        {

        }


    }
}


