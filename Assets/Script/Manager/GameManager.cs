using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	[HideInInspector]
	public GameObject player;

	public GameObject fireBall;
	public GameObject magicBall;
	public GameObject earthBall;
	public GameObject waterBall;
	public GameObject windBall;

	public GameObject changeElementalUI;
    public GameObject pauseUI;

	void Start () {
		GameManager.instance = this;

		player = GameObject.Find ("Player");
	}
}
