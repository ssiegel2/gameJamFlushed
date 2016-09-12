using UnityEngine;
using System.Collections;

public class NPCAnimationController : MonoBehaviour {
	float direction;
	bool move;
	Vector2 prevPosition;
	
	Animator animator;
	
	// Use this for initialization
	void Start () {
		direction = 0;
		move = false;
		prevPosition = new Vector2 (transform.position.x, transform.position.y);
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 diff = new Vector2 (transform.position.x - prevPosition.x,
		                            transform.position.y - prevPosition.y);
		if (diff.magnitude != 0) {
			direction = Mathf.Atan2 (diff.y, diff.x);
			direction *= Mathf.Rad2Deg;
			if (direction < 0) {
				direction += 360;
			}
			move = true;
			prevPosition = new Vector2 (transform.position.x, transform.position.y);
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
