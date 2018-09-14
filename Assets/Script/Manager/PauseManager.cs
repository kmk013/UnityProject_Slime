using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public static PauseManager instance;

    public void ShowPauseUI()
    {
        GameManager.instance.pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void DisappearPauseUI()
    {
        GameManager.instance.pauseUI.SetActive(false);
        Time.timeScale = 1;
    }
}
