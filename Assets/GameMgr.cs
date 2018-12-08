using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {
    public float TimeToWin = 60;
    public Dictionary<string, WinJudge> playerList = new Dictionary<string, WinJudge>();
    public List<Slider> sliders;
    public WinJudge Current_WinJudge;
	// Use this for initialization
	void Start () {
        for(int i = 1; i <= 4; i++)
        {
            playerList.Add(i.ToString(), new WinJudge(i.ToString(),sliders[i]));
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Current_WinJudge!=null)
        {
            Current_WinJudge.accumulateTime += Time.deltaTime;
            Current_WinJudge.WinSlider.value = Current_WinJudge.accumulateTime / TimeToWin * 100;
            if (Current_WinJudge.accumulateTime >= TimeToWin)
                Debug.Log("Win!");
        }
    }

    public void TurnToAngel(string id)
    {
        Current_WinJudge = playerList[id];
    }
}
