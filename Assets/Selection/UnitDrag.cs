using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDrag : MonoBehaviour
{


	private new Camera camera;
	[SerializeField] private RectTransform visual;

	private Rect selection;
	private Vector2 startPos = Vector2.zero;
	private Vector2 endPos = Vector2.zero;



	void Start()
	{
		camera = Camera.main;
		DrawVisual();
	}

	
	void Update()
	{
		//Drag mouse
		if (Input.GetMouseButtonDown(0))
		{
			startPos = Input.mousePosition;
			selection = new Rect();
		}

		if (Input.GetMouseButton(0))
		{
			endPos = Input.mousePosition;
			DrawVisual();
			DrawSelection();
		}

		if (Input.GetMouseButtonUp(0))
		{
			SelectUnits();
			startPos = Vector2.zero;
			endPos = Vector2.zero;
			DrawVisual();
		}
	}
	void DrawVisual()
	{
		Vector2 center = (startPos + endPos)/2;
		visual.position = center;

		Vector2 size = new Vector2(Mathf.Abs(startPos.x - endPos.x), Mathf.Abs(startPos.y - endPos.y));
		visual.sizeDelta = size;
	}
	void DrawSelection()
	{
		// Drag left or right
		if (Input.mousePosition.x < startPos.x)
		{
			selection.xMin = Input.mousePosition.x;
			selection.xMax = startPos.x;
		}
		else
		{
			selection.xMin = startPos.x;
			selection.xMax = Input.mousePosition.x;
		}

		// Drag down or up
		if (Input.mousePosition.y < startPos.y)
		{
			selection.yMin = Input.mousePosition.y;
			selection.yMax = startPos.y;
		}
		else
		{
			selection.yMin = startPos.y;
			selection.yMax = Input.mousePosition.y;
		}

	}
	void SelectUnits()
	{
		// Check which units are inside selection
		foreach (GameObject unit in UnitSelections.Instance.unitlist)
		{
			// convers unit to screenpoint, check if point is inside selection
			if (selection.Contains(camera.WorldToScreenPoint(unit.transform.position)))
			{
				UnitSelections.Instance.DragSelect(unit);
			}
		}
	}
}
