using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour {
    public float speed;
    public string playerid;
    public bool isangle;
    public bool isattack;
    public bool canmove;
    public float attackrange;
    public float attacktime; 
    public GameObject enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (canmove)
        {
            PlayerControl(playerid);
        }  
    }

    void PlayerControl(string id)
    {
        transform.position += new Vector3(Input.GetAxis("LeftX"+id) * speed * Time.deltaTime, -Input.GetAxis("LeftY"+id) * speed * Time.deltaTime, 0);
        if (Input.GetAxis("RightX" + id) < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetAxis("RightX" + id) > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxis("Attack" + playerid) == -1 && isattack == false)
        {
            isattack = true;
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attacktime / 2);
        if ((transform.localScale.x > 0 && transform.position.x < enemy.transform.position.x) || (transform.localScale.x < 0 && transform.position.x > enemy.transform.position.x))
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) < attackrange)
            {
                print(gameObject + " win");
            }
        }
        yield return new WaitForSeconds(attacktime / 2);
        isattack = false;
    }
}
