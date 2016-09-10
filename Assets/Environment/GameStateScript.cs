using UnityEngine;
using System.Collections;

public class GameStateScript : MonoBehaviour {
	public float lengthOfSafety;
	private string gameState;
	private float timer;

	// Use this for initialization
	void Start () {
		gameState = "Overworld";
	}

	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer -= Time.deltaTime;
		}
	}

	public void Overworld() {
		gameState = "Overworld";
		timer = lengthOfSafety;
	}

	public void Dialogue() {
		if (timer <= 0) {
			gameState = "Dialogue";
		}
	}

	public string CurrentState() {
		return gameState;
	}

	public bool Safe() {
		return timer > 0;
	}
	
}
