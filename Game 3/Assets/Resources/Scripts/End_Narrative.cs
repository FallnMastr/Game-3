using UnityEngine;
using System.Collections;

public class End_Narrative : MonoBehaviour {
	public GUISkin guiSkin;
	public int count = 0;
	
	
	void OnGUI(){
		count += 1;
		GUI.skin = guiSkin;
		GUI.Box(new Rect(0, 0,Screen.width,Screen.height),"");
		GUI.Label(new Rect((Screen.width/2) - (Screen.width/4) ,500 - (Time.timeSinceLevelLoad*50),Screen.width/2, 8000),""+
		          "By returning the orbs to the temple of DraLoren I was able to summon the god that had imprisoned the people of DraLoren. After a long grueling battle I was able to vanquish him and lift the spell off this planet.\n\n  The local people are internally grateful and have allowed me to integrate myself into their society. I have begun discussions with the leaders of the civilization concerning setting up colonies for our race to move to. I hope that my good deeds towards the people of this planet, will allow for a peaceful transition into populating these colonies…"); 
		
		if(GUI.Button(new Rect((float)(Screen.width)-(float)(Screen.width * 0.07), (float)(Screen.height * .9), (float)(Screen.width *.05), (float)(Screen.height * 0.05)), "Skip")){
			Application.LoadLevel(19);		
		}
		if(count == 3250){
			Application.LoadLevel(19);
		}
		
	}
}