using UnityEngine;
using System.Collections;

public class Stats_GUI : MonoBehaviour {
	public GUISkin guiSkin;

	Stats hero;

    public int hp, currentHP, str, vit, spd, charLevel;   				// Stats
	public int gold, currentExperience, expToNextLevel;		// Stats
	
	public string Text, Text2, Text3, Text4, Text5, Text6;
	
    /*void Awake () {
        DontDestroyOnLoad(gameObject);
    }*/

	// Use this for initialization
	void Start () {
		hero = (Stats)FindObjectOfType(typeof(Stats));
		hp = hero.hp;
		currentHP = hero.currentHP;
		str = hero.str;
		vit = hero.vit;
		spd = hero.spd;
		gold = hero.gold;
		currentExperience = hero.currentExperience;
		expToNextLevel = hero.expToNextLevel;
		charLevel = hero.heroLevel;
		
		Text = "Level: " + charLevel;
		Text2 = "HP: " + currentHP + "/" + hp;
		Text3 = "Experience: " + currentExperience + "/" + expToNextLevel;
		Text4 = "Gold: " + gold;
		Text5 = "Str: " + str;
		Text6 = "Vit: " + vit;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
	
	void OnGUI() {
		GUI.skin = guiSkin;
		GUI.Label(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.4)/2), (float)(Screen.height * 0.2), (float)(Screen.width * 0.4), (float)(Screen.height * 0.1)), Text);
		GUI.Label(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.4)/2), (float)(Screen.height * 0.3), (float)(Screen.width * 0.4), (float)(Screen.height * 0.1)), Text2);
		GUI.Label(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.4)/2), (float)(Screen.height * 0.4), (float)(Screen.width * 0.4), (float)(Screen.height * 0.1)), Text3);
		GUI.Label(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.4)/2), (float)(Screen.height * 0.5), (float)(Screen.width * 0.4), (float)(Screen.height * 0.1)), Text4);
		GUI.Label(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.4)/2), (float)(Screen.height * 0.6), (float)(Screen.width * 0.4), (float)(Screen.height * 0.1)), Text5);
		GUI.Label(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.4)/2), (float)(Screen.height * 0.7), (float)(Screen.width * 0.4), (float)(Screen.height * 0.1)), Text6);
	}
	

	
	
}
