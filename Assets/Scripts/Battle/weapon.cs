using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    Vector3 screenPosition;//将物体从世界坐标转换为屏幕坐标
    Vector3 mousePositionOnScreen;//获取到点击屏幕的屏幕坐标
    Vector3 mousePositionInWorld;//将点击屏幕的屏幕坐标转换为世界坐标
    Vector3 direction;//武器的方向向量
    public Bullet bulletPrefab;
    private AngleControl angelController;
    //private Transform bullets;

	// Use this for initialization
	void Start () {
        angelController = GetComponentInParent<AngleControl>();
    }
	
	// Update is called once per frame
	void Update () {
		//获取鼠标在相机中（世界中）的位置，转换为屏幕坐标；
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //获取鼠标在场景中坐标
        mousePositionOnScreen = Input.mousePosition;
        //让场景中的Z=鼠标坐标的Z
        mousePositionOnScreen.z = screenPosition.z;
        //将相机中的坐标转化为世界坐标
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        //物体到角色的向量
		//mousePositionInWorld - transform.position
        //Vector3.Angle(Vector3.Right,dirB);
		Vector3 offVector = mousePositionInWorld - transform.position;
		if(offVector.y<0)
			transform.eulerAngles = new Vector3(0, 0, (-1)*Vector3.Angle(mousePositionInWorld - transform.position,Vector3.right));
		else 
		    transform.eulerAngles = new Vector3(0, 0, Vector3.Angle(mousePositionInWorld - transform.position,Vector3.right));

        direction = (mousePositionInWorld - transform.position).normalized;
        
        //if (Input.GetMouseButtonDown(0))
        if(angelController.isattack)
        {
            Shoot();
        }
	}

    void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.EulerAngles(transform.eulerAngles));
        bullet.forwardVec = direction;
    }
}
