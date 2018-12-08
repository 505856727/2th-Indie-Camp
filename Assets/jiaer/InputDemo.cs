using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDemo : MonoBehaviour {
    public float speed;
    public string playerid;
    public bool isattack;
    public float attackrange;
    public float attacktime;
    public GameObject enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerControl(playerid);        
    }

    void PlayerControl(string id)
    {
        transform.position += new Vector3(Input.GetAxis("LeftX"+id) * speed * Time.deltaTime, -Input.GetAxis("LeftY"+id) * speed * Time.deltaTime, 0);
        if (id != "5")
        {
            if (Input.GetAxis("RightX" + id) < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (Input.GetAxis("RightX" + id) > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            if (Input.GetAxis("RightY" + id) < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, Vector3.Angle(new Vector3(Input.GetAxis("RightX" + id), -Input.GetAxis("RightY" + id), 0), -Vector3.left));
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, -Vector3.Angle(new Vector3(Input.GetAxis("RightX" + id), -Input.GetAxis("RightY" + id), 0), -Vector3.left));
            }
        }
        if (Input.GetAxis("Attack" + playerid) == 1 && isattack == false)
        {
            isattack = true;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attacktime / 2);
        if (Vector3.Distance(enemy.transform.position, transform.position) < attackrange)
        {
            print(gameObject + " win");
        }
        yield return new WaitForSeconds(attacktime / 2);
        isattack = false;
    }
}
