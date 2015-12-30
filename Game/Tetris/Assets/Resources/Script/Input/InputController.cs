using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InputCustom
{
    public enum EInputDevice
    {
        E_None = 0, 
        E_KeyBoard = 1,
        E_Mouse    = 2,
        E_Touch    = 3,
    }

    public enum ESlideDirection
    {
        E_None  = 0, 
        E_Left  = 1,
        E_Right = 2,
        E_Up    = 3,
        E_Down  = 4,
        E_Click  = 5,
    }

    public class InputController : Singleton<InputController>
    {
        private List<InputDevice> mDevice = new  List<InputDevice>();
        private bool Enable = false;

        public InputController()
        {

        }

        public void SetInputDevice(List<EInputDevice> deviceList)
        {
            for (int i = 0; i < deviceList.Count; ++i)
            {
                if (deviceList[i] == EInputDevice.E_Mouse)
                {
                    mDevice.Add(new InputMouse());
                }
                else if (deviceList[i] == EInputDevice.E_KeyBoard)
                {
                    mDevice.Add(new InputKeyBoard());
                }
                else if (deviceList[i] == EInputDevice.E_Touch)
                {
                    mDevice.Add(new InputTouch());
                }
            }
        }

        public void Update()
        {
            for (int i = 0; i < mDevice.Count; ++i)
            {
                mDevice[i].Update();
            }
        }


        // Slide Direction Caculation.
        private ESlideDirection mDirection = ESlideDirection.E_None;
        public ESlideDirection GetDirection()
        {
            return mDirection;
        }

        public void Reset()
        {
            mDirection = ESlideDirection.E_None;
        }

        public void GetSlideDirection(Vector2 startPoint, Vector2 endPoint)
        {
            float xDiff = endPoint.x - startPoint.x;
            float yDiff = endPoint.y - startPoint.y;
            float slope = Mathf.Abs(yDiff / xDiff);
            ESlideDirection vdirection = ESlideDirection.E_None,
                                      hdirection = ESlideDirection.E_None;

            if (yDiff - GameConfig.Instance.SlideThreshold > 0)
            {
                vdirection = ESlideDirection.E_Up;
            }
            else if(yDiff + GameConfig.Instance.SlideThreshold < 0)
            {
                vdirection = ESlideDirection.E_Down;
            }

            if (xDiff - GameConfig.Instance.SlideThreshold > 0)
            {
                hdirection = ESlideDirection.E_Right;
            }
            else if(xDiff + GameConfig.Instance.SlideThreshold < 0)
            {
                hdirection = ESlideDirection.E_Left;
            }

            ESlideDirection finalDirection;
            if (slope > GameConfig.Instance.SlopeThreshold)
            {
                finalDirection = vdirection;
            }
            else
            {
                finalDirection = hdirection;
            }

            if (finalDirection == ESlideDirection.E_None)
            {
                finalDirection = ESlideDirection.E_Click;
            }
            LogDebug.Log(finalDirection.ToString());

            mDirection = finalDirection;
        }
    }

}
