using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour {
    public GameObject enemy;

    private bool _spawning = false;
    private int _spawnTimer = 5;

	// Use this for initialization
	void Start () {
        StartSpawning();
	}
	
	// Update is called once per frame
	void Update () {
        if (_spawning) {
            //if Activated, spawn every 120 frames
            if (_spawnTimer == 5)
                SpawnEnemy(5);
            _spawnTimer++;

            if (_spawnTimer > 240)
                _spawnTimer = 0;
        }
	}

    void StopSpwaning() {
        _spawning = false;
    }

    void StartSpawning() {
        _spawning = true;
    }

    void SpawnEnemy(int amount) {
        for (int i = 0; i < amount; i++ )
            Instantiate(enemy, transform.position, transform.rotation);
    }
}
