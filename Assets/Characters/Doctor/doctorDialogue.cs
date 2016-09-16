using UnityEngine;
using System.Collections;

public class doctorDialogue : DialogueTest {
	GameStateScript gameState;

	public Texture secondaryPortrait;
	
	string characterName;
	
	void Hello1(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue ("Hello, Auggie");
		} else if (choice == 1) {
			Current = Hello2;
			Current(-1);
		}
	}
	void Hello2(int choice) {
		if (choice == -1) {
			conversation.NewMonologue ("You do remember our appointment together at the hospital today, don't you?");
		} else if (choice == 1) {
			Current = Hello3;
			Current(-1);
		}
	}
	void Hello3(int choice) {
		if (choice == -1) {
			conversation.NewMonologue ("I hope very much you'll be able to make it.");
		} else if (choice == 1) {
			gameState.IncrementArc();
			gameState.Overworld();
			gameState.SetMusicState ("None");
		}
	}

	void Prognosis1(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue ("Hello again, Auggie\nIt's very good that you've come to see me.");
		} else if (choice == 1) {
			Current = Prognosis2;
			Current(-1);
		}
	}
	void Prognosis2(int choice) {
		if (choice == -1) {
			conversation.NewMonologue ("Your condition, it seems, has gone critical.");
		} else if (choice == 1) {
			Current = Prognosis3;
			Current(-1);
		}
	}
	void Prognosis3(int choice) {
		if (choice == -1) {
			conversation.NewMonologue ("That is to say, we are dealing with something very serious");
		} else if (choice == 1) {
			Current = Prognosis4;
			Current(-1);
		}
	}
	void Prognosis4(int choice) {
		if (choice == -1) {
			conversation.NewMonologue ("There is no easy way to say this, so I'll be brief.");
		} else if (choice == 1) {
			Current = Prognosis5;
			Current(-1);
		}
	}
	void Prognosis5(int choice) {
		if (choice == -1) {
			conversation.NewMonologue ("");
		} else if (choice == 1) {
			Current = Prognosis6;
			Current(-1);
		}
	}
	void Prognosis6(int choice) {
		if (choice == -1) {
			conversation.NewMonologue ("Auggie,\nYou're going bald.");
		} else if (choice == 1) {
			Current = Prognosis7;
			Current(-1);
		}
	}
	void Prognosis7(int choice) {
		if (choice == -1) {
			conversation.SetPortrait(secondaryPortrait);
			conversation.NewMonologue ("Oh god!");
		} else if (choice == 1) {
			Current = Prognosis8;
			Current(-1);
		}
	}
	void Prognosis8(int choice) {
		if (choice == -1) {
			/* Change portrait back to doctor's */
			conversation.SetPortrait(portrait);
			conversation.NewMonologue ("We'll need to operate immediately.");
		} else if (choice == 1) {
			if (gameState.GetArcState() == 2) {
				gameState.IncrementArc();
				gameState.IncrementArc();
			} else {
				gameState.IncrementArc();
			}
			Application.LoadLevel("end");
		}
	}

	void Silence(int choice) {
		if (choice == -1) {
			monologue = true;
			conversation.NewMonologue ("");
		} else if (choice == 1) {
			gameState.Overworld ();
			gameState.SetMusicState ("None");
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
				if (gameState.GetArcState () < 2) {
					gameState.SetMusicState ("None");
					Debug.Log ("hello");
				} else if (gameState.GetArcState () >= 2) {
					gameState.SetMusicState ("Siren");
				}
				
				if (gameState.GetArcState() == 0) {
					Current = Hello1;
					Current(-1);

				} else if (gameState.GetArcState() == 2 || gameState.GetArcState () == 3) {
					Current = Prognosis1;
					Current(-1);
				} else {
					Current = Silence;
					Current(-1);
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
