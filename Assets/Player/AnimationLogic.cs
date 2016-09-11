using UnityEngine;
using System.Collections;

public class AnimationLogic : MonoBehaviour {
	public float direction = 270;
	bool move;

	Animator animator;

	// Use this for initialization
	void Start () {
		move = false;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			move = true;
			direction = Mathf.Rad2Deg * Mathf.Atan2 (Input.GetAxis ("Vertical"), Input.GetAxis ("Horizontal"));

			if (direction < 0) { // Ensure direction is positive
				direction += 360;
			}
		} else {
			move = false;
		}


		if (direction > 22.5 && direction < 67.5) {
			if(move) {
				animator.Play ("Auggie-TopRight");
			} else {
				animator.Play ("Auggie-TopRightStill");
			}
		} else if (direction > 67.5 && direction < 112.5) {
			if(move) {
				animator.Play ("Auggie-Top");
			} else {
				animator.Play ("Auggie-TopStill");
			}
		} else if (direction > 112.5 && direction < 157.5) {
			if(move) {
				animator.Play ("Auggie-TopLeft");
			} else {
				animator.Play ("Auggie-TopLeftStill");
			}
		} else if (direction > 157.5 && direction < 202.5) {
			if(move) {
				animator.Play ("Auggie-Left");
			} else {
				animator.Play ("Auggie-LeftStill");
			}
		} else if (direction > 202.5 && direction < 247.5) {
			if(move) {
				animator.Play ("Auggie-BottomLeft");
			} else {
				animator.Play ("Auggie-BottomLeftStill");
			}
		} else if (direction > 247.5 && direction < 292.5) {
			if(move) {
				animator.Play ("Auggie-Bottom");
			} else {
				animator.Play ("Auggie-BottomStill");
			}
		} else if (direction > 292.5 && direction < 337.5) {
			if(move) {
				animator.Play ("Auggie-BottomRight");
			} else {
				animator.Play ("Auggie-BottomRightStill");
			}
		} else if (direction > 337.5 || direction < 22.5) {
			if(move) {
				animator.Play ("Auggie-Right");
			} else {
				animator.Play ("Auggie-RightStill");
			}
		}
	}
}
