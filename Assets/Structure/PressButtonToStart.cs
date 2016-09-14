using UnityEngine;
using System.Collections;

public class PressButtonToStart : MonoBehaviour {

	public string destination;

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Application.LoadLevel(destination);
		}
	}
}
