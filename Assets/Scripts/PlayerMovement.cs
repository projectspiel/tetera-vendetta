using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	
	Vector3 destination;
	int floorMask;
	float camRayLength = 100f;
	float smoothing = 5f;
	float movementPrecision = 0.01f;
	NavMeshAgent navAgent;

	
	void Awake ()
	{
		floorMask = LayerMask.GetMask ("Floor");
		navAgent = GetComponent<NavMeshAgent>();

	}
	
	void FixedUpdate ()
	{
		if (Input.GetAxis ("Fire1") == 1) {
			Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit gridHit;
			if (Physics.Raycast (camRay, out gridHit, camRayLength, floorMask)) {
				destination = gridHit.transform.position;
			}
		}

//		if ((transform.position - destination).magnitude > movementPrecision) {
//			transform.position = Vector3.Lerp (transform.position, destination, smoothing * Time.deltaTime);
//			string foo = (transform.position - destination).magnitude.ToString();
//			Debug.Log(foo);
//		}

		navAgent.SetDestination (destination);
	}
}