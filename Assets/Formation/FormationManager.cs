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


	public List<Vector3> Square(Vector3 middle, int size, float spread, float angle, int formationWidth)
	{
		List<Vector3> postions = new List<Vector3>();

		int width = (int)Mathf.Sqrt(size);
		int height = (int)Mathf.Sqrt(size);
		float rest = size - (width * height);

		if (rest > 0)
		{
			width += (int)Mathf.Ceil(rest / height);
		}

		if (formationWidth != 0)
		{
			width = size/formationWidth;
			height = formationWidth;
			rest = size - (width * height);

			if (rest > 0)
			{
				width += (int)Mathf.Ceil(rest / height);
			}
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

		List<Vector3> rotpos = new List<Vector3>();

		angle = angle + (90 * Mathf.Deg2Rad); // Add 90 deg to make more intuitive
		foreach (var pos in postions)
		{	
			rotpos.Add(RotatePoint(middle, angle, pos));
		}


		return rotpos;
	}

	public List<Vector3> Circle(Vector3 middle, int size, float radius, int rings, float offset, float rotate)
	{
		List<Vector3> postions = new List<Vector3>();

		int unitsPerRing = size / rings;
		float rest = size - (unitsPerRing * rings);
		if (rest > 0)
		{
			unitsPerRing += (int)Mathf.Ceil(rest / rings);
		}

		for (int j = 0; j < rings; j++)
		{
			for (int i = 0; i < unitsPerRing; i++)
			{
				var angle = i * Mathf.PI * 2 / unitsPerRing;

				var x = Mathf.Cos(angle) * radius;
				var z = Mathf.Sin(angle) * radius;
				var pos = new Vector3(x, 0, z);

				postions.Add(pos + middle);
			}
			radius = radius + (j+1) + offset;
		}

		List<Vector3> rotpos = new List<Vector3>();

		foreach (var pos in postions)
		{
			rotpos.Add(RotatePoint(middle, rotate, pos));
		}

		return rotpos;
	}



	private Vector3 RotatePoint(Vector3 mid, float angle, Vector3 p)
	{
		
		float s = Mathf.Sin(angle);
		float c = Mathf.Cos(angle);

		p.x -= mid.x;
		p.z -= mid.z;

		float xnew = p.x * c - p.z * s;
		float ynew = p.x * s + p.z * c;

		p.x = xnew + mid.x;
		p.z = ynew + mid.z;

		return p;
	}

}
