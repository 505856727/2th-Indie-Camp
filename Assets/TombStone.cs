using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombStone : MonoBehaviour {
    public string playerid;
    public float rebornTime = 5.0f;
    public GameObject demonPrefab;
    private float rebornTimer = float.MinValue;
    
	// Use this for initialization
	void Start () {
        rebornTimer = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time - rebornTimer >= rebornTime)
        {
            //reborn
            GameObject demonObj = Instantiate(demonPrefab, transform.position, Quaternion.identity);
            //赋予playerID
        }
	}
}
