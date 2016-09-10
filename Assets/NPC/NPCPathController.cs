using UnityEngine;
using System.Collections;

public class NPCPathController : MonoBehaviour {

    public float travelDist = 2f;
    public float moveSpeed = 2f;

    Vector2 startPos;
    Vector2 endPos;

    float startTime;

	// Use this for initialization
	void Start () {
        startPos = new Vector2(transform.position.x, transform.position.y + travelDist);
        endPos = new Vector2(transform.position.x, transform.position.y - travelDist);
        transform.position = startPos;
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        float distCovered = Mathf.PingPong((Time.time - startTime) * moveSpeed, 1);
        float fracJourney = (distCovered / travelDist*2);
        transform.position = Vector2.Lerp(startPos, endPos, fracJourney);


	}
}
