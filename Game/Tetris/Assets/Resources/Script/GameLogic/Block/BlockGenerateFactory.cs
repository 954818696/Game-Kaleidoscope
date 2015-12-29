using UnityEngine;
using System.Collections;

namespace GameLogic
{
    public class BlockFactory
    {
        public static BlockBase GenerateBlock(int x, int y)
        {
           // EBlockType blockType = (EBlockType)Random.Range((int)EBlockType.E_Line, (int)EBlockType.E_Triangle);
            EBlockRot   rotType = (EBlockRot)Random.Range(1, 4);
            EBlockType blockType = EBlockType.E_Triangle;
           
            switch (blockType)
            {
                case EBlockType.E_Line:
                    return new BlockLine(x, y);
                case EBlockType.E_Square:
                    return new BlockSquare(x, y);
                case EBlockType.E_Triangle:
                    return new BlockTriangle(x, y, rotType);
                case EBlockType.E_Z: ;
                    return new BlockZ(x, y);
            }

            return null;
        }
    }
}

