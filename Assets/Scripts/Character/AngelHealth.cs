using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngelHealth : CharacterHealth {
    public Slider WinSlider;
    public float maxHp = 100;
    public float currentHp = 100;
    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public override void TakeDamage(float damage, string attackerID)
    {
        base.TakeDamage(damage, attackerID);
        currentHp -= damage;
        if (WinSlider)
            WinSlider.value = currentHp;
        else Debug.LogError("No Slider");
        if (currentHp <= 0)
        {
            Debug.Log("Die");
        }
    }
}
