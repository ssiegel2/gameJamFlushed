using UnityEngine;
using System.Collections;

public class StunScript : MonoBehaviour {

	private float timer;
	public float stunLength = 1f;

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (timer > 0) {
			timer -= Time.deltaTime;
		}

	}

	public void Stun() {
		timer = stunLength;
	}

	public bool isStunned() {
		return timer > 0;
	}
}
