using UnityEngine;
using System.Collections;


namespace GameLogic
{
    public class BlockTriangle : BlockBase
    { 
        public BlockTriangle(EBlockRot rotType, int x, int y)
        {
            blockType = EBlockType.E_Triangle;
            blockRot = rotType;

            GenerateBlock(x, y);
            RotBlock();
        }

        public override void GenerateBlock(int x, int y)
        {

        }

        public override void RotBlock()
        {

        }
    }
}


