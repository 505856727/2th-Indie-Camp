using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinJudge
{
    public string playerID;
    public float accumulateTime = 0;//累积时间
    public int sliderOrder = 0;
    public WinJudge(string id)
    {
        playerID = id;
    }
}
