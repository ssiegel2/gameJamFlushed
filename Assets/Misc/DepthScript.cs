using UnityEngine;
using System.Collections;


// Z value will float between the intial Z + .5 and the inital Z - .5 depending on x
// That way objects that are higher up will appear to be behind objects that are lower
public class DepthScript : MonoBehaviour {
	public float maxYMagnitude = 15;

	float zScaler;
	float initialZ;

	// Use this for initialization
	void Start () {
		zScaler = 1 / (2 * maxYMagnitude);

		initialZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x,
		                                 transform.position.y,
		                                 transform.position.y * zScaler + initialZ);
	}
}
