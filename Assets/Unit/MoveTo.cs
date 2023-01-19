using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

	// [SerializeField] private Transform goal;
	private NavMeshAgent agent;
	// private new Camera camera;
	// [SerializeField] private LayerMask ground;


	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		//camera = Camera.main;
	}

	void Update()
	{
		//	if (Input.GetMouseButtonDown(1))
		//	{
		//		RaycastHit hit;
		//		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		//		if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
		//		{
		//			agent.SetDestination(hit.point);
		//		}
		//	}
	}

	public void SetDesitnation(Vector3 pos)
	{
		agent.SetDestination(pos);
	}
}
