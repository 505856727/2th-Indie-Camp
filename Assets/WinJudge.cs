using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinJudge : MonoBehaviour {
    public Slider WinSlider;
    
    public bool isAngle = false;
    public float TimeToWin = 60;
    private float accumulateTime = 0;//累积时间
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isAngle)
        {
            accumulateTime += Time.deltaTime;
            WinSlider.value = accumulateTime / TimeToWin *100;
            if (accumulateTime >= TimeToWin)
                Debug.Log("Win!");
        }
	}
}
