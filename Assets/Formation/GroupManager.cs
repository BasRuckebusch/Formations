using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
	public List<GameObject>[] grouparray = new List<GameObject>[5];
	private Vector3[] groupMiddle = new Vector3[5];

	private Camera camera;
	[SerializeField] private LayerMask ground;

	// Singleton design pattern, only 1 UnitSelection can exist at a time.
	public static GroupManager Instance { get; private set; }
	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this.gameObject);
			Debug.Log("GroupManager already exists");
		}
		else
		{
			Instance = this;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		for (int i = 0; i < grouparray.Length; i++)
		{
			List<GameObject> gameObjects = new List<GameObject>();
			grouparray[i] = gameObjects;
		}
		camera = Camera.main;
	}

	void Update()
	{

		if (UnitSelections.Instance.unitsSelected.Count != 0)
		{
			grouparray[0] = UnitSelections.Instance.unitsSelected;
		}

		if (Input.GetMouseButtonDown(1))
		{
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
			{
				groupMiddle[0] = hit.point;
				Square(0);
			}
		}


		if (Input.GetKeyDown(KeyCode.F1))
		{
			CreateGroup(1);
		}
		if (Input.GetKeyDown(KeyCode.F2))
		{
			CreateGroup(2);
		}
		if (Input.GetKeyDown(KeyCode.F3))
		{
			CreateGroup(3);
		}
		if (Input.GetKeyDown(KeyCode.F4))
		{
			CreateGroup(4);
		}
		if (Input.GetKeyDown(KeyCode.F5))
		{
			CreateGroup(5);
		}

	}

	void CreateGroup(int i)
	{
		grouparray[i] = UnitSelections.Instance.unitsSelected;

		foreach (GameObject unit in grouparray[i])
		{
			Debug.Log(unit.name);
		}
	}

	void Square(int i)
	{
		List<Vector3> squarePos = FormationManager.Instance.Square(groupMiddle[i], grouparray[i].Count, 2.5f);
		int count = 0;
		foreach (GameObject unit in grouparray[i])
		{
			unit.GetComponent<MoveTo>().SetDesitnation(squarePos[count]);
			++count;
		}
	}

}
