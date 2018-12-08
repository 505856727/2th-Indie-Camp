using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonHealth : CharacterHealth
{
    private float freezeDuration = 2.0f;
    private float rebornTime = 5.0f;
    public GhostControl controller;
    public TombStone TombStonePrefab;
    bool freeze = false;
    float freezeTimer = float.MinValue;
    private Animator anim;
    // Use this for initialization
    void Start () {
        controller = GetComponent<GhostControl>();
        anim = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (freeze)
        {
            if(Time.time - freezeTimer >= freezeDuration)
            {
                AudioManager.GetInstance().PlaySound(1);
                freeze = false;
                controller.freeze = freeze;
                anim.SetTrigger("frozenEnd");
            }
        }
	}

    public override void TakeDamage(float damage, string attackerID)
    {
        base.TakeDamage(damage, attackerID);
        if (!freeze)
        {
            freeze = true;
            AudioManager.GetInstance().PlaySound(6);
            controller.freeze = freeze;
            freezeTimer = Time.time;
            anim.SetTrigger("frozenBegin");
        }
        else
        {
            DieProcess();
        }
    }

    public void DieProcess()
    {
        controller.die = true;
        GetComponentInChildren<Animator>().SetTrigger("Die");
        StartCoroutine(Reborn());
        AudioManager.GetInstance().PlaySound(9);
    }

    IEnumerator Reborn()
    {
        yield return new WaitForSeconds(rebornTime);
        //Animator setTrigger
        controller.die = false;
        AudioManager.GetInstance().PlaySound(11);
        GetComponentInChildren<Animator>().SetTrigger("Reborn");
    }
}
