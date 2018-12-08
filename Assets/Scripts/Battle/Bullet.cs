using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public string attackerID;
    public float damage = 10.0f;
    public float speed = 100.0f;
    public float duration = 1.0f;
    public Vector3 forwardVec;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, duration);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += speed * forwardVec *Time.deltaTime;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<DemonHealth>().TakeDamage(damage, attackerID);
    }
}
