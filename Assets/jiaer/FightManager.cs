using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour {
    public GameObject[] players;
    public GameObject angle;
    public int[] blick;
    private void Start()
    {
        StartCoroutine(Blick());
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
            yield return null;
        }
        ToAngle((FindMax()+1).ToString());
        print(FindMax() + 1);
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
        players[int.Parse(id) - 1].SetActive(false);
        angle.GetComponent<AngleControl>().id = id;
        angle.SetActive(true);        
    }
}
