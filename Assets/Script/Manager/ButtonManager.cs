using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    public static ButtonManager instance;

	GameObject magicBall;

    public int id = 0;

    private float destoryTimer = 0f;
    private float timer = 0f;

    void UseMana()
    {
        Player.instance.manapoint -= 5;
        Player.instance.manaBar.gameObject.GetComponent<Slider>().value -= 5;
    }

    void Update()
    {
        destoryTimer += Time.deltaTime;

        if(destoryTimer >= 3f)
        {
            Destroy(magicBall);
            destoryTimer = 0f;
        }
    }

    public void shootMagicBallRight()
    {
        if (Player.instance.manapoint >= 5)
        {
            switch (id)
            {
                case 0:
                    magicBall = Instantiate(GameManager.instance.magicBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 1:
                    magicBall = Instantiate(GameManager.instance.fireBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 2:
                    magicBall = Instantiate(GameManager.instance.earthBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 3:
                    magicBall = Instantiate(GameManager.instance.windBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 4:
                    magicBall = Instantiate(GameManager.instance.waterBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
            }
            magicBall.transform.rotation = Quaternion.Euler(0, 0, 270);

            UseMana();

            if (!JoystickCtrl.instance.drag)
                StartCoroutine(SeeRightIdle());
            else
                StartCoroutine(SeeRight());
        }
    }

	public void shootMagicBallLeft() {
        if (Player.instance.manapoint >= 5)
        {
            switch (id)
            {
                case 0:
                    magicBall = Instantiate(GameManager.instance.magicBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 1:
                    magicBall = Instantiate(GameManager.instance.fireBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 2:
                    magicBall = Instantiate(GameManager.instance.earthBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 3:
                    magicBall = Instantiate(GameManager.instance.windBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 4:
                    magicBall = Instantiate(GameManager.instance.waterBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
            }
            magicBall.transform.rotation = Quaternion.Euler(0, 0, 90);

            UseMana();

            if (!JoystickCtrl.instance.drag)
                StartCoroutine(SeeLeftIdle());
            else
                StartCoroutine(SeeLeft());
        }
    }

	public void shootMagicBallUp() {
        if (Player.instance.manapoint >= 5)
        {
            switch (id)
            {
                case 0:
                    magicBall = Instantiate(GameManager.instance.magicBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 1:
                    magicBall = Instantiate(GameManager.instance.fireBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 2:
                    magicBall = Instantiate(GameManager.instance.earthBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 3:
                    magicBall = Instantiate(GameManager.instance.windBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 4:
                    magicBall = Instantiate(GameManager.instance.waterBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
            }
            magicBall.transform.rotation = Quaternion.Euler(0, 0, 0);

            UseMana();

            if (!JoystickCtrl.instance.drag)
                StartCoroutine(SeeUpIdle());
            else
                StartCoroutine(SeeUp());
        }
    }

	public void shootMagicBallDown() {
        if (Player.instance.manapoint >= 5)
        {
            switch (id)
            {
                case 0:
                    magicBall = Instantiate(GameManager.instance.magicBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 1:
                    magicBall = Instantiate(GameManager.instance.fireBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 2:
                    magicBall = Instantiate(GameManager.instance.earthBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 3:
                    magicBall = Instantiate(GameManager.instance.windBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
                case 4:
                    magicBall = Instantiate(GameManager.instance.waterBall, GameManager.instance.player.transform.position, Quaternion.identity) as GameObject;
                    break;
            }
            magicBall.transform.rotation = Quaternion.Euler(0, 0, 180);

            UseMana();

            if (!JoystickCtrl.instance.drag)
                StartCoroutine(SeeDownIdle());
            else
                StartCoroutine(SeeDown());
        }
    }

    public void changeElementalButtonOn() {
		GameManager.instance.changeElementalUI.SetActive (true);
		Time.timeScale = 0.3f;
	}

	public void changeElementalButtonOff() {
		GameManager.instance.changeElementalUI.SetActive (false);

		Time.timeScale = 1;
	}

	public void changeMana() {
        if(ElementManager.instance.canMana)
		    id = 0;
	}

	public void changeFire() {
        if(ElementManager.instance.canFire)
		    id = 1;
	}

	public void changeEarth() {
        if(ElementManager.instance.canEarth)
            id = 2;
	}

	public void changeAir() {
        if(ElementManager.instance.canAir)
            id = 3;
	}

	public void changeWater() {
        if(ElementManager.instance.canWater)
            id = 4;
	}

    IEnumerator SeeRight()
    {
        while (true)
        {
            Player.instance.controller.SetBool("isUpIdle", false);
            Player.instance.controller.SetBool("isRightIdle", false);
            Player.instance.controller.SetBool("isDownIdle", false);
            Player.instance.controller.SetBool("isLeftIdle", false);

            Player.instance.controller.SetBool("isUp", false);
            Player.instance.controller.SetBool("isRight", true);
            Player.instance.controller.SetBool("isLeft", false);
            Player.instance.controller.SetBool("isDown", false);

            timer += Time.deltaTime;

            if (timer >= .4f)
            {
                timer = 0;
                break;
            }

            yield return null;
        }
       
    }

    IEnumerator SeeLeft()
    {
        while (true)
        {
            Player.instance.controller.SetBool("isUpIdle", false);
            Player.instance.controller.SetBool("isRightIdle", false);
            Player.instance.controller.SetBool("isDownIdle", false);
            Player.instance.controller.SetBool("isLeftIdle", false);

            Player.instance.controller.SetBool("isUp", false);
            Player.instance.controller.SetBool("isRight", false);
            Player.instance.controller.SetBool("isLeft", true);
            Player.instance.controller.SetBool("isDown", false);

            timer += Time.deltaTime;

            if (timer >= .4f)
            {
                timer = 0;
                break;
            }

            yield return null;
        }

    }

    IEnumerator SeeUp()
    {
        while (true)
        {
            Player.instance.controller.SetBool("isUpIdle", false);
            Player.instance.controller.SetBool("isRightIdle", false);
            Player.instance.controller.SetBool("isDownIdle", false);
            Player.instance.controller.SetBool("isLeftIdle", false);

            Player.instance.controller.SetBool("isUp", true);
            Player.instance.controller.SetBool("isRight", false);
            Player.instance.controller.SetBool("isLeft", false);
            Player.instance.controller.SetBool("isDown", false);

            timer += Time.deltaTime;

            if (timer >= .4f)
            {
                timer = 0;
                break;
            }

            yield return null;
        }

    }

    IEnumerator SeeDown()
    {
        while (true)
        {
            Player.instance.controller.SetBool("isUpIdle", false);
            Player.instance.controller.SetBool("isRightIdle", false);
            Player.instance.controller.SetBool("isDownIdle", false);
            Player.instance.controller.SetBool("isLeftIdle", false);

            Player.instance.controller.SetBool("isUp", false);
            Player.instance.controller.SetBool("isRight", false);
            Player.instance.controller.SetBool("isLeft", false);
            Player.instance.controller.SetBool("isDown", true);

            timer += Time.deltaTime;

            if (timer >= .4f)
            {
                timer = 0;
                break;
            }

            yield return null;
        }

    }

    IEnumerator SeeUpIdle()
    {
        while (true)
        {
            Player.instance.controller.SetBool("isUpIdle", true);
            Player.instance.controller.SetBool("isRightIdle", false);
            Player.instance.controller.SetBool("isDownIdle", false);
            Player.instance.controller.SetBool("isLeftIdle", false);

            Player.instance.controller.SetBool("isUp", false);
            Player.instance.controller.SetBool("isRight", false);
            Player.instance.controller.SetBool("isLeft", false);
            Player.instance.controller.SetBool("isDown", false);

            timer += Time.deltaTime;

            if (timer >= .4f)
            {
                timer = 0;
                break;
            }

            yield return null;
        }

    }

    IEnumerator SeeRightIdle()
    {
        while (true)
        {
            Player.instance.controller.SetBool("isUpIdle", false);
            Player.instance.controller.SetBool("isRightIdle", true);
            Player.instance.controller.SetBool("isDownIdle", false);
            Player.instance.controller.SetBool("isLeftIdle", false);

            Player.instance.controller.SetBool("isUp", false);
            Player.instance.controller.SetBool("isRight", false);
            Player.instance.controller.SetBool("isLeft", false);
            Player.instance.controller.SetBool("isDown", false);

            timer += Time.deltaTime;

            if (timer >= .4f)
            {
                timer = 0;
                break;
            }

            yield return null;
        }

    }

    IEnumerator SeeDownIdle()
    {
        while (true)
        {
            Player.instance.controller.SetBool("isUpIdle", false);
            Player.instance.controller.SetBool("isRightIdle", false);
            Player.instance.controller.SetBool("isDownIdle", true);
            Player.instance.controller.SetBool("isLeftIdle", false);

            Player.instance.controller.SetBool("isUp", false);
            Player.instance.controller.SetBool("isRight", false);
            Player.instance.controller.SetBool("isLeft", false);
            Player.instance.controller.SetBool("isDown", false);

            timer += Time.deltaTime;

            if (timer >= .4f)
            {
                timer = 0;
                break;
            }

            yield return null;
        }

    }

    IEnumerator SeeLeftIdle()
    {
        while (true)
        {
            Player.instance.controller.SetBool("isUpIdle", false);
            Player.instance.controller.SetBool("isRightIdle", false);
            Player.instance.controller.SetBool("isDownIdle", false);
            Player.instance.controller.SetBool("isLeftIdle", true);

            Player.instance.controller.SetBool("isUp", false);
            Player.instance.controller.SetBool("isRight", false);
            Player.instance.controller.SetBool("isLeft", false);
            Player.instance.controller.SetBool("isDown", false);

            timer += Time.deltaTime;

            if (timer >= .4f)
            {
                timer = 0;
                break;
            }

            yield return null;
        }

    }
}
