using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinJudge
{
    public string playerID;
    public Slider WinSlider;
    public float accumulateTime = 0;//累积时间
    public WinJudge(string id,Slider _slider)
    {
        playerID = id;
        WinSlider = _slider;
    }
}
