using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	[Header("Properties")]
	public float slowTimeValue = 0.2f;
	public float normalTimeValue = 1.0f;
	public float timeStabilizer = 0.02f;

	[Header("Debug")]
	public bool timeSlowed = false;

	public static LevelManager instance;

	void Awake ()
	{
		instance = this;
	}

	public void ResumeTime ()
	{
		Time.timeScale = normalTimeValue;
		Time.fixedDeltaTime = timeStabilizer* Time.timeScale;
	}

	public void SlowTime ()
	{
		Time.timeScale = slowTimeValue;
		Time.fixedDeltaTime = timeStabilizer * Time.timeScale;
	}

	public void StopTime ()
	{
		Time.timeScale = 0.0f;
		Time.fixedDeltaTime = timeStabilizer * Time.deltaTime;
	}

	public void ChangeTime()
	{
		if (timeSlowed == true)
		{
			SlowTime();
		}
		else
		{
			ResumeTime();
		}
	}

	public void LoadLevel (int index)
	{
		SceneManager.LoadScene(index);
		ResumeTime();
	}

	public void QuitGame ()
	{
		Application.Quit();
	}
}
