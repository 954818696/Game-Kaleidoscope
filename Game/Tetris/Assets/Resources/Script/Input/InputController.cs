using UnityEngine;
using System.Collections;

namespace InputCustom
{
    public enum EInputDevice
    {
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
    }

    public class InputController : Singleton<InputController>
    {
        private InputDevice mDevice;

        public InputController()
        {

        }

        public void SetInputDevice()
        {

        }


        public ESlideDirection GetSlideDirection(Vector2 startPoint, Vector2 endPoint)
        {
            float xDiff = endPoint.x - startPoint.x;
            float yDiff = endPoint.y - startPoint.y;
            float slope = Mathf.Abs(yDiff / xDiff);
            ESlideDirection vdirection = ESlideDirection.E_None,
                            hdirection = ESlideDirection.E_None;

            if (yDiff - GameConfig.SlideThreshold > 0)
            {
                vdirection = ESlideDirection.E_Up;
            }
            else if(yDiff + GameConfig.SlideThreshold < 0)
            {
                vdirection = ESlideDirection.E_Down;
            }

            if (xDiff - GameConfig.SlideThreshold > 0)
            {
                hdirection = ESlideDirection.E_Right;
            }
            else if(xDiff + GameConfig.SlideThreshold < 0)
            {
                hdirection = ESlideDirection.E_Left;
            }

            ESlideDirection finalDirection = ESlideDirection.E_None;
            if (slope > GameConfig.SlopeThreshold)
            {
                finalDirection = vdirection;
            }
            else
            {
                finalDirection = hdirection;
            }

            LogDebug.Log(finalDirection.ToString());

            return finalDirection;
        }
    }

}
