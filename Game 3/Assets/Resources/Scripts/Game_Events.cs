using UnityEngine;
using System.Collections;

public class Game_Events : MonoBehaviour {
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

	// AREA 1 
	bool gameStart,hasSeenLake,hasSeenShop;
	// AREA 2
	bool hasSeenCity;
	// AREA 3
	bool inArea3, movedNumSteps, startedConvo, didClickNext, hasSeenScroll;
	bool BtoM1,BtoM2,BtoM3,BtoM4,BtoM5;
	bool MtoB1,MtoB2,MtoB3,MtoB4,MtoB5;
	// AREA 4 
	// AREA 5
	// AREA 6 
	// AREA 7
	// AREA 8 
	// AREA 9
	// AREA 10 
	// AREA 12
	// AREA 13
	// AREA 14
	// AREA 15
	// Temple Message
	bool inTemple;

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

		// AREA 1
		gameStart = false; hasSeenLake = false; hasSeenShop = false;

		// AREA 2
		hasSeenCity = false;

		// AREA 3
		inArea3 = false; movedNumSteps = false; startedConvo = false; didClickNext = false; hasSeenScroll = false;
		BtoM1 = true; BtoM2 = false; BtoM3 = false; BtoM4 = false; BtoM5 = false;
		MtoB1 = false; MtoB2 = false; MtoB3 = false; MtoB4 = false; MtoB5 = false;

		// AREA 4 

		// AREA 5

		// AREA 6 

		// AREA 7

		// AREA 8 

		// AREA 9

		// AREA 10 

		// AREA 11

		// AREA 12
	
		// AREA 13

		// AREA 14

		// AREA 15

