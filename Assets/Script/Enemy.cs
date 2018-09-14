using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public static Enemy instance;

    public Transform target;

    private float moveSpeed = .5f;  
    private float health = 10f;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        Follow();

        if (health <= 0)
        {
            Destroy(this.gameObject);
            Player.instance.killNum += 1;
        }
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "MagicBall")
        {
            health -= 4f;
            Destroy(col.gameObject);
        }
    }

    void Follow()
    {
        Vector3 targetDirection = target.position - transform.position;
		transform.position += targetDirection * moveSpeed * Time.deltaTime * Time.timeScale;
    }
}
