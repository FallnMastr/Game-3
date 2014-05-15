using UnityEngine;
using System.Collections;

public class Level_8_Events : MonoBehaviour {

	// keeps track of the players position
	float x_pos;
	float y_pos;
	
	player user;
	GameDialogGUI speechBox;
	
	// Use this for initialization
	void Start () {
		user = (player)FindObjectOfType (typeof(player));
		x_pos = user.xpos;
		y_pos = user.ypos;
		
		speechBox = (GameDialogGUI)FindObjectOfType (typeof(GameDialogGUI));
	}
	
	// Update is called once per frame
	void Update () {
		
		x_pos = user.xpos;
		y_pos = user.ypos;
		
		
		
	}
}
