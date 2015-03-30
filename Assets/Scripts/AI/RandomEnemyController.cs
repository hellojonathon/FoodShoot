using UnityEngine;
using System.Collections;

public class RandomEnemyController : MonoBehaviour {
    public int hp = 10;
	// Use this for initialization
    void Start() {
        RandMovement();
	}
	
    void Update() {
        if (hp <= 0) {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Bullet") {
            hp -= 20;
        }

        if (coll.gameObject.tag == "Player") {
            hp -= 100;
        }

        if (coll.gameObject.tag == "BottomWall") {
            Destroy(gameObject);
        }
    }

    void RandMovement() {
        Vector2 direction = new Vector2();
        direction.x = Random.value;
        direction.y = Random.value;
        if (Random.value < 0.5)
            direction.x *= -1;

        if (Random.value < 0.5)
            direction.y *= -1;

        rigidbody2D.mass = Random.value * 100;

        //Debug.Log(direction.x + " " + direction.y);
        gameObject.rigidbody2D.AddForce(direction.normalized * 1500);
    }
}
