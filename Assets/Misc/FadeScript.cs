using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour {
	float timer;
	bool fade;
	public float speed;
	SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		fade = false;
		timer = 0;
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (fade) {
			if (timer <= 0 && sprite.color.a < 255) {
				Color temp = sprite.color;
				temp.a++;
				sprite.color = temp;
				timer = 1;
			}
			else {
				timer -= Time.deltaTime * speed;
			}
		}
		transform.position = GameObject.Find ("Camera").transform.position;
	}

	public void Fade() {
		fade = true;
	}
}
