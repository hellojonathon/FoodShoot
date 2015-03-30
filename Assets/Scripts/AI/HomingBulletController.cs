using UnityEngine;
using System.Collections;

public class HomingBulletController : MonoBehaviour {
    public int speed = 5;

    //Screen Points
    private Vector2 _min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    private Vector2 _max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

	// Use this for initialization
	void Start () {
        //Find the player and move bullet towards him
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) {
            rigidbody2D.velocity = player.transform.position.normalized * speed;
            if (rigidbody2D.velocity == new Vector2(0, 0)) {
                rigidbody2D.velocity = transform.up.normalized * speed;
            }
        } else {
            Destroy(gameObject);
        }
	}

    void Update() {
        //Destroy the object as it goes out of bounds
        if (transform.position.y > _max.y || transform.position.y < _min.y || transform.position.x > _max.x || transform.position.x < _min.x) {
            Destroy(collider);
            Destroy(gameObject);
        }

        //Destroy if the player is dead
        if (GameObject.FindGameObjectWithTag("Player") == null) {
            Explode();
        }
    }

    // Plays explosion animation and destroys the object
    //todo: finish animation
    void Explode() {
        Destroy(gameObject);
    }
}
