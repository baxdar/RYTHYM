using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseGame : MonoBehaviour {

    bool paused;
    public GameObject pauseMenu;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(PauseUnPause(paused));
        }

	}
    IEnumerator PauseUnPause(bool p)
    {
        paused = !paused;
        pauseMenu.SetActive(!p);
        int gameTime = Convert.ToInt32(p);
        Time.timeScale = gameTime;
        yield return null;
    }
}
