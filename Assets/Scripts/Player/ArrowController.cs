using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Rotate the Arrow towards the mouse
        /*
        Vector3 mousePos = Input.mousePosition;
        Vector3 objPosition = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.z = 10.0f; //Distance between Mouse and Arrow
        mousePos.x = mousePos.x - transform.position.x;
        mousePos.y = mousePos.y - transform.position.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0,angle);
         */

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Rotate object towards mouse position
        Quaternion rot = Quaternion.LookRotation(mousePosition - transform.position, transform.TransformDirection(Vector3.forward));
        transform.rotation = new Quaternion(0, 0, rot.z, rot.w);
	}
}
