using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveAmount = 20f;
    public float maxSpeed = 5f;
    public float friction = 5f;

    Rigidbody2D rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
    void FixedUpdate(){
        float hMove = Input.GetAxis("Horizontal") * moveAmount;
        float vMove = Input.GetAxis("Vertical") * moveAmount;
        bool noMove = Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0;

        if (!noMove) {
            rigidBody.AddForce(new Vector2(hMove, vMove));
            rigidBody.velocity = new Vector2(Mathf.Clamp(rigidBody.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rigidBody.velocity.y, -maxSpeed, maxSpeed));
        }
        else{
            rigidBody.AddForce(-rigidBody.velocity.normalized * friction);
        }



        Debug.Log(rigidBody.velocity);
    }


	// Update is called once per frame
	void Update () {
	
	}
}
