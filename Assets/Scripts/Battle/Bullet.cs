using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public string attackerID;
    public float damage = 10.0f;
    public float speed = 45.0f;
    public float duration = 2.0f;
    private bool bloom = false;
    private Animator m_anim;
    //public Vector3 forwardVec;
	// Use this for initialization
	void Start () {
        m_anim = GetComponent<Animator>();
        Destroy(this.gameObject, duration);
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position += speed * forwardVec *Time.deltaTime;
        if(!bloom)
            transform.Translate(speed*Time.deltaTime, 0, 0);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(!collision.GetComponent<GhostControl>().die || collision.gameObject.CompareTag("Wall"))
        {
            bloom = true;
            m_anim.SetTrigger("bloom");
            collision.GetComponent<DemonHealth>().TakeDamage(damage, attackerID);
        }
    }
}
