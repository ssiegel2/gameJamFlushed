using UnityEngine;
using System.Collections;

public class dialogueTemplate : DialogueTest {
	GameStateScript gameState;
	
	string characterName;
	
	void Decision1(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue ("How are you? How are you? How are you? How are you? How are you?\n How are you? How are you? How are you?");
		} else if (choice == 1) {
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

				/* LOGIC GOES HERE! FOR NOW: GO TO THE ONLY DECISION */


				Current = Decision1;
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
