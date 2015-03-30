using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
    public int speed = 5;
    private Vector2 _min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    private Vector2 _max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

    // Use this for initialization
    void Start() {
        this.tag = "Bullet";

        // Take mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Rotate object towards mouse position
        Quaternion rot = Quaternion.LookRotation(mousePosition - transform.position, transform.TransformDirection(Vector3.forward));
        transform.rotation = new Quaternion(0, 0, rot.z, rot.w);

        // Fire straight
        rigidbody2D.velocity = -(transform.up.normalized * speed);
    }

    //Destroy on Collision
    //todo: add animations
    void OnCollisionEnter2D(Collision2D coll) {
        //Destroy(collider);
        Destroy(gameObject);
    }

    void Update() {
        //Destroy the object as it goes out of bounds
        if (transform.position.y > _max.y || transform.position.y < _min.y || transform.position.x > _max.x || transform.position.x < _min.x) {
            Destroy(collider);
            Destroy(gameObject);
        }
    }
}
