using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public bool EnableLog = true;

    // 操作输入, 同时支持多个输入设备
    public List<EInputDevice> InputDeviceList = new List<EInputDevice>();

    void Start()
    {
        LogDebug.EnableLog = EnableLog;

        InputController.Instance.SetInputDevice(InputDeviceList);
    }

}
