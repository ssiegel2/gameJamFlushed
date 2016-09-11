using UnityEngine;
using System.Collections;

public class AnimationLogic : MonoBehaviour {
	float direction;
	bool move;

	Animator animator;

	// Use this for initialization
	void Start () {
		direction = 0;
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
				animator.Play ("Blank-TopRight");
			} else {
				animator.Play ("Blank-TopRightStill");
			}
		} else if (direction > 67.5 && direction < 112.5) {
			if(move) {
				animator.Play ("Blank-Top");
			} else {
				animator.Play ("Blank-TopStill");
			}
		} else if (direction > 112.5 && direction < 157.5) {
			if(move) {
				animator.Play ("Blank-TopLeft");
			} else {
				animator.Play ("Blank-TopLeftStill");
			}
		} else if (direction > 157.5 && direction < 202.5) {
			if(move) {
				animator.Play ("Blank-Left");
			} else {
				animator.Play ("Blank-LeftStill");
			}
		} else if (direction > 202.5 && direction < 247.5) {
			if(move) {
				animator.Play ("Blank-BottomLeft");
			} else {
				animator.Play ("Blank-BottomLeftStill");
			}
		} else if (direction > 247.5 && direction < 292.5) {
			if(move) {
				animator.Play ("Blank-Bottom");
			} else {
				animator.Play ("Blank-BottomStill");
			}
		} else if (direction > 292.5 && direction < 337.5) {
			if(move) {
				animator.Play ("Blank-BottomRight");
			} else {
				animator.Play ("Blank-BottomRightStill");
			}
		} else if (direction > 337.5 || direction < 22.5) {
			if(move) {
				animator.Play ("Blank-Right");
			} else {
				animator.Play ("Blank-RightStill");
			}
		}
	}
}
