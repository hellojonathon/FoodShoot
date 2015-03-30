using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Rotate the Arrow towards the mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Rotate object towards mouse position
        Quaternion rot = Quaternion.LookRotation(mousePosition - transform.position, transform.TransformDirection(Vector3.forward));
        transform.rotation = new Quaternion(0, 0, rot.z, rot.w);
	}
}
