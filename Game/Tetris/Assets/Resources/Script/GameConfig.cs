using UnityEngine;
using System.Collections;
using InputCustom;

public class GameConfig : MonoSingleton<GameConfig>
{
	public int Width  = 10;
	public int Height = 20;

    public float blockWidth;
    public float blockHeight;

    public Transform mBlockPrefab;
    public Transform mLeftBottomPos;


    // 滑动阈值
    public float SlideThreshold = 1f;
    public float SlopeThreshold = 2f;

    public EInputDevice InputDevice = EInputDevice.E_Touch;




}
