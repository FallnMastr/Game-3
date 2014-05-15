using UnityEngine;
using System.Collections;

public class Level_2_Events : MonoBehaviour {
	// keeps track of the players position
	float x_pos;
	float y_pos;

	player user;

	// THINGS NEEDED FOR THE GUI
	public GUISkin Dialog_GUISkin;

	public Texture Dialog_Texture;

	int top;
	int left;
	int width;
	int height;
	
	int fontSize;
	
	string textShown;

	bool hasSeenCity,doShowDialog;
	// Use this for initialization
	void Start () {
		user = (player)FindObjectOfType (typeof(player));

		x_pos = user.xpos;
		y_pos = user.ypos;

		// THINGS NEEDED FOR THE GUI
		top = Screen.height * 3 / 4;
		left = Screen.width/5;
		height = Screen.height - top - 10;
		width = Screen.width *3/5 ;

		fontSize = Screen.height/25;
		textShown = "";
		doShowDialog = false;

	}
	
	// Update is called once per frame
	void Update () {
		x_pos = user.xpos;
		y_pos = user.ypos;

		if (!hasSeenCity) {
			if (y_pos > 71f) {
				textShown = "There's a city off in the distance!  Maybe I can meet a few locals, ask a few questions...";
				doShowDialog = true;
				hasSeenCity = !hasSeenCity;
			}
		}

		Debug.Log ("Player Pos: ( " + x_pos + " , " + y_pos + " )");

	}
	void OnGUI(){
		
		Rect speechRect = new Rect (left, top, width, height);
		Rect closeButtRect = new Rect (left + width - 75, top + (height - 30), 50, 25);
		
		if (doShowDialog) {
			GUI.skin = Dialog_GUISkin;
			GUI.skin.textArea.fontSize = fontSize;
			if(GUI.Button(closeButtRect,"Close")){close ();}
			GUI.DrawTexture(speechRect,Dialog_Texture);
			GUI.TextArea(speechRect,textShown);
			if(GUI.Button(closeButtRect,"Close")){close ();}
		}

	}
	// GUI FUNCTIONS BELOW 
	// closes a dialog, sign, or thought box
	void close(){
		doShowDialog = false;
	}
}
