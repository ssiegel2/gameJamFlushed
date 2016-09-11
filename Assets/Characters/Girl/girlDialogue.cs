using UnityEngine;
using System.Collections;

public class girlDialogue : DialogueTest {
	GameStateScript gameState;
	
	string characterName;
	
	void Health1(int choice) {
		if (choice == -1) {
			conversation.NewChoice ("How are you? How are you? How are you? How are you? How are you?\n How are you? How are you? How are you?",
			                        "Bye",
			                        "BYE!!!",
			                        "");
		} else if (choice == 1) {
			gameState.Overworld ();
		} else if (choice == 2) {
			gameState.Overworld ();
		}
	}
	
	// Use this for initialization
	// Call Initialize first, set current to the base of the current dialogue tree,
	// Then call Current(-1) to start
	void Start () {
		//initiated = false;
		gameState = GameObject.Find ("GameState").GetComponent<GameStateScript> ();
		characterName = GetComponent<DialogueTransitionScript> ().characterName;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameState.CurrentState () == "Dialogue" && initiated != true) {
			if (gameState.GetInterlocutor() == characterName) {
				// Logic can be added here for which dialogue tree to start from
				Initialize ();
				Current = Health1;
				Current (-1);
			}
		}
		if (gameState.CurrentState () == "Overworld" && initiated == true) {
			initiated = false;
		}
		if (initiated == true) {
			Current (GetChoice ());
		}
	}
}
