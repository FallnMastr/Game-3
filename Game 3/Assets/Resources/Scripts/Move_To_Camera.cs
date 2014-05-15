using UnityEngine;
using System.Collections;

public class Move_To_Camera : MonoBehaviour {

    Move_To_Player cam;

    public Vector3 camPos;
    public Vector3 distanceFromWorld;

	// Use this for initialization
	void Start () {
        distanceFromWorld = new Vector3(0, 0, 9);

        cam = (Move_To_Player)FindObjectOfType(typeof(Move_To_Player));
	}
	
	// Update is called once per frame
	void Update () {
        camPos = cam.transform.position + distanceFromWorld;
		//Debug.Log(camPos);
        transform.position = camPos;
	}
}
