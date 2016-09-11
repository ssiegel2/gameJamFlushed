using UnityEngine;
using System.Collections;

public class GotoSceneScript : MonoBehaviour {

	BoxCollider2D player;
	
	BoxCollider2D thisCollider;

	public string sceneName;

	// Use this for initialization
	void Start () {
		thisCollider = GetComponent<BoxCollider2D>();
		
		player = GameObject.Find ("player").GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisCollider.IsTouching (player)) {
			Application.LoadLevel(sceneName);
		}
	}
}
