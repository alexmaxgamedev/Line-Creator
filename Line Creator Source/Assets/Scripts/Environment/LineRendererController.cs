using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class LineRendererController : MonoBehaviour 
{
	public LineRenderer LineRenderer;
	public EdgeCollider2D EdgeCollider;

	private List<Vector2> points;

	public void UpdateLine (Vector2 mousePosition)
	{
		if (points == null)
		{
			points = new List<Vector2>();
			SetPoint(mousePosition);
			return;
		}

		if (Vector2.Distance (points.Last (), mousePosition) > 0.01f) 
		{ 
			SetPoint (mousePosition); 
		}
	}

	void SetPoint (Vector2 point)
	{
		points.Add(point);
		LineRenderer.positionCount = points.Count;
		LineRenderer.SetPosition(points.Count - 1, point);

		if (points.Count > 1) 
		{ 
			EdgeCollider.points = points.ToArray (); 
		}
	}
}