using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    public int BoardWidth = 10;
    public int BoardHeight = 20;

    public Transform mBlock;
    public Transform mLeftBottomPos;
    public float blockWidth;
    public float blockHeight;

	// Use this for initialization
	void Start () {
        testSetPos();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void testSetPos()
    {
        for (int y = 0; y < 20; ++y)
        {
            for (int x = 0; x < 10; ++x)
            {
                Instantiate(mBlock, new Vector3(mLeftBottomPos.localPosition.x + x * blockWidth, mLeftBottomPos.localPosition.y + y * blockHeight, 0), Quaternion.identity);
            }
        }
    }
}
