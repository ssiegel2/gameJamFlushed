using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveAmount = 20f;
    public float maxSpeed = 5f;

    Rigidbody2D rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(new Vector2(0, moveAmount));
	}
	
    void FixedUpdate(){
        float hMove = Input.GetAxis("Horizontal") * moveAmount;
        float vMove = Input.GetAxis("Vertical") * moveAmount;

        rigidBody.AddForce(new Vector2(Mathf.Clamp(hMove, -maxSpeed, maxSpeed), Mathf.Clamp(vMove, -maxSpeed, maxSpeed)));


        Debug.Log(rigidBody.velocity);
    }


	// Update is called once per frame
	void Update () {
	
	}
}
