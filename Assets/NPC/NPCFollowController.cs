using UnityEngine;
using System.Collections;

public class NPCFollowController : MonoBehaviour {

    public float moveSpeed = 2f;
    public float sightRadius = 3f;

    bool followingPlayer = false;

    GameObject player;
    CircleCollider2D circle;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");

        circle = GetComponent<CircleCollider2D>();
        circle.radius = sightRadius;

	}
	
	// Update is called once per frame
	void Update () {
        //npc follows player if in range
        if (followingPlayer) {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        }
	}

    //checks if the player is within the npc's sight
    void OnTriggerEnter2D(Collider2D coll){
        followingPlayer = coll.gameObject.name == "player";
    }

    void OnTriggerExit2D(Collider2D coll) {
        followingPlayer = false;
    }
}
