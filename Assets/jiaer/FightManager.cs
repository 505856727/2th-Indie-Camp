using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour {
    public GameObject[] players;
    public GameObject angle;
    public static FightManager instance;
    public int[] blick;
    private void Start()
    {
        instance = this;
        StartCoroutine(Blick());
    }

    public static FightManager GetInstance()
    {
        return instance;
    }

    int FindMax()
    {
        int value = 0;
        for (int i = 0; i < players.Length - 1; i++)
        {
            if (blick[value] < blick[i + 1])
            {
                value = i + 1;
            }
        }
        return value;
    }

    IEnumerator Blick()
    {
        float time = Time.time;
        while (Time.time - time < 5)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                blick[0]++;
            }
            if (Input.GetKeyDown(KeyCode.Joystick2Button0))
            {
                blick[1]++;
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button0))
            {
                blick[2]++;
            }
            if (Input.GetKeyDown(KeyCode.Joystick3Button0))
            {
                blick[3]++;
            }
            yield return null;
        }
        ToAngle((FindMax()+1).ToString());
        for(int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<GhostControl>().canmove = true;
        }
    }

    public void ToAngle(string id)
    {
        angle.SetActive(true);
        angle.GetComponent<AngleControl>().id = id;
        players[int.Parse(id)-1].SetActive(false);
    }

    public void ToGhost(string id)
    {
        players[int.Parse(id) - 1].SetActive(true);
        angle.SetActive(false);        
    }
}
