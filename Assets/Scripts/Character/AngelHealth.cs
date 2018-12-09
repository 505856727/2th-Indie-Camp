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
    public GameObject bomb;
    private Color originColor;
    public Color splashColor = Color.red;
    public float toredspeed;
    // Use this for initialization
    void Start () {
        //spriteRender = GetComponentInChildren<SpriteRenderer>();
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
        StopCoroutine("ToRed");
        StartCoroutine("ToRed");        
        if (currentHp <= 0)
        {
            Debug.Log("Die");
            bomb.SetActive(true);
            bomb.transform.position = transform.position += new Vector3(0, 1, 0);
            AudioManager.GetInstance().PlaySound(4);
            GameMgr.instance.TurnToAngel(attackerID, GetComponent<AngleControl>().id);
            FightManager.GetInstance().ToGhost(GetComponent<AngleControl>().id);
            FightManager.GetInstance().ToAngle(attackerID);
            currentHp = maxHp;
        }
        if (HpSlider)
            HpSlider.value = currentHp;
        else Debug.LogError("No Slider");

        //splashTimer = Time.time;
        //splashTime = Time.time;
    }

    IEnumerator ToRed()
    {
        while (spriteRender.color.g > 0.1f)
        {
            spriteRender.color -= new Color(0, toredspeed * Time.deltaTime, toredspeed * Time.deltaTime, 0);
            yield return null;
        }
        while (spriteRender.color.g < 0.99f)
        {
            spriteRender.color += new Color(0, toredspeed * Time.deltaTime, toredspeed * Time.deltaTime, 0);
            yield return null;
        }
    }
}
