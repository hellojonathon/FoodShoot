using UnityEngine;
using System.Collections;

public class TitleGUI : MonoBehaviour {

    //WIP Screen
	void OnGUI() {
        if (GUI.Button(new Rect(100, 300, 100, 50), "Test Game"))
            Application.LoadLevel("TestScene");

    }
}
