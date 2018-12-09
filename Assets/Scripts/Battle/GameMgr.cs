using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour {
    public static GameMgr instance;
    public float TimeToWin = 60;
    public Dictionary<string, WinJudge> playerList = new Dictionary<string, WinJudge>();
    public List<Slider> sliders = new List<Slider>(3);

    //动态替换头像
    public List<Image> Avatars = new List<Image>(4);
    public List<Sprite> OriginAvatars = new List<Sprite>(4);
    public Sprite AngelAvatar;

    public WinJudge Current_WinJudge;
    public Text WinText;

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
            {
                AudioManager.GetInstance().PlayMusic(2);
                WinText.gameObject.SetActive(true);
                WinText.text = "Player" + Current_WinJudge.playerID + "Win!";
                Invoke("ReturnToMenu", 5.0f);
            }
        }
    }

    public void TurnToAngel(string killerID,string deathID)
    {
        //WinJudge killerWinJudge = playerList[killerID];
        //int temp = killerWinJudge.sliderOrder;
        //playerList[ID].sliderOrder = killerWinJudge.sliderOrder;
        Debug.Log(int.Parse(deathID) - 1);
        Avatars[int.Parse(deathID) - 1].sprite = OriginAvatars[int.Parse(deathID) - 1];
        Current_WinJudge = playerList[killerID];
        Avatars[Current_WinJudge.sliderOrder].sprite = AngelAvatar;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
