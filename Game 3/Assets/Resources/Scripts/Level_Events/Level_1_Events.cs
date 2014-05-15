using UnityEngine;
using System.Collections;

public class Level_1_Events : MonoBehaviour {

	// keeps track of the players position
	float x_pos;
	float y_pos;

	// booleans keep track of events that have happened
	bool gameStart;
	bool hasSeenLake;
	bool hasSeenShop;

	string gameStartText;
	string seeShopText;
	string seeLakeText;

	player user;
	GameDialogGUI speechBox;

	// THINGS NEEDED FOR THE GUI
	public GUISkin Dialog_GUISkin;
	//public GUISkin Thought_GUISkin;
	//public GUISkin Sign_GUISkin;
	
	public Texture Dialog_Texture;
	//public Texture Sign_Texture;
	//public Texture Thought_Texture;
	
	int top;
	int left;
	int width;
	int height;
	
	int fontSize;
	int lineSpace;
	
	public string textShown;
	
	
	// true if any dialog is needed to be shown
	public bool doShowDialog,doShowThought,doShowSign;


	// Use this for initialization
	void Start () {
		user = (player)FindObjectOfType (typeof(player));
	//	speechBox = (GameDialogGUI)FindObjectOfType (typeof(GameDialogGUI));

		x_pos = user.xpos;
		y_pos = user.ypos;

		gameStart = false;
		hasSeenLake = false;
		hasSeenShop = false;

		/*gameStartText = "<speaker name>: what he says";
		seeShopText = "<speaker name>: what he says";
		seeLakeText = "<speaker name>: what he says";
		*/

		// THINGS NEEDED FOR THE GUI
		top = Screen.height * 3 / 4;
		left = Screen.width/5;
		height = Screen.height - top - 10;
		width = Screen.width *3/5 ;
		
		doShowDialog = false;
		doShowSign = false;
		doShowThought = false;
		
		fontSize = Screen.height/25;
	}
	
	// Update is called once per frame
	void Update () {

		x_pos = user.xpos;
		y_pos = user.ypos;

		// if the event has been triggered, there is no need to check for conditions
		if (!gameStart) {
			if(isStartGame()){
				textShown = "In daylight, this world looks a lot like Earth a few hundred years ago.  I probably shouldn't get my hopes up, but this could be it...I can't think that way.  I'll just follow this path and see where it leads me.";
				doShowDialog = true;
				gameStart = !gameStart;
			}
		}

		if(!hasSeenLake){
			if(canSeeLake()){
				textShown = "Whoa, is that water?  This is the first planet I've found with lakes like ours...";
				doShowDialog = true;
				hasSeenLake = !hasSeenLake;
			}
		}

		if(!hasSeenShop){
			if(canSeeShop()){
				textShown = "What happened to that place?!  I need to keep going and find out.";
				doShowDialog = true;
				hasSeenShop = !hasSeenShop;
			}
		}

		/*if(gameStart && hasSeenLake && hasSeenShop){
			Debug.Log("ALL AREA 1 EVENTS TRIGGERED!");
		}*/

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
	/*	if (doShowSign) {
			GUI.skin = Sign_GUISkin;
			GUI.skin.textArea.fontSize = fontSize;
			if(GUI.Button(closeButtRect,"Close")){close ();}
			GUI.DrawTexture(speechRect,Sign_Texture);
			GUI.TextArea(speechRect,textShown);
			if(GUI.Button(closeButtRect,"Close")){close ();}
		}
		if(doShowThought){
			GUI.skin = Thought_GUISkin;
			GUI.skin.textArea.fontSize = fontSize;
			if(GUI.Button(closeButtRect,"Close")){close ();}
			GUI.DrawTexture(speechRect,Thought_Texture);
			GUI.TextArea(speechRect,textShown);
			if(GUI.Button(closeButtRect,"Close")){close ();}
		}*/
	}
	// uses the x and y to test if the player can see the lake
	bool canSeeLake(){

		// test if player is in the upper left quadrant
		if ((x_pos >= -17f && x_pos <= -10f) && (y_pos >= .5f && y_pos <= 19.5f)) {
			return(true);
				}
		// test for upper right quadrant
		if ((x_pos >= -10f && x_pos <= 18f) && (y_pos >= .5f && y_pos <= 19.5f)) {
			return(true);
		}
		//test for lower right quadrant
		if ((x_pos >= -10f && x_pos <= 18f) && (y_pos >= -5.5f && y_pos <= .5f)) {
			return(true);
		}
		// test for lower left quadrant it's the triangle y = (-6/7)x + (-197/14), x = (y +(197/14))/(-6/7)
		if (x_pos <= -10f && y_pos <= 0.5f && y_pos >= (-6f / 7f) * x_pos + (-197f / 14f)) {
			return(true);
				}

		return(false);
	}
	// tests to see if the player can see the shop building thing
	bool canSeeShop(){

		if (x_pos >= -9f && x_pos <= 11f && y_pos >= 14.5f) {
			return(true);
				}

		return(false);
	}
	// tests if player is in the start position
	bool isStartGame(){

		if (x_pos == -26f && y_pos == -21.5) {
			return(true);
				}
		return(false);
	}

	// GUI FUNCTIONS BELOW 
	// closes a dialog, sign, or thought box
	void close(){
		doShowDialog = false;
		doShowSign = false;
		doShowThought = false;
	}

}
