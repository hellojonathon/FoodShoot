using UnityEngine;
using System.Collections;

public class EnemyBulletController : MonoBehaviour {

    public int speed = 10;
    private Vector2 _min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    private Vector2 _max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

    void Start() {
        rigidbody2D.velocity = transform.up.normalized * speed;
    }

    void Update() {
        //Destroy the object as it goes out of bounds
        if (transform.position.y > _max.y || transform.position.y < _min.y || transform.position.x > _max.x || transform.position.x < _min.x) {
            Destroy(collider);
            Destroy(gameObject);
        }

        //Destroy if the player is dead
        if (!GameObject.FindGameObjectWithTag("Player")) {
            Destroy(collider);
            Destroy(gameObject);
        }
    }
}
