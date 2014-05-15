using UnityEngine;
using System.Collections;

public class Quad2 : MonoBehaviour {

    float xc;
    float yc;

	// Use this for initialization
	void Start () {
        xc = GameObject.Find("Main Camera").transform.position.x;
        yc = GameObject.Find("Main Camera").transform.position.y;

        transform.position = new Vector3(xc + 19, yc, -1);
	}
	
	// Update is called once per frame
	void Update () {
        xc = GameObject.Find("Main Camera").transform.position.x;
        yc = GameObject.Find("Main Camera").transform.position.y;

        transform.position = new Vector3(xc + 19, yc, -1);
	}
}
