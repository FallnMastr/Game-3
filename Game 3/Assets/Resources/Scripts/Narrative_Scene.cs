using UnityEngine;
using System.Collections;

public class Narrative_Scene : MonoBehaviour {
	public GUISkin guiSkin;
	public int count = 0;

	
	void OnGUI(){
		count += 1;
		GUI.skin = guiSkin;
		GUI.Box(new Rect(0, 0,Screen.width,Screen.height),"");
		GUI.Label(new Rect((Screen.width/2) - (Screen.width/4) ,500 - (Time.timeSinceLevelLoad*50),Screen.width/2, 8000),""+
			"The year is 2157. Our Earth, once beautiful, is a shadow of its former self. " +
			"The land is scarred from wars both past and present, our natural resources long ago drained." +
			" There are more people on our planet than food to sustain them. " + 
			"The atmosphere was damaged beyond repair well over a hundred years ago, and we now face " + 
			"scorching heat, unending storms, and floods that swallow entire cities. We have lost hope for our planet- Earth will not be saved." +
			"\n" +
			"\n" +
			"\n" +
			"\n" +
			"I was hired by what remains of our world's government to explore planets in the Yevon Galaxy for possible human colonization. Even if my mission is successful and I find a planet capable of sustaining life, few will have the opportunity to begin again on this new world. Time is running out for our people. I am humanity's last hope. " +
			"\n" +
			"\n" +
			"\n" +
			"\n" +
			"Of all the planets in the Yevon Galaxy, the one with the most promise for sustaining life is Draloren. I landed on its surface 76 hours ago and have been waiting for daybreak to leave my ship. I can see the first rays of light on the horizon now..."); 

		if(GUI.Button(new Rect((float)(Screen.width)-(float)(Screen.width * 0.07), (float)(Screen.height * .9), (float)(Screen.width *.05), (float)(Screen.height * 0.05)), "Skip")){
			Application.LoadLevel(7);		
		}

		if(count == 4700){
			Application.LoadLevel(7);
			}		
	}
}
