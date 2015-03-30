using UnityEngine;
using System.Collections;

public class BossEnemy : MonoBehaviour {
    
    //Different types of bullets a boss may fire
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;

    //Boss Properties
    public int hp = 1000;
    public int shotInterval = 30;
    public int shotCounter = 0;

    // Boss transition counters
    private int _transitionCounter;
    private int _currentTransition;
    private int _fullHP = 1000;
    private int _counterReset;

    private GameObject _hpBarObject;
    private HPBar _hpBarScript;
    private bool _isPlayerAlive;

    // Use this for initialization
    void Start() {
        //Get the HP Bar
        _hpBarObject = GameObject.Find("HPBar");
        _hpBarScript = _hpBarObject.GetComponent<HPBar>();

        //Initialize transition variables
        _transitionCounter = 3;
        _currentTransition = 1;
        _isPlayerAlive = true;
        _counterReset = shotInterval + 5;
    }

    // Update is called once per frame
    void Update() {
        //Transition if HP hits 0, else destroy the boss
        if (hp <= 0 && _currentTransition <= _transitionCounter) {
            _hpBarScript.EmptyHP();
            _currentTransition++;
            hp = _fullHP;
            _hpBarScript.FillHP();

            //Destroy if last transition is destroyed
            if (_currentTransition > _transitionCounter) {
                Explode();
            }
        }

        //Check if player is alive
        if (GameObject.FindGameObjectWithTag("Player")) {
            _isPlayerAlive = true;
        } else {
            _isPlayerAlive = false;
        }

        //Shoot only when Player is alive
        if (_isPlayerAlive) {
            switch (_currentTransition) {
                case 1:
                    ShotVariation1();
                    break;
                case 2:
                    ShotVariation2();
                    break;
                case 3:
                    ShotVariation3();
                    break;
            }
        }
        
        shotCounter++;
        //Reset if shotcounter goes haywire
        if (shotCounter > _counterReset)
            shotCounter = 0;
    }

    void OnTriggerEnter2D(Collider2D coll) {
        string layerName = LayerMask.LayerToName(coll.gameObject.layer);

        //Destroy the bullet on collision
        if (layerName == "Bullet (Player)") {
            Destroy(coll.gameObject);
            hp -= 5;
            _hpBarScript.ReduceHealth(0.005f);
        }        
    }

    void ShotVariation1() {
        //Shoot Regularly
        if (shotCounter >= shotInterval) {
            Shot(gameObject.transform, 2);
            for (int i = 0; i < transform.childCount; i++) {
                Transform shotpos = transform.GetChild(i);
                Shot(shotpos, 1);
                shotCounter = 0;
            }
        }
    }

    void ShotVariation2() {
        //Burst shots - Shoot for 5 frames
        if (shotCounter >= shotInterval) {
            Shot(gameObject.transform, 2);
            for (int i = 0; i < transform.childCount; i++) {
                Transform shotpos = transform.GetChild(i);
                Shot(shotpos, 1);
            }
        }
    }

    void ShotVariation3() {
        //Hardest Variation
        shotInterval = 15;
        if (shotCounter >= shotInterval) {
            Shot(gameObject.transform, 2);
            Shot(gameObject.transform, 3);
            for (int i = 0; i < transform.childCount; i++) {
                //transform.GetChild(i).Rotate(new Vector3(0, 0, 10));
                Transform shotpos = transform.GetChild(i);
                shotpos.Rotate(new Vector3(0, 0, 10));
                Shot(shotpos, 1);
                shotCounter = 0;
            }
            for (int i = 0; i < transform.childCount; i++) {
                //transform.GetChild(i).Rotate(new Vector3(0, 0, 10));
                Transform shotpos = transform.GetChild(i);
                shotpos.Rotate(new Vector3(0, 0, -10));
                Shot(shotpos, 1);
                shotCounter = 0;
            }
        }
    }

    public void Shot(Transform origin, int num) {
        switch (num) { 
            case 1:
                Instantiate(bullet1, origin.position, origin.rotation);
                break;
            case 2:
                Instantiate(bullet2, origin.position, origin.rotation);
                break;
            case 3:
                Instantiate(bullet3, origin.position, origin.rotation);
                break;
        }
    }

    void Explode() {
        Destroy(_hpBarObject);
        Destroy(gameObject);
    }
}
