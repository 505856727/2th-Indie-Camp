using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashTest : MonoBehaviour {

    private float splashTimer;//计时器
    private float splashDuration = 1.0f;
    private float splashTime;//计时器
    public SpriteRenderer spriteRender;
    private Color originColor;
    public Color splashColor = Color.red;
    // Use this for initialization
    void Start () {
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        originColor = spriteRender.color;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            splashTimer = Time.time;
            splashTime = Time.time; ;
        }
        if (Time.time - splashTimer <= splashDuration)
        {
            splashTime += Time.deltaTime;
            if (splashTime % 2 > 0.05)//除以2余数大于0.5即每1秒显隐一次
            {
                spriteRender.color = splashColor;
            }
            else
            {
                spriteRender.color = originColor;
            }

        }
        else spriteRender.color = originColor;
    }
}
