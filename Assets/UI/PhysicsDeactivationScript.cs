using UnityEngine;
using System.Collections;

// Add this to every rigidbody so that it will stop moving when in dialogue mode
public class PhysicsDeactivationScript : MonoBehaviour {

	GameStateScript gameState;
	Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		gameState = GameObject.Find ("GameState").GetComponent<GameStateScript> ();
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameState.CurrentState() == "Dialogue") {
			rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
		} else if (gameState.CurrentState() == "Overworld") {
			rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
		}
	}
}
