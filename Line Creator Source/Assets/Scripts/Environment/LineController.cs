using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineController : MonoBehaviour 
{
	[Header("Line Prefabs")]
	public GameObject solidLine;
	public GameObject hiddenLine;
	public GameObject bouncyLine;
	public GameObject boosterLine;
	public GameObject eraser;

	[Header("Debug")]
	public LineSelection selectedLine;
	public LineRendererController activeLine;
	public Vector2 mousePosition;
	public List<GameObject> lines;

	public enum LineSelection
	{
		solidLine,
		hiddenLine,
		boucnyLine,
		boosterLine
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Mouse0))
		{
			if (selectedLine == LineSelection.solidLine)
			{
				GameObject solidLineInstance = Instantiate (solidLine);
				activeLine = solidLineInstance.GetComponent<LineRendererController> ();
				lines.Add(solidLineInstance);
			}

			if (selectedLine == LineSelection.hiddenLine)
			{
				GameObject hiddenLineInstance = Instantiate (hiddenLine);
				activeLine = hiddenLineInstance.GetComponent<LineRendererController> ();
				lines.Add(hiddenLineInstance);
			}

			if (selectedLine == LineSelection.boucnyLine)
			{
				GameObject bouncyLineInstance = Instantiate (bouncyLine);
				activeLine = bouncyLineInstance.GetComponent<LineRendererController> ();
				lines.Add(bouncyLineInstance);
			}

			if (selectedLine == LineSelection.boosterLine)
			{
				GameObject boosterLineInstance = Instantiate (boosterLine);
				activeLine = boosterLineInstance.GetComponent<LineRendererController> ();
				lines.Add(boosterLineInstance);
			}
		}
		else if (Input.GetKeyUp (KeyCode.Mouse0))
		{
			activeLine = null;
		}

		if (Input.GetKeyDown(KeyCode.Mouse1)) 
		{
			Instantiate(eraser, Player.instance.playerCamera.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			for (int i = 0; i < lines.Count; i++) 
			{
				if (lines.ElementAt (i) != null)
				{
					Destroy(lines.ElementAt(i));
				}	
			}

			lines = new List<GameObject>();
		}

		if (activeLine != null)
		{
			mousePosition = Player.instance.playerCamera.ScreenToWorldPoint (Input.mousePosition);
			activeLine.UpdateLine (mousePosition);
		}
	}

	public void SelectLine (int index)
	{
		if (index == 1)
		{
			selectedLine = LineSelection.solidLine;
		}

		if (index == 2)
		{
			selectedLine = LineSelection.hiddenLine;
		}

		if (index == 3)
		{
			selectedLine = LineSelection.boucnyLine;
		}

		if (index == 4)
		{
			selectedLine = LineSelection.boosterLine;
		}
	}
}