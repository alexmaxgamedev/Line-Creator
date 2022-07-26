using UnityEngine;

public class CameraPan : MonoBehaviour
{
	[Header ("Camera Pan")]
	public float camPanSpeed = -2.0f;
	public float maxCamZoom = 15.0f;
	public float minCamZoom = 1.0f;

	[Header ("Follow Cam")]
	public float smoothCamSpeed = 500.0f;
	public Vector3 followCameraOffset;

	[Header("Debug")]
	public bool isFollowingPlayer;
	public Vector3 lastMousePosition;
	public Vector3 directionPosition;
	public Vector3 cameraPanDirection;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.F))
		{
			isFollowingPlayer = !isFollowingPlayer;

			if (Player.instance.playerPaused == true)
			{
				transform.position = Player.instance.transform.position;
			}
		}

		if (isFollowingPlayer == true && Player.instance.playerPaused == false)
		{
			directionPosition = Player.instance.transform.position + followCameraOffset;
			transform.position = Vector3.Lerp (transform.position, directionPosition, smoothCamSpeed * Time.deltaTime);
		}

		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && Player.instance.playerCamera.orthographicSize != maxCamZoom) 
		{
			Player.instance.playerCamera.orthographicSize++;
		}

		if (Input.GetAxis ("Mouse ScrollWheel") < 0 && Player.instance.playerCamera.orthographicSize != minCamZoom) 
		{
			Player.instance.playerCamera.orthographicSize--;
		}

		if (Input.GetKeyDown (KeyCode.Mouse2) && isFollowingPlayer == false) 
		{
			lastMousePosition = Input.mousePosition;
		}

		if (Input.GetKey (KeyCode.Mouse2) && isFollowingPlayer == false) 
		{
			cameraPanDirection = Input.mousePosition - lastMousePosition;
			transform.Translate (cameraPanDirection.x * camPanSpeed * Time.deltaTime, cameraPanDirection.y * camPanSpeed * Time.deltaTime, 0.0f);
			lastMousePosition = Input.mousePosition; 
		}
	}
}