using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {
    public static GameMgr instance;
    public float TimeToWin = 60;
    public Dictionary<string, WinJudge> playerList = new Dictionary<string, WinJudge>();
    public List<Slider> sliders = new List<Slider>(3);
    public WinJudge Current_WinJudge;
	// Use this for initialization
	void Start () {
        instance = this;
        for(int i = 1; i <= 4; i++)
        {
            WinJudge winJudge = new WinJudge(i.ToString());
            winJudge.sliderOrder = i - 1;
            playerList.Add(i.ToString(), winJudge);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Current_WinJudge!=null)
        {
            Current_WinJudge.accumulateTime += Time.deltaTime;
            //Current_WinJudge.WinSlider.value = Current_WinJudge.accumulateTime / TimeToWin * 100;
            sliders[Current_WinJudge.sliderOrder].value = Current_WinJudge.accumulateTime / TimeToWin * 100;
            if (Current_WinJudge.accumulateTime >= TimeToWin)
                Debug.Log("Win!");
        }
    }

    public void TurnToAngel(string killerID,string deathID)
    {
        //WinJudge killerWinJudge = playerList[killerID];
        //int temp = killerWinJudge.sliderOrder;
        //playerList[ID].sliderOrder = killerWinJudge.sliderOrder;
        Current_WinJudge = playerList[killerID];
    }
}
