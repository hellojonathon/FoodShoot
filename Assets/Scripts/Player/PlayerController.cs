using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float horizontalSpeed = 10;
    public float verticalSpeed = 5;

    // Bullet
    public GameObject bullet;
    public GameObject altBullet;
    public GameObject arrow;

    //Private Vars
    //private float _speed = 0.1f;
    private int _shotCounter = 0;
    private int _shotPeriod = 10;

    void Start() {
        //Start invincible for 2 seconds
        gameObject.collider2D.enabled = false;
        StartCoroutine(InvincibilityFrames());
    }

    //Add invincibility animation
    IEnumerator InvincibilityFrames() {
        yield return new WaitForSeconds(2);
        gameObject.collider2D.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        //Find the layer of collision
        string layerName = LayerMask.LayerToName(coll.gameObject.layer);

        //Destroy the bullet on collision
        if (layerName == "Bullet (Enemy)") {
            Destroy(coll.gameObject);
        }

        //Explode if layer is bullet or enemy
        if (layerName == "Bullet (Enemy)" || layerName == "Enemy") {
            Destroy(gameObject);
        }
    }

    void Update() {
        // Check for Firing Inputs

        //Shoot Towards Mouse/Touch
        if (Input.GetButtonDown("Fire1") || Input.GetMouseButton(0)) {
            Shoot();
        }

        if (Input.GetButtonDown("Fire2") || Input.GetMouseButton(1)) {
            AlternativeShoot();
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            horizontalSpeed = 3;
            verticalSpeed = 3;
        }
        else {
            horizontalSpeed = 7;
            verticalSpeed = 5;
        }

        // Input Directions
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;

        // Move with restrictions
        Move(direction);
    }

    void Move(Vector2 direction) {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 pos = transform.position;
        pos.x += direction.x * horizontalSpeed * Time.deltaTime;
        pos.y += direction.y * verticalSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        transform.position = pos;
    }

    void Shoot() {
        if (_shotCounter == _shotPeriod) {
            Instantiate(bullet, transform.position, transform.rotation);
            _shotCounter = 0;
        }
        _shotCounter++;

        //Reset variable if it goes out of bounds
        if (_shotCounter > 15)
            _shotCounter = 0;

        _shotCounter++;
    }

    void AlternativeShoot() {
        if (_shotCounter == _shotPeriod) {
            Instantiate(altBullet, transform.position, transform.rotation);
            _shotCounter = 0;
        }

        //Reset variable if it goes out of bounds
        if (_shotCounter > 15)
            _shotCounter = 0;

        _shotCounter++;
    }
}

