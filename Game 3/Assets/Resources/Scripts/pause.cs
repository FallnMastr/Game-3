using UnityEngine;
using System.Collections;
using System;

public class pause : MonoBehaviour {

	public GUISkin guiSkin;

    Stats stat;
    player play;
    Move_To_Player cam;

    int saveState;

	// Use this for initialization
	void Start () {
        saveState = PlayerPrefs.GetInt("saveState");
	}
	
	// Update is called once per frame
	void Update () {
        stat = (Stats)FindObjectOfType(typeof(Stats));
        play = (player)FindObjectOfType(typeof(player));
        cam = (Move_To_Player)FindObjectOfType(typeof(Move_To_Player));
	}

    void OnGUI () {
		GUI.skin = guiSkin;

        if(GUI.Button(new Rect(Screen.width*0.35f, Screen.height*0.5f, Screen.width*0.3f, Screen.height*0.1f), new GUIContent("SAVE", "All previously saved progress will be overwritten!"))) {
            switch (saveState) {
                case 1:
                    PlayerPrefs.SetInt("currentLevel1", stat.currentLevel);
                    PlayerPrefs.SetInt("lastLevel1", stat.lastLevel);
                    PlayerPrefs.SetInt("newLevel1", stat.newLevel);
                    PlayerPrefs.SetInt("hp1", stat.hp);
                    PlayerPrefs.SetInt("currentHP1", stat.currentHP);
                    PlayerPrefs.SetInt("str1", stat.str);
                    PlayerPrefs.SetInt("vit1", stat.vit);
                    PlayerPrefs.SetInt("spd1", stat.spd);
                    PlayerPrefs.SetInt("heroLevel1", stat.heroLevel);
                    PlayerPrefs.SetInt("currentExperience1", stat.currentExperience);
                    PlayerPrefs.SetInt("potions1", stat.potions);
                    PlayerPrefs.SetInt("gold1", stat.gold);
                    PlayerPrefs.SetInt("expToNextLevel1", stat.expToNextLevel);
                    PlayerPrefs.SetInt("dir1", play.anim.GetInteger("Direction"));
                    PlayerPrefs.SetInt("boots_int1", stat.boots_int);
                    PlayerPrefs.SetInt("weapon_int11", stat.weapon_int1);
                    PlayerPrefs.SetInt("weapon_int21", stat.weapon_int2);
                    PlayerPrefs.SetInt("weapon_int31", stat.weapon_int3);
                    PlayerPrefs.SetInt("sword_int11", stat.sword_int1);
                    PlayerPrefs.SetInt("sword_int21", stat.sword_int2);
                    PlayerPrefs.SetInt("sword_int31", stat.sword_int3);
                    PlayerPrefs.SetInt("orb_earth1", stat.orb_earth);
                    PlayerPrefs.SetInt("orb_fire1", stat.orb_fire);
                    PlayerPrefs.SetInt("orb_water1", stat.orb_water);
                    PlayerPrefs.SetInt("orb_wind1", stat.orb_wind);
                    PlayerPrefs.SetInt("chest1_11", stat.chest1_1);
                    PlayerPrefs.SetInt("chest1_21", stat.chest1_2);
                    PlayerPrefs.SetInt("chest5_11", stat.chest5_1);
                    PlayerPrefs.SetInt("chest6_11", stat.chest6_1);
                    PlayerPrefs.SetInt("chest6_21", stat.chest6_2);
                    PlayerPrefs.SetInt("chest6_31", stat.chest6_3);
                    PlayerPrefs.SetInt("chest6_41", stat.chest6_4);
                    PlayerPrefs.SetInt("chest6_51", stat.chest6_5);
                    PlayerPrefs.SetInt("chest6_61", stat.chest6_6);
                    PlayerPrefs.SetInt("chest6_71", stat.chest6_7);
                    PlayerPrefs.SetInt("chest7_11", stat.chest7_1);
                    PlayerPrefs.SetInt("chest8_11", stat.chest8_1);
            
                    PlayerPrefs.SetFloat("xpos1", play.xpos);
                    PlayerPrefs.SetFloat("ypos1", play.ypos);
                    Debug.Log(PlayerPrefs.GetFloat("xpos1"));
                    Debug.Log(PlayerPrefs.GetFloat("ypos1"));

                    PlayerPrefs.SetFloat("xDist1", cam.xDist);
                    PlayerPrefs.SetFloat("yDist1", cam.yDist);
                    break;
                case 2:
                    PlayerPrefs.SetInt("currentLevel2", stat.currentLevel);
                    PlayerPrefs.SetInt("lastLevel2", stat.lastLevel);
                    PlayerPrefs.SetInt("newLevel2", stat.newLevel);
                    PlayerPrefs.SetInt("hp2", stat.hp);
                    PlayerPrefs.SetInt("currentHP2", stat.currentHP);
                    PlayerPrefs.SetInt("str2", stat.str);
                    PlayerPrefs.SetInt("vit2", stat.vit);
                    PlayerPrefs.SetInt("spd2", stat.spd);
                    PlayerPrefs.SetInt("heroLevel2", stat.heroLevel);
                    PlayerPrefs.SetInt("currentExperience2", stat.currentExperience);
                    PlayerPrefs.SetInt("potions2", stat.potions);
                    PlayerPrefs.SetInt("gold2", stat.gold);
                    PlayerPrefs.SetInt("expToNextLevel2", stat.expToNextLevel);
                    PlayerPrefs.SetInt("dir2", play.anim.GetInteger("Direction"));
                    PlayerPrefs.SetInt("boots_int2", stat.boots_int);
                    PlayerPrefs.SetInt("weapon_int12", stat.weapon_int1);
                    PlayerPrefs.SetInt("weapon_int22", stat.weapon_int2);
                    PlayerPrefs.SetInt("weapon_int32", stat.weapon_int3);
                    PlayerPrefs.SetInt("sword_int12", stat.sword_int1);
                    PlayerPrefs.SetInt("sword_int22", stat.sword_int2);
                    PlayerPrefs.SetInt("sword_int32", stat.sword_int3);
                    PlayerPrefs.SetInt("orb_earth2", stat.orb_earth);
                    PlayerPrefs.SetInt("orb_fire2", stat.orb_fire);
                    PlayerPrefs.SetInt("orb_water2", stat.orb_water);
                    PlayerPrefs.SetInt("orb_wind2", stat.orb_wind);
                    PlayerPrefs.SetInt("chest1_12", stat.chest1_1);
                    PlayerPrefs.SetInt("chest1_22", stat.chest1_2);
                    PlayerPrefs.SetInt("chest5_12", stat.chest5_1);
                    PlayerPrefs.SetInt("chest6_12", stat.chest6_1);
                    PlayerPrefs.SetInt("chest6_22", stat.chest6_2);
                    PlayerPrefs.SetInt("chest6_32", stat.chest6_3);
                    PlayerPrefs.SetInt("chest6_42", stat.chest6_4);
                    PlayerPrefs.SetInt("chest6_52", stat.chest6_5);
                    PlayerPrefs.SetInt("chest6_62", stat.chest6_6);
                    PlayerPrefs.SetInt("chest6_72", stat.chest6_7);
                    PlayerPrefs.SetInt("chest7_12", stat.chest7_1);
                    PlayerPrefs.SetInt("chest8_12", stat.chest8_1);
            
                    PlayerPrefs.SetFloat("xpos2", play.xpos);
                    PlayerPrefs.SetFloat("ypos2", play.ypos);

                    PlayerPrefs.SetFloat("xDist2", cam.xDist);
                    PlayerPrefs.SetFloat("yDist2", cam.yDist);
                    break;
                case 3:
                    PlayerPrefs.SetInt("currentLevel3", stat.currentLevel);
                    PlayerPrefs.SetInt("lastLevel3", stat.lastLevel);
                    PlayerPrefs.SetInt("newLevel3", stat.newLevel);
                    PlayerPrefs.SetInt("hp3", stat.hp);
                    PlayerPrefs.SetInt("currentHP3", stat.currentHP);
                    PlayerPrefs.SetInt("str3", stat.str);
                    PlayerPrefs.SetInt("vit3", stat.vit);
                    PlayerPrefs.SetInt("spd3", stat.spd);
                    PlayerPrefs.SetInt("heroLevel3", stat.heroLevel);
                    PlayerPrefs.SetInt("currentExperience3", stat.currentExperience);
                    PlayerPrefs.SetInt("potions3", stat.potions);
                    PlayerPrefs.SetInt("gold3", stat.gold);
                    PlayerPrefs.SetInt("expToNextLevel3", stat.expToNextLevel);
                    PlayerPrefs.SetInt("dir3", play.anim.GetInteger("Direction"));
                    PlayerPrefs.SetInt("boots_int3", stat.boots_int);
                    PlayerPrefs.SetInt("weapon_int13", stat.weapon_int1);
                    PlayerPrefs.SetInt("weapon_int23", stat.weapon_int2);
                    PlayerPrefs.SetInt("weapon_int33", stat.weapon_int3);
                    PlayerPrefs.SetInt("sword_int13", stat.sword_int1);
                    PlayerPrefs.SetInt("sword_int23", stat.sword_int2);
                    PlayerPrefs.SetInt("sword_int33", stat.sword_int3);
                    PlayerPrefs.SetInt("orb_earth3", stat.orb_earth);
                    PlayerPrefs.SetInt("orb_fire3", stat.orb_fire);
                    PlayerPrefs.SetInt("orb_water3", stat.orb_water);
                    PlayerPrefs.SetInt("orb_wind3", stat.orb_wind);
                    PlayerPrefs.SetInt("chest1_13", stat.chest1_1);
                    PlayerPrefs.SetInt("chest1_23", stat.chest1_2);
                    PlayerPrefs.SetInt("chest5_13", stat.chest5_1);
                    PlayerPrefs.SetInt("chest6_13", stat.chest6_1);
                    PlayerPrefs.SetInt("chest6_23", stat.chest6_2);
                    PlayerPrefs.SetInt("chest6_33", stat.chest6_3);
                    PlayerPrefs.SetInt("chest6_43", stat.chest6_4);
                    PlayerPrefs.SetInt("chest6_53", stat.chest6_5);
                    PlayerPrefs.SetInt("chest6_63", stat.chest6_6);
                    PlayerPrefs.SetInt("chest6_73", stat.chest6_7);
                    PlayerPrefs.SetInt("chest7_13", stat.chest7_1);
                    PlayerPrefs.SetInt("chest8_13", stat.chest8_1);
            
                    PlayerPrefs.SetFloat("xpos3", play.xpos);
                    PlayerPrefs.SetFloat("ypos3", play.ypos);

                    PlayerPrefs.SetFloat("xDist3", cam.xDist);
                    PlayerPrefs.SetFloat("yDist3", cam.yDist);
                    break;
            }
        }

        if(GUI.Button(new Rect(Screen.width*0.35f, Screen.height*0.65f, Screen.width*0.3f, Screen.height*0.1f), new GUIContent("QUIT", "Any usaved progress will be lost!"))) {
            Application.Quit();
        }

        GUI.Label(new Rect(Screen.width*0.25f, Screen.height*0.75f, Screen.width*0.5f, Screen.height*0.25f), GUI.tooltip);
    }

    void drawOutline(Rect position, String text, GUIStyle style, Color outColor, Color inColor) {
        var backupStyle = style;
        style.normal.textColor = outColor;
        position.x--;
        GUI.Label(position, text, style);
        position.x +=2;
        GUI.Label(position, text, style);
        position.x--;
        position.y--;
        GUI.Label(position, text, style);
        position.y +=2;
        GUI.Label(position, text, style);
        position.y--;
        style.normal.textColor = inColor;
        GUI.Label(position, text, style);
        style = backupStyle;
    }
}
