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
            //Animator setTrigger
            //
            controller.die = true;
            controller.m_anim.SetInteger("state", 3);
            //Die动画播放完之后调用Destroy
            //
            //TombStone TombStoneObj = Instantiate(TombStonePrefab, transform.position, Quaternion.identity);
            //TombStoneObj.playerid = controller.playerid;
            StartCoroutine(Reborn());
        }
    }

    IEnumerator Reborn()
    {
        yield return new WaitForSeconds(rebornTime);
        //Animator setTrigger
        controller.die = false;
        controller.m_anim.SetInteger("state", 0);
        //恢复
    }
}
