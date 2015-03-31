using UnityEngine;
using System.Collections;

public class BossFightManager : MonoBehaviour  {
    public GameObject player;

    // GUI Sizes
    public Vector2 pos = new Vector2(20,40);
    public Vector2 size = new Vector2(60, 20);
    public int lifeCount = 3;

    // Level Flags
    private bool _fightEnd;
    private bool _playerDead;
    private bool _isWaiting = false;

	// Use this for initialization
	void Start () {
        Instantiate(player, new Vector3(0, 0, -3f), transform.rotation);
        _playerDead = false;
        _fightEnd = false;
        _isWaiting = false;
	}
	
	// Update is called once per frame
	void Update () {
        //if Player is destroyed
        if (!GameObject.FindGameObjectWithTag("Player")) {
            _playerDead = true;
        }

        //if Player is dead
        if (_playerDead) {
            //End game when lives are gone
            if (lifeCount <= 0) {
                GameEnd();
            } else {
                //Respawn player after 3 seconds
                if (!_isWaiting) {
                    _isWaiting = true; //Prevent coroutine to be triggered twice
                    _playerDead = false;
                    lifeCount--;
                    RespawnPlayer();
                }
            }
        }

        //if Boss is destroyed
        if (!GameObject.FindGameObjectWithTag("Enemy")) {
            GameEnd();
        }
	}

    // Coroutine to respawn the player after 3 seconds after death
    void RespawnPlayer() {
        //Only respawn when life count is > 0
        if (lifeCount > 0) {
            Instantiate(player, new Vector3(0, 0, -3f), transform.rotation);
        }
        _isWaiting = false;
    }

    // Menus after game has ended
    void OnGUI() {
        if (_fightEnd) {
            if (!_playerDead) {
                GUI.TextArea(new Rect(50, 100, 100, 50), "Congratulations!");
            }

            if (GUI.Button(new Rect(100, 200, 100, 50), "Play Again"))
                Application.LoadLevel("BossScene");
        }

    }

    //Game End flag
    void GameEnd() {
        _fightEnd = true;
    }
}