		// Temple Message
		inTemple = false;

	}
	
	// Update is called once per frame
	void Update () {
		x_pos = user.xpos;
		y_pos = user.ypos;
		//Debug.Log ("Player Pos: ( " + x_pos + " , " + y_pos + " )");


		// AREA 1

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
				textShown = "That's strange. A building without someone nearby...";
				doShowDialog = true;
				hasSeenShop = !hasSeenShop;
			}
		}

		// AREA 2
		if (!hasSeenCity) {
			if (y_pos > 71f && y_pos < 73f) {
				textShown = "There's a city off in the distance!  Maybe I can meet a few locals, ask a few questions...";
				doShowDialog = true;
				hasSeenCity = !hasSeenCity;
			}
		}

		// AREA 3

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

			// NPC CONVO IN AREA 3
		if (!startedConvo) {
			if(hasStartedConvo()){
				if(BtoM1){
					textShown = "Blake: Hey!  You!  I was starting to think this place was abandoned!";
					doShowDialog = true;
					if(didClickNext){
						BtoM1 = false;
						MtoB1 = true;
						didClickNext = false;
					}
				}
				if(MtoB1){
					textShown = "Stranger: Who are you?";
					doShowDialog = true;
					if(didClickNext){
						MtoB1 = false;
						BtoM2 = true;
						didClickNext = false;
					}
				}
				if(BtoM2){
					textShown = "Blake: Oh sorry, I'm Blake.  I'm from another world, we call it Earth... but it's not much of  a planet anymore, actually.  I've been trying to find a safe planet for our population to colonize.  I'm hoping this is the place.  ";
					doShowDialog = true;
					if(didClickNext){
						BtoM2 = false;
						MtoB2 = true;
						didClickNext = false;
					}
				}
				if(MtoB2){
					textShown = "Stranger: It's not.  You shouldn't bring anyone here.  Our own people weren't even safe here.  You should leave.";
					doShowDialog = true;
					if(didClickNext){
						MtoB2 = false;
						BtoM3 = true;
						didClickNext = false;
					}
				}
				if(BtoM3){
					textShown = "Blake:  What do you mean?  What happened to your people?";
					doShowDialog = true;
					if(didClickNext){
						BtoM3 = false;
						MtoB3 = true;
						didClickNext = false;
					}
				}
				if(MtoB3){
					textShown = "Stranger: They all vanished.  Everything was fine, and then they were all gone.  I think I'm the only one left.  You're not safe here.";
					doShowDialog = true;
					if(didClickNext){
						MtoB3 = false;
						BtoM4 = true;
						didClickNext = false;
					}
				}
				if(BtoM4){
					textShown = "Blake: They vanished?";
					doShowDialog = true;
					if(didClickNext){
						BtoM4 = false;
						MtoB4 = true;
						didClickNext = false;
					}
				}
				if(MtoB4){
					textShown = "Stranger: Yes, I just said that.  You should go.";
					doShowDialog = true;
					if(didClickNext){
						MtoB4 = false;
						BtoM5 = true;
						didClickNext = false;
					}
				}
				if(BtoM5){
					textShown = "Blake: I'm not leaving.  This place might be our last hope, and I'm not giving up on it.  Tell me what happened.";
					doShowDialog = true;
					if(didClickNext){
						BtoM5 = false;
						MtoB5 = true;
						didClickNext = false;
					}
				}
				if(MtoB5){
					textShown = "Stranger: Well, they just disappeared.  The thing that set me apart was that I didn't buy into the Faith of DraLoren.  The people here were extremely religious.  When they all disappeared, I began looking for answers.  I found this scroll near the temple.  You may read it.";
					doShowDialog = true;
					if(didClickNext){
						MtoB5 = false;

						didClickNext = false;
						// when last dialog box appears change startConvo to true
						startedConvo = true;
					}

				}

			}
			if(!hasSeenScroll){
				if(startedConvo){
					textShown = "Scroll: To the mountains you must journey, to the plains, the desert, and the waters. The four orbs of DraLoren, the four gods for which they stand. Restore them to our temple, restore your people to the land.";
					doShowDialog = true;
					hasSeenScroll = true;
				}
			}

		}

		// AREA 4 
		// AREA 5
		// AREA 6 
		// AREA 7
		// AREA 8 
		// AREA 9
		// AREA 10 
		// AREA 12
		// AREA 13
		// AREA 14
		// AREA 15

		//Temple Message
		if (!inTemple) {
			if(isInTemple()){
				textShown = "“Restore them to our temple, restore your people to the land”...I guess all I have to do now is return these orbs.";
				doShowDialog = true;
				inTemple = true;
			}
		}

		
	}
	void OnGUI(){
		
		Rect speechRect = new Rect (left, top, width, height);
		Rect closeButtRect = new Rect (left + width - 75, top + (height - 30), 50, 25);
		//Rect nextRect = new Rect (left + width - 75, tope + height - 30, 50, 25);
		
		if (doShowDialog) {
			GUI.skin = Dialog_GUISkin;
			GUI.skin.textArea.fontSize = fontSize;
			if(GUI.Button(closeButtRect,"Close"))
			{
				close ();
				if(hasStartedConvo()){
					didClickNext = true;// used for the are3 convo with npc
				}
			}
			GUI.DrawTexture(speechRect,Dialog_Texture);
			GUI.TextArea(speechRect,textShown);
			if(GUI.Button(closeButtRect,"Close")){
				close ();
				if(hasStartedConvo()){
				didClickNext = true;// used for the are3 convo with npc
				}
			}
			 
		}
		
	}
	// GUI FUNCTIONS BELOW 
	// closes a dialog, sign, or thought box
	void close(){
		doShowDialog = false;
	}

	// AREA 1 FUNCTIONS

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
		
		if (x_pos >= -9f && x_pos <= 11f && y_pos >= 14.5f && y_pos <= 24.5f) {
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

	// AREA 2 FUNCTIONS IN THE UPDATE FUNCION
	// AREA 3 FUNCTIONS

	bool isInArea3(){
		return(x_pos == 46f && y_pos == 83.5f);
	}
	bool hasMovedSteps(){
		float numStepsAway = 25;
		if ((x_pos == 46f + numStepsAway || (x_pos == 46f - numStepsAway && y_pos == 83.5f)) || (y_pos == 83.5f + numStepsAway)) {
			return(true);
		}
		return(false);
	}
	bool hasStartedConvo(){
		return(x_pos == 53f && y_pos == 124.5f);
		
	}

	// AREA 4 FUNCTIONS
	// AREA 5 FUNCTIONS
	// AREA 6 FUNCTIONS
	// AREA 7 FUNCTIONS
	// AREA 8 FUNCTIONS
	// AREA 9 FUNCTIONS
	// AREA 10 FUNCTIONS
	// AREA 11 FUNCTIONS
	// AREA 12 FUNCTIONS
	// AREA 13 FUNCTIONS
	// AREA 14 FUNCTIONS
	// AREA 15 FUNCTIONS
	// Temple Message Function
	bool isInTemple(){
		//	xpos: 35 <= x <= 57
		//	ypos: y <= 248.5
		return((x_pos >= 35f && x_pos <= 57f) && (y_pos >= 240.5f));
	}
}
