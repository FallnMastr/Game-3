using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	Stats stat;
	battle battleScene;

	const int INVENTORY_SIZE = 8;

	int top;
	int left;
	int bottom;
	int right;
	int textHeight;
	int spaceHeight;
	int inv_height;
	int inv_width;
	int slot_selected;
	int delay; 

	bool isOpen;
	
	public string text;

	public GUISkin inv_skin;

	// Use this for initialization
	void Start () {
		stat = (Stats)FindObjectOfType(typeof(Stats));
		battleScene = (battle)FindObjectOfType(typeof(battle));

		// start with slot 1 selected
		slot_selected = 1;

		// set the top and left to align the inventory text
		top = Screen.height / 8;
		left = Screen.width / 4; 
		bottom = Screen.height * 7 / 8;
		right = Screen.width * 3 / 4;
		inv_height = bottom - top;
		inv_width = right - left;


		// set the height of the text and the space between the items
		textHeight = 30;
		spaceHeight = 10;

		// make sure the inventory is closed on start
		isOpen = false;

		// controls how soon the inventory can change states
		delay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text = "Potion x(" + stat.potions + ")";

	//	Debug.Log ("Selected_slot = " + slot_selected);

		// catches overflow
		if (delay < 0) {
			delay = 0;
				} else {
			delay++;
		}

		// detect when inventory is opened and closed
		if(Input.GetKeyUp(KeyCode.I) && delay > 50){
			isOpen = !isOpen;	// if its closed it opens and vice versa
			delay = 0;
		}

		// only change slots if inventory is open
			if (isOpen) {
						// if they press up and the slot selected is > 8 make slot selected - 1
						if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.UpArrow)) {
								if (slot_selected > 1) {
										slot_selected -= 1;
								}
						}

						// if they press down and the slot selected is < 5 make slot selected +4
						if (Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.DownArrow)) {
								if (slot_selected < INVENTORY_SIZE) {
										slot_selected += 1;
								}
						}	
				} else {
			// when inv is closed change slot selected to slot 1
			slot_selected = 1;
				}

	}
	void OnGUI(){
		int text_offset = 50;
		GUI.skin = inv_skin;
		Rect buttonRect = new Rect ();
		if (isOpen && !GameObject.Find("Battle") && !GameObject.Find("char stats")) {
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.5)/2),0,(float)(Screen.width * 0.5),(float)(Screen.height)),"");
			GUI.Label(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.3)/2),0,(float)(Screen.width * 0.3),(float)(Screen.height * 0.1)),"Inventory");

			if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.1), (float)(Screen.width * 0.3), textHeight),text)){
				//Debug.Log("Button clicked.");
				if(stat.potions > 0 && stat.currentHP < stat.hp){
					stat.currentHP = stat.currentHP + 500;
					if(stat.currentHP > stat.hp){
						stat.currentHP = stat.hp;
					}
					stat.potions = stat.potions - 1;
				}
			}
			if(stat.sword1){
				GUI.contentColor = Color.red;
			}
			else{
				GUI.contentColor = Color.white;
			}
			if(stat.weapon1){
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.2), (float)(Screen.width * 0.3), textHeight),"Sword 1")){
					if(stat.sword2){
						stat.removingS2 = true;
						stat.sword1 = true;
						stat.sword2 = false;
					}
					else if(stat.sword3){
						stat.removingS3 = true;
						stat.sword1 = true;
						stat.sword3 = false;
					}
				}
			}
			else{
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.2), (float)(Screen.width * 0.3), textHeight),"")){
				}
			}
			if(stat.sword2){
				GUI.contentColor = Color.red;
			}
			else{
				GUI.contentColor = Color.white;
			}
			if(stat.weapon2){
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.3), (float)(Screen.width * 0.3), textHeight),"Sword 2")){
					if(stat.sword1){
						stat.removingS1 = true;
						stat.sword2 = true;
						stat.sword1 = false;
					}
					else if(stat.sword3){
						stat.removingS3 = true;
						stat.sword2 = true;
						stat.sword3 = false;
					}
				}
			}
			else{
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.3), (float)(Screen.width * 0.3), textHeight),"")){
				}
			}
			if(stat.sword3){
				GUI.contentColor = Color.red;
			}
			else{
				GUI.contentColor = Color.white;
			}
			if(stat.weapon3){
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.4), (float)(Screen.width * 0.3), textHeight),"Sword 3")){
					if(stat.sword1){
						stat.removingS1 = true;
						stat.sword3 = true;
						stat.sword1 = false;
					}
					else if(stat.sword2){
						stat.removingS2 = true;
						stat.sword3 = true;
						stat.sword2 = false;
					}
				}
			}
			else{
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.4), (float)(Screen.width * 0.3), textHeight),"")){
				}
			}
			//if(stat.waterBoots){
				GUI.contentColor = Color.red;
			//}
			//else{
				//GUI.contentColor = Color.white;
			//}
			if(stat.waterBoots){
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.5), (float)(Screen.width * 0.3), textHeight),"Water Walking Shoes")){
				}
			}
			else{
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.5), (float)(Screen.width * 0.3), textHeight),"")){
				}
			}
			if(stat.orb_wind ==  1){
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.6), (float)(Screen.width * 0.3), textHeight),"Wind Orb")){
				}
			}
			else{
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.6), (float)(Screen.width * 0.3), textHeight),"")){
				}
			}
			if(stat.orb_fire ==  1){
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.7), (float)(Screen.width * 0.3), textHeight),"Fire Orb")){				
				}
			}
			else{
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.7), (float)(Screen.width * 0.3), textHeight),"")){			
				}
			}
			if(stat.orb_earth ==  1){
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.8), (float)(Screen.width * 0.3), textHeight),"Earth Orb")){
				}

			}
			else{
				if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.8), (float)(Screen.width * 0.3), textHeight),"")){
				}
			}
			if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.3)/2), (float)(Screen.height * 0.9), (float)(Screen.width * 0.3), textHeight),"")){
			}
		}
		else{
			isOpen = false;
		}
	}
	
}