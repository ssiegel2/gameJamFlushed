using UnityEngine;
using System.Collections;

public class BuddyScript : DialogueTest {
	GameStateScript gameState;
	
	string characterName;
	
	void Hello1(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue ("Auggie!");
		} else if (choice == 1) {
			Current = Hello2;
			Current(-1);
		}
	}
	void Hello2(int choice) {
		if (choice == -1) {
			conversation.NewMonologue ("That girl you're always hanging out with was looking for you earlier.");
		} else if (choice == 1) {
			gameState.Overworld();
		}
	}

	
	void Silence(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue ("");
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
				gameState.SetMusicState ("Dialogue");
				
				/* LOGIC GOES HERE! FOR NOW: GO TO THE ONLY DECISION */

				Current = Hello1;
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
