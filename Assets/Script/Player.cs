using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public static Player instance;

    public Animator controller;
    public GameObject hpBar;
    public GameObject manaBar;
    public int killNum = 9;

    public  float health = 100f;
    public float manapoint = 100f;

    private float playerMoveSpeed = 2f;

    private float recoveryTimer = 0f;

    Vector3 position = Vector3.zero;

    void Start()
    {
        Player.instance = this;
        controller = GetComponent<Animator>();

    }

    void Update()
    {
        Move();
        PlayerDirection();
        SelfRecovery();

        Debug.Log(killNum);
    }

    void Move()
    {
        if (JoystickCtrl.instance.drag)
        {
            position += JoystickCtrl.instance.dir * playerMoveSpeed * Time.deltaTime * Time.timeScale;
            transform.position = new Vector3(position.x, position.y, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            health -= 5f;
            hpBar.gameObject.GetComponent<Slider>().value -= 5f;
        }
        if (col.gameObject.tag == "KingEnemy")
        {
            health -= 10f;
            hpBar.gameObject.GetComponent<Slider>().value -= 10f;
        }
    }

    void SelfRecovery()
    {
        recoveryTimer += Time.deltaTime;

        if(recoveryTimer >= 1)
        {
            if (0 <= health && health < 99)
            {
                health += 2;
                hpBar.gameObject.GetComponent<Slider>().value += 2;
            }
            if (0 <= manapoint && manapoint < 99)
            {
                manapoint += 3;
                manaBar.gameObject.GetComponent<Slider>().value += 3;
            }

            recoveryTimer = 0;
        }
    }

    void PlayerDirection()
    {
		if (JoystickCtrl.instance.angle >= 0 && JoystickCtrl.instance.angle <= 90)
        {
            controller.SetBool("isUp", true);
            controller.SetBool("isRight", false);
            controller.SetBool("isLeft", false);
            controller.SetBool("isDown", false);

            controller.SetBool("isUpIdle", false);
            controller.SetBool("isRightIdle", false);
            controller.SetBool("isLeftIdle", false);
            controller.SetBool("isDownIdle", false);
            if (!JoystickCtrl.instance.drag)
            {
                controller.SetBool("isUp", false);
                controller.SetBool("isRight", false);
                controller.SetBool("isLeft", false);
                controller.SetBool("isDown", false);

                controller.SetBool("isUpIdle", true);
                controller.SetBool("isRightIdle", false);
                controller.SetBool("isLeftIdle", false);
                controller.SetBool("isDownIdle", false);
            }
        }
		if (JoystickCtrl.instance.angle > 90 && JoystickCtrl.instance.angle <= 180)
        {
            controller.SetBool("isUp", false);
            controller.SetBool("isRight", true);
            controller.SetBool("isLeft", false);
            controller.SetBool("isDown", false);

            controller.SetBool("isUpIdle", false);
            controller.SetBool("isRightIdle", false);
            controller.SetBool("isLeftIdle", false);
            controller.SetBool("isDownIdle", false);
            if (!JoystickCtrl.instance.drag)
            {
                controller.SetBool("isUp", false);
                controller.SetBool("isRight", false);
                controller.SetBool("isLeft", false);
                controller.SetBool("isDown", false);

                controller.SetBool("isUpIdle", false);
                controller.SetBool("isRightIdle", true);
                controller.SetBool("isLeftIdle", false);
                controller.SetBool("isDownIdle", false);
            }
        }
		if (JoystickCtrl.instance.angle > 180 && JoystickCtrl.instance.angle <= 270)
        {
            controller.SetBool("isUp", false);
            controller.SetBool("isRight", false);
            controller.SetBool("isLeft", false);
            controller.SetBool("isDown", true);

            controller.SetBool("isUpIdle", false);
            controller.SetBool("isRightIdle", false);
            controller.SetBool("isLeftIdle", false);
            controller.SetBool("isDownIdle", false);
            if (!JoystickCtrl.instance.drag)
            {
                controller.SetBool("isUp", false);
                controller.SetBool("isRight", false);
                controller.SetBool("isLeft", false);
                controller.SetBool("isDown", false);

                controller.SetBool("isUpIdle", false);
                controller.SetBool("isRightIdle", false);
                controller.SetBool("isLeftIdle", false);
                controller.SetBool("isDownIdle", true);
            }
        }
		if(0 > JoystickCtrl.instance.angle && -45 <= JoystickCtrl.instance.angle || JoystickCtrl.instance.angle > 270 && JoystickCtrl.instance.angle <= 315)
        {
            controller.SetBool("isUp", false);
            controller.SetBool("isRight", false);
            controller.SetBool("isLeft", true);
            controller.SetBool("isDown", false);

            controller.SetBool("isUpIdle", false);
            controller.SetBool("isRightIdle", false);
            controller.SetBool("isLeftIdle", false);
            controller.SetBool("isDownIdle", false);
            if (!JoystickCtrl.instance.drag)
            {
                controller.SetBool("isUp", false);
                controller.SetBool("isRight", false);
                controller.SetBool("isLeft", false);
                controller.SetBool("isDown", false);

                controller.SetBool("isUpIdle", false);
                controller.SetBool("isRightIdle", false);
                controller.SetBool("isLeftIdle", true);
                controller.SetBool("isDownIdle", false);
            }
        }
    }
}
