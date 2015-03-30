using UnityEngine;
using System.Collections;

//Require RigidBody2D Component
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyShip : MonoBehaviour {
    public float speed;
    public float shotDelay;
    public GameObject bullet;
    public bool canShoot;
    public GameObject explosion;

    public void Explosion() {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    public void Shot(Transform origin) {
        Instantiate(bullet, origin.position, origin.rotation);
    }

    public void Move(Vector2 direction) {
        rigidbody2D.velocity = direction * speed;
    }
}
