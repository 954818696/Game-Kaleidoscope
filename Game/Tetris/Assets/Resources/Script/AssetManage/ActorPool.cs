using UnityEngine;
using System.Collections;

namespace AssetManage
{
    public class ActorSet
    {
        public const string Block = "Prefab/Block";
    }

    public class ActorPool : Singleton<ActorPool>
    {

        public ActorPool()
        {
            
        }
    }
}

