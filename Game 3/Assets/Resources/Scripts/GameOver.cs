using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    public KeyCode space;

	void Start () {
        space = KeyCode.Space;
	}
	
	void Update () {
        bool spc = Input.GetKey(space);

	    if (spc) {
            Application.LoadLevel(0);
        }
	}
}