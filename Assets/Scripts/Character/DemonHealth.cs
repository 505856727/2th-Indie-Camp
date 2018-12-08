using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonHealth : CharacterHealth
{
    public float freezeDuration = 3.0f;
    public CharacterMovement controller;
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

    public override void TakeDamage(float damage, GameObject attacker)
    {
        base.TakeDamage(damage, attacker);
        if (!freeze)
        {
            freeze = true;
            controller.freeze = freeze;
            freezeTimer = Time.time;
        }
        else
        {
            Debug.Log("Demon Die");
        }
    }
}
