using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KingSlime : MonoBehaviour {

    public static KingSlime instance;

    private Transform target;
    private Color c;
    private float moveSpeed = .25f;
    private float health = 100f;
    private float alpha = 1f;


    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Player").transform;
        c = this.gameObject.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();

        if (health <= 0f)
            Death();

        Debug.Log(health);
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "MagicBall")
        {   
            health -= 50f;
            Destroy(col.gameObject);
        }
    }

    void Follow()
    {
        Vector3 targetDirection = target.position - transform.position;
        transform.position += targetDirection * moveSpeed * Time.deltaTime * Time.timeScale;
    }

    IEnumerator Death()
    {
        while (true)
        {
            alpha -= .1f * Time.deltaTime;

            this.gameObject.GetComponent<Image>().color = new Color(c.r, c.g, c.b, alpha);

            if (alpha <= 0)
            {
                break;
            }

            yield return null;
        }

        Destroy(this.gameObject);
    }
}
