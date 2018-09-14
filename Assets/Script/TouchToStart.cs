using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TouchToStart : MonoBehaviour {

    public GameObject Door;
    public GameObject Hole;
    public GameObject Title;
    public GameObject Inside;

    private Color c;
    private Color titleColor;
    private Color insideColor;
    private float alpha = 1f;
    private float speed = 0.3f;
    private float insideSpeed = 0.03f;
    private int i = 0;

    bool Fading;
    bool Into = false;

    // Use this for initialization
    void Start()
    {
        c = Door.GetComponent<Image>().color;
        titleColor = Title.GetComponent<Image>().color;
        insideColor = Inside.GetComponent<Image>().color;
    }

    public void Clicked()
    {
        StartCoroutine(Fade());
    }

    private void Update()
    {
        Debug.Log(alpha);
    }


    IEnumerator Fade()
    {
        while (true)
        {
            alpha -= speed * Time.deltaTime;
            Door.GetComponent<Image>().color = new Color(c.r, c.g, c.b, alpha);
            Title.GetComponent<Image>().color = new Color(titleColor.r, titleColor.g, titleColor.b, alpha);

            if (alpha <= 0)
            {
                break;
            }
            yield return null;
        }

        StartCoroutine(IntoHole());
    }

    IEnumerator IntoHole()
    {
        while (true)
        {
            Hole.transform.localScale += new Vector3(insideSpeed, insideSpeed, 0);

            if (Hole.transform.localScale.x >= 3.8 && Hole.transform.localScale.y >= 3.8)
            {
                break;
            }

            yield return null;
        }

        StartCoroutine(InsideCave());
    }

    IEnumerator InsideCave()
    {
        while (true)
        {
            alpha += .5f * Time.deltaTime;
            Inside.GetComponent<Image>().color = new Color(insideColor.r, insideColor.g, insideColor.b, alpha);

            if (alpha >= 1)
            {
                break;
            }

            yield return null;
        }

    }
}
