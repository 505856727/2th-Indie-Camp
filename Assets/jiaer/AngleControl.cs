using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleControl : MonoBehaviour {
    public string id;
    public bool isattack;
    public float speed;
    public GameObject weapon;

    private Rigidbody2D rigidbody;
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        AngleMove();
    }

    // Update is called once per frame
    void Update () {
        AngleAttack();
	}

    void AngleMove()
    {
        rigidbody.velocity = new Vector3(Input.GetAxis("LeftX" + id) * speed * Time.deltaTime, -Input.GetAxis("LeftY" + id) * speed * Time.deltaTime, 0);
        //transform.position += new Vector3(Input.GetAxis("LeftX" + id) * speed * Time.deltaTime, -Input.GetAxis("LeftY" + id) * speed * Time.deltaTime, 0);
        if (Input.GetAxis("LeftX" + id) < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxis("LeftX" + id) > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Mathf.Abs(Input.GetAxis("RightY" + id)) > 0.5f || Mathf.Abs(Input.GetAxis("RightX" + id)) > 0.5f)
        {
            if (Input.GetAxis("RightY" + id) < 0)
            {
                weapon.transform.eulerAngles = new Vector3(0, 0, Vector3.Angle(new Vector3(Input.GetAxis("RightX" + id), -Input.GetAxis("RightY" + id), 0), -Vector3.left));
            }
            else
            {
                weapon.transform.eulerAngles = new Vector3(0, 0, -Vector3.Angle(new Vector3(Input.GetAxis("RightX" + id), -Input.GetAxis("RightY" + id), 0), -Vector3.left));
            }
        }
    }

    void AngleAttack()
    {
        if (Input.GetAxis("Attack" + id)<-0.9f)
        {
            isattack = true;
        }
        else
        {
            isattack = false;
        }
    }
}
