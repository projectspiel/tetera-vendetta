using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

	void Awake () {
		transform.rotation = Camera.main.transform.rotation;
	}
}
