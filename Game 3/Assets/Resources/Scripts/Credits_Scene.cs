using UnityEngine;
using System.Collections;

public class Credits_Scene : MonoBehaviour {
	public GUISkin guiSkin;

    void Start () {
        if (GameObject.Find("Manager")) GameObject.Destroy(GameObject.Find("Manager"));
    }

	void OnGUI(){
		GUI.skin = guiSkin;
		GUI.Box(new Rect(0, 0,Screen.width,Screen.height),"");
		GUI.Label (new Rect ((Screen.width / 2) - (float)(Screen.width * 0.4), 500 - (Time.timeSinceLevelLoad * 50), (float)(Screen.width * 0.8), 8000), ""+

		           "Donnie\n"+
		           "Level Design, Character Movement,\nCollision Detection, Camera Movement,\nPause Screen, Sound Design, \nSave States\n\n"+

		           "Christian\n"+
		           "Battle System, Enemy AI, \nInventory, Shop NPC, \nArt Assets\n\n"+

		           "Byron\n"+
		           "Graphical User Interfaces, Narrative, \nCollision Detection, Main Menu, \nSound Design\n\n"+

		           "Ben\n"+
		           "Narrative, Inventory \nStory Ideas " +
		           "\n\n\n\n\n\nThanks for Playing!");

		
		if(GUI.Button(new Rect((float)(Screen.width)-(float)(Screen.width * 0.07), (float)(Screen.height * .9), (float)(Screen.width *.05), (float)(Screen.height * 0.05)), "Exit")){
			Application.LoadLevel(0);		
		}
	}
}
