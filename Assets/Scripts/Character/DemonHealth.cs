using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonHealth : CharacterHealth
{
    public float freezeDuration = 3.0f;
    public CharacterMovement controller;
    public TombStone TombStonePrefab;
    bool freeze = false;
    float freezeTimer = float.MinValue;
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterMovement>();
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
            Debug.Log("Demon Die");
            //Animator setTrigger
            //
            controller.die = true;
            //Die动画播放完之后调用Destroy
            //
            TombStone TombStoneObj = Instantiate(TombStonePrefab, transform.position, Quaternion.identity);
            TombStoneObj.playerid = controller.playerid;
        }
    }
}
