using UnityEngine;
using System.Collections;

namespace InputCustom
{
    public class InputMouse : InputDevice
    {
        private Vector3 posStart, posEnd;

        public InputMouse()
        {
            deviceType = EInputDevice.E_Mouse;
        }
        public override void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                posStart = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                posEnd = Input.mousePosition;

                InputController.Instance.GetSlideDirection(posStart, posEnd);
            }
        }
    }
}

