using UnityEngine;
using System.Collections;
using GameLogic;

namespace Rendering
{
    public class ChessBoardRender
    {

        private  Vector3 GetSlotPos(int x, int y)
        {
            Vector3 pos = new Vector3(GameConfig.Instance.mLeftBottomPos.localPosition.x + x * GameConfig.Instance.blockWidth,
                                      GameConfig.Instance.mLeftBottomPos.localPosition.y + y * GameConfig.Instance.blockHeight,
                                      0);

            return pos;
        }

        public void Rendering(ChessBoard boardData)
        {
            int width = GameConfig.Instance.Width;
            int height = GameConfig.Instance.Height;


            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    if (boardData.slotStateArray[y, x])
                    {
                        Vector3 pos = GetSlotPos(x, y);

                    }
                    else
                    {
 
                    }
                }
            }
        }
    }
}

