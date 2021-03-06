﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostControl : MonoBehaviour {
    private float speed = 550;
    public string playerid;
    public bool isangle;
    public bool isattack;
    public bool canmove;
    public float attackrange;
    public float attacktime;
    public float attackdamage;
    public GameObject enemy;

    public bool freeze = false;
    public bool die = false;
    public Animator m_anim;
    private Rigidbody2D rigidbody;

    private float attackTimer;
    public float attackInterval = 1.0f;
    public int attacksoundid;
    public Sprite sprite;
	// Use this for initialization
	void Start () {
        m_anim = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (canmove)
        {
            if (freeze || die)
            {
                rigidbody.velocity = new Vector3(0, 0, 0);
                
            }
            else PlayerControl(playerid);
        }
        AnimatorControl();
    }

    void PlayerControl(string id)
    {
        float moveX = Input.GetAxis("LeftX" + id);
        float moveY = Input.GetAxis("LeftY" + id);        
        rigidbody.velocity = new Vector3(moveX * speed * Time.deltaTime, -moveY * speed * Time.deltaTime, 0);
        //transform.position += new Vector3(moveX * speed * Time.deltaTime, -moveY * speed * Time.deltaTime, 0);
        if (moveX < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveX > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //print(playerid+" "+Input.GetAxis("Attack" + playerid));
        if (Input.GetAxis("Attack" + playerid) < -0.9f && isattack == false && Time.time - attackTimer>= attackInterval)
        {
            isattack = true;
            //m_anim.SetTrigger("attack");
            StartCoroutine(Attack());
        }
    }

    public void AnimatorControl()
    {
        if (freeze)
        {
            m_anim.SetInteger("state", 4);
        }
        else if ((Mathf.Abs(Input.GetAxis("LeftX" + playerid)) > 0.05f || Mathf.Abs(Input.GetAxis("LeftY" + playerid)) > 0.05f )&& !isattack)
        {
            m_anim.SetInteger("state", 1);
        }
        else if (isattack)
        {
            m_anim.SetInteger("state", 2);
        }
        else
        {
            m_anim.SetInteger("state", 0);
        }
    }

    IEnumerator Attack()
    {
        m_anim.SetTrigger("attack");
        AudioManager.GetInstance().PlaySound(attacksoundid);
        yield return new WaitForSeconds(attacktime / 2);
        attackTimer = Time.time;
        if ((transform.localScale.x > 0 && transform.position.x > enemy.transform.position.x) || (transform.localScale.x < 0 && transform.position.x < enemy.transform.position.x))
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) < attackrange)
            {
                enemy.GetComponent<AngelHealth>().TakeDamage(attackdamage, playerid);
            }
        }
        yield return new WaitForSeconds(attacktime / 2);
        isattack = false;
        m_anim.SetTrigger("attackfinish");
    }
}
