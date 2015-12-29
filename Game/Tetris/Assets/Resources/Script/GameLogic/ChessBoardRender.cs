using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameLogic;

namespace Rendering
{
    public class ChessBoardRender : MonoSingleton<ChessBoardRender>
    {
        private bool[,] slotState;
        private List<GameObject> mActorCache = new List<GameObject>();
        private GameObject mBlockActor;

        public ChessBoardRender()
        {
            int width = GameConfig.Instance.Width;
            int height = GameConfig.Instance.Height;
            slotState = new bool[height, width];

            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    slotState[y, x] = false;
                }
            }

            mBlockActor = Resources.Load("Prefab/Block") as GameObject;
        }

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
                        if (slotState[y, x])
                            continue;

                        Vector3 pos = GetSlotPos(x, y);
                        Instantiate(mBlockActor, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
                        slotState[y, x] = true;
                        
                    }
                    else if (slotState[y, x])
                    {
                        //mActorCache.Add();
                    }
                }
            }
        }
    }
}

