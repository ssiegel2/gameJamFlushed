using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 20f;

    Rigidbody2D rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(new Vector2(0, moveSpeed));
	}
	
    void FixedUpdate(){
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        rigidBody.AddForce(new Vector2(hMove * moveSpeed, vMove * moveSpeed));

        
    }


	// Update is called once per frame
	void Update () {
	
	}
}
