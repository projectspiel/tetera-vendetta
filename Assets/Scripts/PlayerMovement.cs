using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	
	Vector3 movement;
	int floorMask;
	float camRayLength = 100f;
	float smoothing = 5f;
	
	void Awake ()
	{
		floorMask = LayerMask.GetMask ("Floor");
	}
	
	
	void FixedUpdate ()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		
		if (Input.GetAxis ("Fire1") == 1 && Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			transform.position = Vector3.Lerp (transform.position, floorHit.point, smoothing * Time.deltaTime);
		}
			
	}
}