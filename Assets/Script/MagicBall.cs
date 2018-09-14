using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : MonoBehaviour {
	public static MagicBall instance;

	float shootDirect;
	float shootSpeed = 5f;

	void Update () {
		transform.Translate (Vector3.up * shootSpeed * Time.deltaTime * Time.timeScale);
	}
}
