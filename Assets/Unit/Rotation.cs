using UnityEngine;

public class Rotation : MonoBehaviour
{
	void FixedUpdate()
    {
		transform.Rotate(0.0f, 0.0f, 0.5f, Space.Self);
	}
}
