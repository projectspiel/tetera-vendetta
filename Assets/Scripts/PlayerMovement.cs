using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;            // The speed that the player will move at.
	
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
	float camRayLength = 100f;          // The length of the ray from the camera into the scene.
	
	void Awake ()
	{
		Debug.Log ("Awake");
		// Create a layer mask for the floor layer.
		floorMask = LayerMask.GetMask ("Floor");

		playerRigidbody = GetComponent <Rigidbody> ();
	}
	
	
	void FixedUpdate ()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		float smoothing = 5f;
		
		if (Input.GetAxis ("Fire1") == 1 && Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			Debug.Log ("Hit");
//			Vector3 playerToMouse = floorHit.point - transform.position;			
//			playerToMouse.y = 0f;
			transform.position = Vector3.Lerp (transform.position, floorHit.point, smoothing * Time.deltaTime);
//			movement = movement.normalized * speed * Time.deltaTime;
//			playerRigidbody.MovePosition (transform.position + movement);
		}
			
	}
}