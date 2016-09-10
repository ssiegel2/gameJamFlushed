using UnityEngine;
using System.Collections;

// Destroys gameobject when touching player
public class DisappearScript : MonoBehaviour {

	public BoxCollider2D player;

	BoxCollider2D thisCollider;


	// Use this for initialization
	void Start () {
		thisCollider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (thisCollider.IsTouching (player)) {
			Destroy (gameObject);
		}
	}
}
