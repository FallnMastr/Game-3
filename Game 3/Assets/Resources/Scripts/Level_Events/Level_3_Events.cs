using UnityEngine;
using System.Collections;

public class Level_3_Events : MonoBehaviour {
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
	
	bool doShowDialog;
	// booleans for dialog upon entereing area3, after moving some steps away, and talking to npc respectively
	bool inArea3, movedNumSteps, talkToMerch;
	// Use this for initialization
	void Start () {
		user = (player)FindObjectOfType (typeof(player));
		
		x_pos = user.xpos;
		y_pos = user.ypos;

		inArea3 = false;
		movedNumSteps = false;
		talkToMerch = false;

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
		
		if (!inArea3) {
			if (isInArea3()) {
				textShown = "Now if I can just find someone... \n Hello?  Hello?";
				doShowDialog = true;
				inArea3 = !inArea3;
			}
		}
		if (!movedNumSteps) {
			if(hasMovedSteps()){
				textShown = "I don't see anyone.  This city seems abandoned...\n Maybe they're just not very friendly?  I'll keep looking.";
				doShowDialog = true;
				movedNumSteps = !movedNumSteps;
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

	bool isInArea3(){
		return(x_pos == 46f && y_pos == 83.5f);
	}
	bool hasMovedSteps(){
		float numStepsAway = 25;
		if ((x_pos > 46 + numStepsAway || x_pos < 46 - numStepsAway) || (y_pos > 83.5 + numStepsAway)) {
			return(true);
				}
		return(false);
	}
	bool inFrontMerch(){
		return(x_pos == 53f && y_pos == 124.5f);

	}
}
