using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDemo : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position+=new Vector3(Input.GetAxis("LeftX1") * speed * Time.deltaTime, -Input.GetAxis("LeftY1") * speed * Time.deltaTime, 0);
        if (Input.GetAxis("RightY1") < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, Vector3.Angle(new Vector3(Input.GetAxis("RightX1"), -Input.GetAxis("RightY1"), 0), -Vector3.left));
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -Vector3.Angle(new Vector3(Input.GetAxis("RightX1"), -Input.GetAxis("RightY1"), 0), -Vector3.left));
        }

    }
}
