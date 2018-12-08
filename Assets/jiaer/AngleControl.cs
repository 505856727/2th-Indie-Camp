using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleControl : MonoBehaviour {
    public string id;
    public bool isattack;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AngleMove();
        AngleAttack();
	}

    void AngleMove()
    {
        transform.position += new Vector3(Input.GetAxis("LeftX" + id) * speed * Time.deltaTime, -Input.GetAxis("LeftY" + id) * speed * Time.deltaTime, 0);
        if (Input.GetAxis("RightY" + id) < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, Vector3.Angle(new Vector3(Input.GetAxis("RightX" + id), -Input.GetAxis("RightY" + id), 0), -Vector3.left));
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -Vector3.Angle(new Vector3(Input.GetAxis("RightX" + id), -Input.GetAxis("RightY" + id), 0), -Vector3.left));
        }
    }

    void AngleAttack()
    {
        if (Input.GetAxis("Attack" + id) == 1 && isattack == false)
        {
            isattack = true;
        }
        else
        {
            isattack = false;
        }
    }
}
