using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
	public List<GameObject> unitlist = new List<GameObject>();
	public List<GameObject> unitsSelected = new List<GameObject>();
	

	// Singleton design pattern, only 1 UnitSelection can exist at a time.
	public static UnitSelections Instance { get; private set; }
	private void Awake()
	{
		if (Instance != null && Instance != this)
		{ 
			Destroy(this.gameObject);
			Debug.Log("UnitSelections already exists");
		}
		else
		{
			Instance = this;
		}
	}

	public void Select(GameObject unit)
	{
		DeselectAll();
		unitsSelected.Add(unit);
		EnableUnit(unit);
	}

	public void ShiftSelect(GameObject unit)
	{
		if (!unitsSelected.Contains(unit))
		{
			unitsSelected.Add(unit);
			EnableUnit(unit);
			
		}
		else
		{
			DisableUnit(unit);
			unitsSelected.Remove(unit);
		}

	}
	public void DragSelect(GameObject unit)
	{
		if (!unitsSelected.Contains(unit))
		{
			unitsSelected.Add(unit);
			EnableUnit(unit);
		}
	}

	public void DeselectAll()
	{
		foreach (GameObject unit in unitsSelected)
		{
			DisableUnit(unit);
		}

		unitsSelected.Clear();
	}

	private void EnableUnit(GameObject unit)
	{
		unit.transform.GetChild(0).gameObject.SetActive(true);
		unit.GetComponent<MoveTo>().enabled = true;
	}

	private void DisableUnit(GameObject unit)
	{
		unit.transform.GetChild(0).gameObject.SetActive(false);
		unit.GetComponent<MoveTo>().enabled = false;
	}

}
