using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {
    public GameObject start;
    public GameObject quit;
    public GameObject star;
    public AudioClip music;
    public float offset;
    public bool isstart;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        choose();
    }

    void choose()
    {
        if (Input.GetAxis("LeftY") > 0.5f && isstart)
        {
            star.transform.position=new Vector3(0, -offset, 0);
            isstart = false;
        }
        else if (Input.GetAxis("LeftY") < -0.5f && !isstart)
        {
            star.transform.position = new Vector3(0, 0, 0);
            isstart = true;
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton0)&&isstart)
        {
            SceneManager.LoadScene("Selector");
        }
        else if(Input.GetKeyDown(KeyCode.JoystickButton0) && !isstart)
        {
            Application.Quit();
        }
    }
}
