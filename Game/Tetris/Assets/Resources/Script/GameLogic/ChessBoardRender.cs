using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameLogic;

namespace Rendering
{
    public class ChessBoardRender : MonoSingleton<ChessBoardRender>
    {
        // 用于对象回收复用
        private Dictionary<int, GameObject> mSlotDict = new Dictionary<int, GameObject>();
        private List<GameObject> mCached = new List<GameObject>();

        private const int mFallBlocksNum = 4;
        private List<GameObject> mFallBlocks = new List<GameObject>();

        private GameObject mBlockActor;

        public ChessBoardRender()
        {
            mBlockActor = Resources.Load("Prefab/Block") as GameObject;

        }

        public void Awake()
        {
            for (int i = 0; i < mFallBlocksNum; ++i)
            {
                GameObject InstActor;
                InstActor = Instantiate(mBlockActor, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                mFallBlocks.Add(InstActor);
            }
            
            Reset();
        }

        public void Reset()
        {
            mSlotDict.Clear();
            int width = GameConfig.Instance.Width;
            int height = GameConfig.Instance.Height;
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    int dictKey = CalKey(x, y);
                    mSlotDict.Add(dictKey, null);
                }
            }

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
                    int dictKey = CalKey(x, y);
                    if (boardData.slotStateArray[y, x])
                    {
                        if (mSlotDict[dictKey] == null)
                        {
                            Vector3 pos = GetSlotPos(x, y);
                            GameObject mInstActor;
                            mInstActor = Instantiate(mBlockActor, new Vector3(pos.x, pos.y, 0), Quaternion.identity) as GameObject;
                            mSlotDict[dictKey] = mInstActor;
                        }
                        else if (mSlotDict[dictKey].activeSelf == false)
                        {
                            mSlotDict[dictKey].SetActive(true);
                        }
                    }
                    else
                    {
                        if (mSlotDict[dictKey] != null)
                        {
                            mSlotDict[dictKey].SetActive(false);
                        }
                    }
                }
            }
        }

        public void Rendering(List<BlockPos> fallingBlock)
        {
            for (int i = 0; i < mFallBlocksNum; ++i)
            {
                Vector3 pos = GetSlotPos(fallingBlock[i].x, fallingBlock[i].y);
                mFallBlocks[i].transform.localPosition = new Vector3(pos.x, pos.y, 0);
            }
        }

        private int CalKey(int x, int y)
        {
            return x * 100 + y;
        }
    }
}

