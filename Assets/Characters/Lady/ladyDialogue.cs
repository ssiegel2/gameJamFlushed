using UnityEngine;
using System.Collections;

public class ladyDialogue : DialogueTest {
	GameStateScript gameState;
	
	string characterName;
	
	void Reprimand1(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue ("What the heck Auggie?! \nWhere have you been?");
		} else if (choice == 1) {
			Current = Reprimand2;
			Current(-1);
		}
	}
	void Reprimand2(int choice) {
		if (choice == -1) {
			conversation.NewMonologue ("I've been waiting here with the doctor for over seven minutes!");
		} else if (choice == 1) {
			Current = Reprimand3;
			Current(-1);
		}
	}
	void Reprimand3(int choice) {
		if (choice == -1) {
			conversation.NewMonologue ("This is your health on the line! \nIf you don't speak with the doctor right the gosh darn now...");
		} else if (choice == 1) {
			Current = Reprimand4;
			Current(-1);
		}
	}
	void Reprimand4(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue ("Oh god.\nI don't even know.");
		} else if (choice == 1) {
			Current = Reprimand5;
			Current(-1);
		}
	}
	void Reprimand5(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue ("Quick!\nSpeak to him!");
		} else if (choice == 1) {
			gameState.IncrementArc();
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

				if (gameState.GetArcState() == 2) {
					Current = Reprimand1;
					Current (-1);
				} else {
					Current = Silence;
					Current (-1);
				}
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
