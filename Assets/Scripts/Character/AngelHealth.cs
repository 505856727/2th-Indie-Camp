using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngelHealth : CharacterHealth {
    public Slider WinSlider;
    public Slider HpSlider;
    public float maxHp = 100;
    public float currentHp = 100;

    private float splashTimer;//计时器
    private float splashDuration = 1.0f;
    private float splashTime;//计时器
    public  SpriteRenderer spriteRender;
    private Color originColor;
    public Color splashColor = Color.red;
    // Use this for initialization
    void Start () {
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        originColor = spriteRender.color;
    }

    private void OnEnable()
    {
        currentHp = maxHp;
        if (HpSlider)
            HpSlider.value = currentHp;
    }

    // Update is called once per frame
    void Update () {
        //if(Time.time - splashTimer<= splashDuration)
        //{
        //    splashTime += Time.deltaTime;
        //    if (splashTime % 2 > 0.1)//除以2余数大于0.5即每1秒显隐一次
        //    {
        //        spriteRender.color = splashColor;
        //    }
        //    else
        //    {
        //        spriteRender.color = originColor;
        //    }

        //}
        //else spriteRender.color = originColor;

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

        //splashTimer = Time.time;
        //splashTime = Time.time;
    }
}
