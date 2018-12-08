using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {
    public GameObject start;
    public GameObject quit;
    public GameObject star;
    public float offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        choose();
    }

    void choose()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider && hit.collider.gameObject == start)
        {
            star.transform.position = Vector3.zero;
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Game");
            }
        }
        else if (hit.collider && hit.collider.gameObject == quit)
        {
            star.transform.position = new Vector3(0, -offset, 0);
            if (Input.GetMouseButtonDown(0))
            {
                Application.Quit();
            }
        }
     
    }

}
