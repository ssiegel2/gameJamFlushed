using UnityEngine;
using System.Collections;

public class ConditionalGotoSceneScript : MonoBehaviour {
	GameStateScript gameState;

	BoxCollider2D player;
	
	BoxCollider2D thisCollider;
	
	public string sceneName;
	public int requiredState = 2;
	
	// Use this for initialization
	void Start () {
		thisCollider = GetComponent<BoxCollider2D>();
		gameState = GameObject.Find ("GameState").GetComponent<GameStateScript> ();
		player = GameObject.Find ("player").GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisCollider.IsTouching (player) && gameState.GetArcState() == requiredState) {
			Application.LoadLevel(sceneName);
		}
	}
}
