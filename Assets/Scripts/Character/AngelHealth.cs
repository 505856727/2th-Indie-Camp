using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngelHealth : CharacterHealth {
    public Slider WinSlider;
    public Slider HpSlider;
    public float maxHp = 100;
    public float currentHp = 100;
    // Use this for initialization
    void Start () {
		
	}

    private void OnEnable()
    {
        currentHp = maxHp;
        if (HpSlider)
            HpSlider.value = currentHp;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public override void TakeDamage(float damage, string attackerID)
    {
        base.TakeDamage(damage, attackerID);
        currentHp -= damage;

        
        if (currentHp <= 0)
        {
            Debug.Log("Die");
            FightManager.GetInstance().ToGhost(GetComponent<AngleControl>().id);
            FightManager.GetInstance().ToAngle(attackerID);
            GameMgr.instance.TurnToAngel(attackerID, "0");
            currentHp = maxHp;
        }
        if (HpSlider)
            HpSlider.value = currentHp;
        else Debug.LogError("No Slider");
    }
}
