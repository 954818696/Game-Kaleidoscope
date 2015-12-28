using UnityEngine;
using System.Collections;


namespace GameLogic
{
    public class BlockTriangle : BlockBase
    {

        private int[,] blockMapPos;

        public BlockTriangle(int x, int y, EBlockRot rotType = EBlockRot.E_Up)
        {
            blockType = EBlockType.E_Triangle;
            blockMapPos = new int[4, 2] { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };

            GenerateBlock(x, y);
            RotBlock(rotType);
        }

        public override void GenerateBlock(int x, int y)
        {
            blockRot = EBlockRot.E_Up;

            // Anchol Block.
            ancholBlock = new BlockPos(x, y - 1);

            // Block List.
            generateList.Add(new BlockPos(x, y - 1));

            generateList.Add(new BlockPos(x - 1, y - 1));
            generateList.Add(new BlockPos(x, y));
            generateList.Add(new BlockPos(x + 1, y - 1));
        }

        public override void RotBlock(EBlockRot rotType)
        {
            if (rotType == blockRot)
            {
                return ;
            }
            else
            {
                for (int i = 1; i < generateList.Count; ++i)
                {
                    int iOffest = (i - 1 + (int)rotType) % (int)EBlockRot.E_Max;
                    generateList[i].x = blockMapPos[iOffest, 0] + ancholBlock.x;
                    generateList[i].y = blockMapPos[iOffest, 1] + ancholBlock.y;
                }
            }


            blockRot = rotType;
        }

        public override void RotBlock()
        {
            int targetRot = (int)blockRot + 1;
            targetRot = targetRot < (int)EBlockRot.E_Max ? targetRot : targetRot % (int)EBlockRot.E_Max;
            RotBlock((EBlockRot)targetRot);
        }
    }
}


