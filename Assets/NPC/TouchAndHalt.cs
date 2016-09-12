using UnityEngine;
using System.Collections;

public class TouchAndHalt : MonoBehaviour {
	BoxCollider2D player;
	
	BoxCollider2D thisCollider;

	public float haltLength = 2.5f;
	private float timer;

	StunScript playerStun;
	
	// Use this for initialization
	void Start () {
		thisCollider = GetComponent<BoxCollider2D>();

		playerStun = GameObject.Find ("player").GetComponent<StunScript> ();
		
		player = GameObject.Find ("player").GetComponent<BoxCollider2D> ();

		timer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (thisCollider.IsTouching (player)) {
			timer = haltLength;
			playerStun.Stun ();
		}

		if (timer > 0) {
			timer -= Time.deltaTime;
		}
	}

	public bool isHalted() {
		return timer > 0;
	}
}
