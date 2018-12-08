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
    public Animator m_anim;
	// Use this for initialization
	void Start () {
        m_anim = GetComponentInChildren<Animator>();
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
        float moveX = Input.GetAxis("LeftX" + id);
        float moveY = Input.GetAxis("LeftY" + id);
        if (moveX != 0 || moveY != 0)
            m_anim.SetBool("moving", true);
        else m_anim.SetBool("moving", false);

        transform.position += new Vector3(moveX * speed * Time.deltaTime, -moveY * speed * Time.deltaTime, 0);
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
            m_anim.SetTrigger("attack");
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
        m_anim.ResetTrigger("attack");
        isattack = false;
    }
}
