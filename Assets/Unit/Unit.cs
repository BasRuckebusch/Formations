using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    void Start()
    {
        UnitSelections.Instance.unitlist.Add(gameObject);
	}

    void OnDestroy()
    {
		UnitSelections.Instance.unitlist.Remove(gameObject);
	}
}
