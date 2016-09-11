using UnityEngine;
using System.Collections;

public class DialogueTransitionScript : MonoBehaviour {

	public string characterName;

	BoxCollider2D player;
	
	BoxCollider2D thisCollider;
	GameStateScript gameState;
	
	
	// Use this for initialization
	void Start () {
		thisCollider = GetComponent<BoxCollider2D>();

		player = GameObject.Find ("player").GetComponent<BoxCollider2D> ();
		gameState = GameObject.Find ("GameState").GetComponent<GameStateScript> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (thisCollider.IsTouching (player)) {
			if (!gameState.Safe () ) {
				gameState.Dialogue();
				gameState.SetInterlocutor(characterName);
			}
		}
	}
}
