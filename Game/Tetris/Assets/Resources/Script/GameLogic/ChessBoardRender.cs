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

        public void Rendering(List<BlockPos> fallingBlock, List<BlockPos> stableBlock)
        {
            for (int i = 0; i < fallingBlock.Count; ++i)
            {
                Vector3 pos = GetSlotPos(fallingBlock[i].x, fallingBlock[i].y);
                mFallBlocks[i].transform.localPosition = new Vector3(pos.x, pos.y, 0);
            }

            for (int i = 0; i < stableBlock.Count; ++i)
            {
                int dictKey = CalKey(stableBlock[i].x, stableBlock[i].y);
                Vector3 pos = GetSlotPos(stableBlock[i].x, stableBlock[i].y);
                if (mSlotDict[dictKey] == null)
                {
                    GameObject InstActor = Instantiate(mBlockActor, pos, Quaternion.identity) as GameObject;
                    mSlotDict[dictKey] = InstActor;
                }
            }
        }

        public void RenderingForReduce(List<int> lines)
        {
            for (int i = 0; i < mFallBlocks.Count; ++i)
            {
                mFallBlocks[i].transform.localPosition = new Vector3(-100f, -100f, 0);
            }

            for (int i = 0; i < lines.Count; ++i)
            {
                    int y = lines[i];
                    for (int x = 0; x < GameConfig.Instance.Width; ++x)
                    {
                        int dictKey = CalKey(x, y);
                       
                        GameObject tmp =  mSlotDict[dictKey];
                        if (tmp != null)
                        {
                            tmp.SetActive(false);
                            Destroy(tmp);
                            mSlotDict[dictKey] = null;
                        }

                        int dictKeyCur = CalKey(x, y + 1);
                        if (mSlotDict[dictKeyCur] != null)
                        {
                            mSlotDict[dictKeyCur].transform.localPosition = GetSlotPos(x, y);
                            mSlotDict[dictKey] = mSlotDict[dictKeyCur];
                            mSlotDict[dictKeyCur] = null;
                        }
                    }
            }
        }

        private int CalKey(int x, int y)
        {
            return (x + 1 ) * 100 + y;
        }
    }
}

