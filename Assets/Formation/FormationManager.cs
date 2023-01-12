using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationManager : MonoBehaviour
{

	public static FormationManager Instance { get; private set; }
	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this.gameObject);
			Debug.Log("FormationManager already exists");
		}
		else
		{
			Instance = this;
		}
	}

	public List<Vector3> Square(Vector3 middle, int size, float spread) 
	{
		List<Vector3> postions = new List<Vector3>();

		int width = (int)Mathf.Sqrt(size);
		int height = (int)Mathf.Sqrt(size);
		int rest = size - (width * height);

		if (rest > 0)
		{
			width += (int)Mathf.Ceil(width / rest);
		}
		for (int x = 0; x < width; x++)
		{
			for (int z = 0; z < height; z++)
			{
				Vector3 pos = new Vector3(middle.x + x + 1, middle.y, middle.z + z + 1);

				pos *= spread;

				postions.Add(pos);
			}
		}
		
		return postions;
	}

	
}
