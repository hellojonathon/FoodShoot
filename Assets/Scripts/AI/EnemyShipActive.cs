using UnityEngine;
using System.Collections;

public class EnemyShipActive : MonoBehaviour {
    EnemyShip ship;

    public int hp = 100;
    public int shotInterval = 15;
    public int shotCounter = 0;
	// Use this for initialization
	void Start () {
        ship = GetComponent<EnemyShip>();
        //ship.Move(transform.up * -1);
	}
	
	// Update is called once per frame
    void Update() {
        if (hp <= 0) {
            Destroy(gameObject);
        }
        if (shotCounter == shotInterval) {
            for (int i = 0; i < transform.childCount; i++) {
                Transform shotpos = transform.GetChild(i);
                ship.Shot(shotpos);
                shotCounter = 0;
            }
        }
        shotCounter++;
    }
}
