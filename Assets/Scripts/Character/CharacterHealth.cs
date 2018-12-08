using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour {

    bool freeze;
    float freezeTimer = float.MinValue;
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void TakeDamage(float damage,GameObject attacker)
    {

    }
}
