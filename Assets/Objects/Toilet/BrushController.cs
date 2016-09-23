using UnityEngine;
using System.Collections;

public class BrushController : MonoBehaviour {

    Rigidbody2D rigidBody;
    public float moveSpeed = 10f;
    public float rotateSpeed = 10f;

    bool rotating = true;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
    void FixedUpdate () {

        if (rotating) {
            transform.Rotate(new Vector3(0, 0, 1), Time.deltaTime * rotateSpeed);
            Vector2 forceToAdd = transform.rotation * -Vector2.up * (moveSpeed);

            rigidBody.AddForce(transform.rotation * -Vector2.up * moveSpeed);
        }
        else {
            rigidBody.AddForce(transform.rotation * Vector2.up * moveSpeed);
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) {
            rotating = !rotating;
        }
	}
}
