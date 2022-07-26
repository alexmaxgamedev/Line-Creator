using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public GameObject pauseMenu;
	public GameObject inGameMenu;
	public GameObject controlPanel;
	public CameraPan cameraPan;
	public LineController lineController;

	[Header("Debug")]
	public bool paused = false;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			paused = !paused;

			if (paused == true)
			{
				Pause();
			}
			else
			{
				Resume();
			}
		}
	}

	public void Pause ()
	{
		pauseMenu.SetActive(true);
		inGameMenu.SetActive(false);
		controlPanel.SetActive(false);
		cameraPan.enabled = false;
		lineController.enabled = false;
		LevelManager.instance.StopTime();
	}

	public void Resume ()
	{
		pauseMenu.SetActive(false);
		inGameMenu.SetActive(true);
		controlPanel.SetActive(true);
		cameraPan.enabled = true;
		lineController.enabled = true;
		LevelManager.instance.ChangeTime();
	}
}
