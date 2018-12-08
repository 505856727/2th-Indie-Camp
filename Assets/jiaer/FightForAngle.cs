using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightForAngle : MonoBehaviour {
    public GameObject[] players;
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
            if (blick[i] < blick[i + 1])
            {
                value = i + 1;
            }
            else
            {
                value = i;
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
        players[FindMax()].GetComponent<InputDemo>().playerid = "5";
        print(players[FindMax()]);
    }
}
