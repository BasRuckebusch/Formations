using UnityEngine;

public class UnitClick : MonoBehaviour
{

	private new Camera camera;

	[SerializeField] private LayerMask clickable;
	[SerializeField] private LayerMask UI;

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
			else if (Physics.Raycast(ray, out hit, Mathf.Infinity, UI))
			{
				Debug.Log("UI");
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
