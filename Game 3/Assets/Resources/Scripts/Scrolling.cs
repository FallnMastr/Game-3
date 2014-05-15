using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour {
	public GUISkin guiSkin;
	
	public float speed;
	public bool Horizontal;
	public bool textScroll;

	// Update is called once per frame
	void Update () {
		if (Horizontal == true) {
		    renderer.material.mainTextureOffset = new Vector2 ((Time.timeSinceLevelLoad * speed), 0f);
		} 
		if (Horizontal == false){
			renderer.material.mainTextureOffset = new Vector2 (0f,(Time.timeSinceLevelLoad * speed));
		}


}
	void OnGUI(){

		GUI.skin = guiSkin;

		if (textScroll == true){
			GUI.Label(new Rect(0,500 - (Time.timeSinceLevelLoad*50),Screen.width, 1000),"You " +"\n" + 
				"and a team go to explore a planet. You find some extinct civilization, which is a huge temple to explore with several layers to get to the center. Each layer requires a sacrifice, defeating an enemy, some puzzle, etc. Player can communicate with other people (Earth, space station). You explore the planet.");
		}
	}
}
