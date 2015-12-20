using UnityEngine;
using System.Collections;
using InputCustom;

public class GameConfig : Singleton<GameConfig>
{
	public const int   BlockWidth  = 50;
	public const int   BlockHeight = 50;

    // 滑动阈值
    public const float SlideThreshold = 1f;
    public const float SlopeThreshold = 2f;

    public EInputDevice InputDevice = EInputDevice.E_Touch;


}
