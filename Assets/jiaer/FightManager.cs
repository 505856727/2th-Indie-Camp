﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour {
    public GameObject[] players;
    public GameObject angle;
    public GameObject touch;
    public GameObject angleUI;
    public Text Tips;
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
            if (Input.GetKeyDown(KeyCode.Joystick4Button0))
            {
                blick[3]++;
            }
            yield return null;
        }
        ToAngle((FindMax()+1).ToString());
        GameMgr.instance.TurnToAngel((FindMax() + 1).ToString(), (FindMax() + 1).ToString());
        Destroy(touch);
        Tips.gameObject.SetActive(false);
        angleUI.SetActive(true);

        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<GhostControl>().canmove = true;
        }
    }

    public void ToAngle(string id)
    {
        angle.transform.position = players[int.Parse(id) - 1].transform.position;
        angle.SetActive(true);
        angle.GetComponent<AngleControl>().id = id;
        angle.GetComponent<AngleControl>().sprite.GetComponent<SpriteRenderer>().sprite = players[int.Parse(id) - 1].GetComponent<GhostControl>().sprite;
        players[int.Parse(id)-1].SetActive(false);
    }

    public void ToGhost(string id)
    {
        players[int.Parse(id) - 1].transform.position = angle.transform.position;
        players[int.Parse(id) - 1].SetActive(true);
        players[int.Parse(id) - 1].GetComponent<DemonHealth>().DieProcess();
        players[int.Parse(id) - 1].GetComponent<GhostControl>().isattack = false;
        angle.SetActive(false);   
    }
}
