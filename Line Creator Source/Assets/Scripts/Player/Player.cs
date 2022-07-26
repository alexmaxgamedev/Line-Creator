using UnityEngine;

public class Player : MonoBehaviour 
{
	[Header("Properties")]
	public Camera playerCamera;
	public Rigidbody2D playerRigidBoby;
	public Vector3 playerResetPosition;

	[Header("Debug")]
	public bool playerPaused = true;

	public static Player instance;

	void Awake()
	{
		instance = this;
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			playerPaused = !playerPaused;

			if (playerPaused == true)
			{
				PausePlayer();
			}
			else
			{
				playerRigidBoby.simulated = true;
			}
		}

		if (Input.GetKeyDown (KeyCode.T))
		{
			LevelManager.instance.timeSlowed = !LevelManager.instance.timeSlowed;
			LevelManager.instance.ChangeTime();

		}

		if (Input.GetKeyDown (KeyCode.R)) 
		{
			PausePlayer();
			playerPaused = true;
			gameObject.transform.position = playerResetPosition;
			gameObject.transform.rotation = Quaternion.Euler (Vector3.zero);
		}
	}

	public void PausePlayer ()
	{
		playerRigidBoby.velocity = Vector2.zero;
		playerRigidBoby.angularVelocity = 0.0f;
		playerRigidBoby.simulated = false;
	}
}