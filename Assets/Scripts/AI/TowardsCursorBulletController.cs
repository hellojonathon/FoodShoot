using UnityEngine;
using System.Collections;

public class TowardsCursorBulletController : MonoBehaviour {
    public int speed = 5;

    //Screen Points
    private Vector2 _min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
    private Vector2 _max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

    // Use this for initialization
    void Start() {
        //Find the player's status
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
        
        // Take mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Rotate object towards mouse position
        Quaternion rot = Quaternion.LookRotation(mousePosition - transform.position, transform.TransformDirection(Vector3.forward));
        transform.rotation = new Quaternion(0, 0, rot.z, rot.w);

        //Fire towards it if player is available
        if (player != null) {
            rigidbody2D.velocity = -(transform.up.normalized * speed);
        }
        else {
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
