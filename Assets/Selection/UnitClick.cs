using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{

	private new Camera camera;

	[SerializeField] private LayerMask clickable;

	void Start()
	{
		camera = Camera.main;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable)) 
			{
				if (Input.GetKey(KeyCode.LeftShift))
				{
					UnitSelections.Instance.ShiftSelect(hit.collider.gameObject);
				}
				else
				{
					UnitSelections.Instance.Select(hit.collider.gameObject);
				}
			}
			else
			{
				if (!Input.GetKey(KeyCode.LeftShift))
				{
					UnitSelections.Instance.DeselectAll();
				}
			}
		}
	}
}
