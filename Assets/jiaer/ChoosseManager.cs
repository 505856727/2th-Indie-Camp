using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosseManager : MonoBehaviour {
    public GameObject[] touch;
    private bool isok;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            touch[0].SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Joystick2Button0))
        {
            touch[1].SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Joystick3Button0))
        {
            touch[2].SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Joystick4Button0))
        {
            touch[3].SetActive(true);
        }
        isok = true;
        for(int i = 0; i < 4; i++)
        {
            if (touch[i].activeSelf == false)
            {
                isok = false;
            }
        }
        if (isok)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
