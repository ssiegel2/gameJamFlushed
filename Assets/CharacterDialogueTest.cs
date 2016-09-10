using UnityEngine;
using System.Collections;

public class CharacterDialogueTest : DialogueTest {

	void Decision1(int choice) {
		if (choice == -1) {
			conversation.NewChoice ("How are you?", "I'm great!", "I'm ok", "Oh Christ");
		} else if (choice == 1) {
			Current = Decision2;
			Current(-1);
		} else if (choice == 2) {
			Current = Decision3;
			Current(-1);
		}
	}
	
	void Decision2(int choice) {
		if (choice == -1) {
			conversation.NewChoice ("Fantastic. When's the last time you peed?",
			                        "Ten minutes ago",
			                        "Not in a long, long time",
			                        "I'm doing it right now!");
		}
	}
	
	void Decision3(int choice) {
		if (choice == -1) {
			conversation.NewChoice ("Why are you OK?",
			                        "I'm always OK",
			                        "I've forgotten how to do anything else",
			                        "");
		}
	}

	// Use this for initialization
	// Call Initialize first, set current to the base of the current dialogue tree,
	// Then call Current(-1) to start
	void Start () {
		Initialize ();
		Current = Decision1;
		Current (-1);
	}
	
	// Update is called once per frame
	void Update () {
		Current (GetChoice ());
	}
}
