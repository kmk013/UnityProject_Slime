using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    private Vector3 c;

	void Update () {
		Check ();
	}

	void Check() {
		c.x = Mathf.Clamp(transform.position.x, -4.5f, 4.5f);
        c.y = Mathf.Clamp(transform.position.y, -2.3f, 2.3f);
        c.z = -10;
        
		transform.position = Vector3.Lerp(c, new Vector3(GameManager.instance.player.transform.position.x, GameManager.instance.player.transform.position.y, -10), 2f * Time.deltaTime);
	}
}
