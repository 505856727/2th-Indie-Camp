using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelHealth : CharacterHealth {
    public float maxHp;
    public float currentHp;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TakeDamage(float damage, GameObject attacker)
    {
        base.TakeDamage(damage, attacker);
        currentHp -= damage;
        if(currentHp <= 0)
        {
            Debug.Log("Die");
        }
    }
}
