using UnityEngine;
using System.Collections;

// The way to use this is to create a new class that inherits from this one, create a
// bunch of private methods that take int choice as an argument and which are series of if 
// statements for what to do with each choice. The choice index -1 indicates that the decision
// should initialize and call DisplayDialogueScript.NewChoice in order to update the GUI.
// There can be logic in the if statements and global values (e.g. affection points) can be
// modified from there.

public class DialogueTest : MonoBehaviour {
	protected DisplayDialogueScript conversation;

	// Inputting -1 into choice initializes the decision; 1, 2, 3 cause
	// the proper response to the choice
	protected delegate void DecisionDelegate (int choice);
	protected DecisionDelegate Current;

	// Use this for initialization
	protected void Initialize () {
		GameObject go = GameObject.Find("UIObject");
		conversation = (DisplayDialogueScript) go.GetComponent(typeof(DisplayDialogueScript));
	}

	// This function returns what choice the player chooses
	protected int GetChoice () {
		// Player must hold down direction and press fire key to choose
		if (Input.GetButton ("Fire1")) {
			if (Input.GetAxis ("Horizontal") < -0.1f) {
				return 1;
			} else if (Input.GetAxis ("Horizontal") > 0.1f) {
				return 2;
			} else if (Input.GetAxis ("Vertical") < -0.1f) {
				return 3;
			}
		}
		return 0;
	}

	// Update is called once per frame
	// Sends input to Current decision
	void Update () {
		Debug.Log (Current);
		Current (GetChoice ());
	}


}
