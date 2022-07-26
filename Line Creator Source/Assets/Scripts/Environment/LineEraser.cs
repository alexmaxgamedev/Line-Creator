using UnityEngine;

public class LineEraser : MonoBehaviour 
{
	public float eraserDestroyTime = 8.0f;

	void Update()
	{
		Destroy (gameObject, eraserDestroyTime);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Line") 
		{
			Destroy (col.gameObject);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Line") 
		{
			Destroy (col.gameObject);
			Destroy (gameObject);
		}
	}
}