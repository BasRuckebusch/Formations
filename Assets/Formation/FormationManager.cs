using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
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
		float rest = size - (width * height);

		if (rest > 0)
		{
			width += (int)Mathf.Ceil(rest / height);
		}

		Vector3 mid = new Vector3(middle.x - (float)(((width) / 2) * spread), middle.y, middle.z - (float)(((height) / 2) * spread));
		if (width % 2 == 0)
		{
			mid.x += 0.5f * spread;
		}
		if (height % 2 == 0)
		{
			mid.z += 0.5f * spread;
		}


		for (int x = 0; x < width; x++)
		{
			for (int z = 0; z < height; z++)
			{
				Vector3 pos = new Vector3(mid.x + x*spread, mid.y, mid.z + z*spread);

				postions.Add(pos);
			}
		}

		return postions;
	}

	public List<Vector3> Circle(Vector3 middle, int size)
	{
		List<Vector3> postions = new List<Vector3>();

		for (int i = 0; i < size; i++)
		{
			var angle = i * Mathf.PI * 2 / size;

			var x = Mathf.Cos(angle) * i;
			var z = Mathf.Sin(angle) * i;
			var pos = new Vector3(x, 0, z);

			postions.Add(pos);
		}

		return postions;
	}

}
