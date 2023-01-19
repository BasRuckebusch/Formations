using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	Camera camera = new Camera();

	void Start()
	{
		camera = Camera.main;
	}
	void Update()
	{
		Vector3 direction = new Vector3();

		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Z)) direction.z = +1f;
		if (Input.GetKey(KeyCode.S)) direction.z = -1f;
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q)) direction.x = -1f;
		if (Input.GetKey(KeyCode.D)) direction.x = +1f;

		Vector3 move = transform.up * direction.z + transform.right * direction.x;

		float speed = 50f;

		transform.position += move * speed * Time.deltaTime;

		if (Input.mouseScrollDelta.y > 0 && camera.orthographicSize < 200)
		{

			camera.orthographicSize += 2;
		}
		else if (Input.mouseScrollDelta.y < 0 && camera.orthographicSize > 5)
		{
			camera.orthographicSize -= 2;
		}
	}
}
