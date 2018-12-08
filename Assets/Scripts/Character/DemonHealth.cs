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
    // Use this for initialization
    void Start () {
        controller = GetComponent<GhostControl>();
    }
	
	// Update is called once per frame
	void Update () {
        if (freeze)
        {
            if(Time.time - freezeTimer >= freezeDuration)
            {
                freeze = false;
                controller.freeze = freeze;
            }
        }
	}

    public override void TakeDamage(float damage, string attackerID)
    {
        base.TakeDamage(damage, attackerID);
        if (!freeze)
        {
            freeze = true;
            controller.freeze = freeze;
            freezeTimer = Time.time;
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
    }

    IEnumerator Reborn()
    {
        yield return new WaitForSeconds(rebornTime);
        //Animator setTrigger
        controller.die = false;
        GetComponentInChildren<Animator>().SetTrigger("Reborn");
    }
}
