using UnityEngine;
using System.Collections;

namespace InputCustom
{
    public abstract class InputDevice 
    {
        public EInputDevice deviceType = EInputDevice.E_None;

        public abstract void Update();
    }

}
