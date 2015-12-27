using UnityEngine;
using System.Collections;


namespace GameLogic
{
    public class BlockTriangle : BlockBase
    {

        private int[] blockMapPos = new int[4];

        public BlockTriangle(int x, int y, EBlockRot rotType = EBlockRot.E_Up)
        {
            blockType = EBlockType.E_Triangle;




            GenerateBlock(x, y);
            RotBlock(rotType);
        }

        public override void GenerateBlock(int x, int y)
        {
            // Anchol Block.
            ancholBlock = new BlockPos(x, y - 1);

            // Other Blocks.
            generateList.Add(new BlockPos(x, y - 1));
            
            generateList.Add(new BlockPos(x, y));
            generateList.Add(new BlockPos(x - 1, y - 1));
            generateList.Add(new BlockPos(x + 1, y - 1));
           
        }

        public override void RotBlock(EBlockRot rotType)
        {
            if (blockRot == rotType)
            {
                return;
            }

            // Anchol offset consult.
            // pre left.

            generateList[0].x = ancholBlock.x;
            generateList[0].y = ancholBlock.y;


            blockRot = rotType;
        }

        public override void RotBlock()
        {
            
        }
    }
}


