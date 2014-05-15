using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    player play;

    public int saveState;               // Out of all possible save states which is being used
    public int currentLevel;            // Current level based upon the build settings (ship level is 6)
    public int lastLevel;               // The previous level the player was in
    public int newLevel;                // The level the player just switched to

    public int xPosOver, yPosOver;      // Last x and y coordinates in the overworld

    public int hp, str, vit, spd;       // Player stats to be used during battles
	public int currentHP;				// Player's remembered current HP
	public int heroLevel;				// Player's level based on experience
	public int currentExperience;		// Player's current experience pool
	public int expToNextLevel;			// The amount of experience required for player to reach next level
	public int rand;					// Holds a randomly generated number
	public int strGained, vitGained;	// Amount of str and vit gained on level up
    
    public int potions, gold;           // Number of these items the player has in inventory

    public bool switchLevel;
	public bool waterBoots;								//keeps track of whether or not player has water boots
	public bool weapon1, weapon2, weapon3;				//keeps track of whether or not player has found each weapon
	public bool sword1, sword2, sword3;					//keeps track of which sword is equipped
	public bool removingS1, removingS2, removingS3;		//keeps track of which sword is unequipped

    public int chest1_1, chest1_2, chest5_1, chest6_1,
               chest6_2, chest6_3, chest6_4, chest6_5,
               chest6_6, chest6_7, chest7_1, chest8_1;

    public int orb_earth, orb_fire, orb_water, orb_wind;

    public int boots_int;
    public int weapon_int1, weapon_int2, weapon_int3;
    public int sword_int1, sword_int2, sword_int3;

	public GameObject[] inventory;

    void Awake () {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        play = (player)FindObjectOfType(typeof(player));

        saveState = PlayerPrefs.GetInt("saveState");
        if (PlayerPrefs.GetInt("Load") == 1) {
            switch (saveState) {
                case 1:
                    heroLevel = PlayerPrefs.GetInt("heroLevel1");
                    hp = PlayerPrefs.GetInt("hp1");
                    currentHP = PlayerPrefs.GetInt("currentHP1");
                    str = PlayerPrefs.GetInt("str1");
                    vit = PlayerPrefs.GetInt("vit1");
                    spd = PlayerPrefs.GetInt("spd1");
                    potions = PlayerPrefs.GetInt("potions1");
                    gold = PlayerPrefs.GetInt("gold1");
                    currentLevel = PlayerPrefs.GetInt("currentLevel1");
                    lastLevel = PlayerPrefs.GetInt("lastLevel1");
                    newLevel = PlayerPrefs.GetInt("newLevel1");
                    currentExperience = PlayerPrefs.GetInt("currentExperience1");
                    expToNextLevel = PlayerPrefs.GetInt("expToNextLevel1");
                    boots_int = PlayerPrefs.GetInt("boots_int1");
                    weapon_int1 = PlayerPrefs.GetInt("weapon_int11");
                    weapon_int2 = PlayerPrefs.GetInt("weapon_int21");
                    weapon_int3 = PlayerPrefs.GetInt("weapon_int31");
                    sword_int1 = PlayerPrefs.GetInt("sword_int11");
                    sword_int2 = PlayerPrefs.GetInt("sword_int21");
                    sword_int3 = PlayerPrefs.GetInt("sword_int31");
                    orb_earth = PlayerPrefs.GetInt("orb_earth1");
                    orb_fire = PlayerPrefs.GetInt("orb_fire1");
                    orb_water = PlayerPrefs.GetInt("orb_water1");
                    orb_wind = PlayerPrefs.GetInt("orb_wind1");
                    chest1_1 = PlayerPrefs.GetInt("chest1_11");
                    chest1_2 = PlayerPrefs.GetInt("chest1_21");
                    chest5_1 = PlayerPrefs.GetInt("chest5_11");
                    chest6_1 = PlayerPrefs.GetInt("chest6_11");
                    chest6_2 = PlayerPrefs.GetInt("chest6_21");
                    chest6_3 = PlayerPrefs.GetInt("chest6_31");
                    chest6_4 = PlayerPrefs.GetInt("chest6_41");
                    chest6_5 = PlayerPrefs.GetInt("chest6_51");
                    chest6_6 = PlayerPrefs.GetInt("chest6_61");
                    chest6_7 = PlayerPrefs.GetInt("chest6_71");
                    chest7_1 = PlayerPrefs.GetInt("chest7_11");
                    chest8_1 = PlayerPrefs.GetInt("chest8_11");
                    break;
                case 2:
                    heroLevel = PlayerPrefs.GetInt("heroLevel2");
                    hp = PlayerPrefs.GetInt("hp2");
                    currentHP = PlayerPrefs.GetInt("currentHP2");
                    str = PlayerPrefs.GetInt("str2");
                    vit = PlayerPrefs.GetInt("vit2");
                    spd = PlayerPrefs.GetInt("spd2");
                    potions = PlayerPrefs.GetInt("potions2");
                    gold = PlayerPrefs.GetInt("gold2");
                    currentLevel = PlayerPrefs.GetInt("currentLevel2");
                    lastLevel = PlayerPrefs.GetInt("lastLevel2");
                    newLevel = PlayerPrefs.GetInt("newLevel2");
                    currentExperience = PlayerPrefs.GetInt("currentExperience2");
                    expToNextLevel = PlayerPrefs.GetInt("expToNextLevel2");
                    boots_int = PlayerPrefs.GetInt("boots_int2");
                    weapon_int1 = PlayerPrefs.GetInt("weapon_int12");
                    weapon_int2 = PlayerPrefs.GetInt("weapon_int22");
                    weapon_int3 = PlayerPrefs.GetInt("weapon_int32");
                    sword_int1 = PlayerPrefs.GetInt("sword_int12");
                    sword_int2 = PlayerPrefs.GetInt("sword_int22");
                    sword_int3 = PlayerPrefs.GetInt("sword_int32");
                    orb_earth = PlayerPrefs.GetInt("orb_earth2");
                    orb_fire = PlayerPrefs.GetInt("orb_fire2");
                    orb_water = PlayerPrefs.GetInt("orb_water2");
                    orb_wind = PlayerPrefs.GetInt("orb_wind2");
                    chest1_1 = PlayerPrefs.GetInt("chest1_12");
                    chest1_2 = PlayerPrefs.GetInt("chest1_22");
                    chest5_1 = PlayerPrefs.GetInt("chest5_12");
                    chest6_1 = PlayerPrefs.GetInt("chest6_12");
                    chest6_2 = PlayerPrefs.GetInt("chest6_22");
                    chest6_3 = PlayerPrefs.GetInt("chest6_32");
                    chest6_4 = PlayerPrefs.GetInt("chest6_42");
                    chest6_5 = PlayerPrefs.GetInt("chest6_52");
                    chest6_6 = PlayerPrefs.GetInt("chest6_62");
                    chest6_7 = PlayerPrefs.GetInt("chest6_72");
                    chest7_1 = PlayerPrefs.GetInt("chest7_12");
                    chest8_1 = PlayerPrefs.GetInt("chest8_12");
                    break;
                case 3:
                    heroLevel = PlayerPrefs.GetInt("heroLevel3");
                    hp = PlayerPrefs.GetInt("hp3");
                    currentHP = PlayerPrefs.GetInt("currentHP3");
                    str = PlayerPrefs.GetInt("str3");
                    vit = PlayerPrefs.GetInt("vit3");
                    spd = PlayerPrefs.GetInt("spd3");
                    potions = PlayerPrefs.GetInt("potions3");
                    gold = PlayerPrefs.GetInt("gold3");
                    currentLevel = PlayerPrefs.GetInt("currentLevel3");
                    lastLevel = PlayerPrefs.GetInt("lastLevel3");
                    newLevel = PlayerPrefs.GetInt("newLevel3");
                    currentExperience = PlayerPrefs.GetInt("currentExperience3");
                    expToNextLevel = PlayerPrefs.GetInt("expToNextLevel3");
                    boots_int = PlayerPrefs.GetInt("boots_int3");
                    weapon_int1 = PlayerPrefs.GetInt("weapon_int13");
                    weapon_int2 = PlayerPrefs.GetInt("weapon_int23");
                    weapon_int3 = PlayerPrefs.GetInt("weapon_int33");
                    sword_int1 = PlayerPrefs.GetInt("sword_int13");
                    sword_int2 = PlayerPrefs.GetInt("sword_int23");
                    sword_int3 = PlayerPrefs.GetInt("sword_int33");
                    orb_earth = PlayerPrefs.GetInt("orb_earth3");
                    orb_fire = PlayerPrefs.GetInt("orb_fire3");
                    orb_water = PlayerPrefs.GetInt("orb_water3");
                    orb_wind = PlayerPrefs.GetInt("orb_wind3");
                    chest1_1 = PlayerPrefs.GetInt("chest1_13");
                    chest1_2 = PlayerPrefs.GetInt("chest1_23");
                    chest5_1 = PlayerPrefs.GetInt("chest5_13");
                    chest6_1 = PlayerPrefs.GetInt("chest6_13");
                    chest6_2 = PlayerPrefs.GetInt("chest6_23");
                    chest6_3 = PlayerPrefs.GetInt("chest6_33");
                    chest6_4 = PlayerPrefs.GetInt("chest6_43");
                    chest6_5 = PlayerPrefs.GetInt("chest6_53");
                    chest6_6 = PlayerPrefs.GetInt("chest6_63");
                    chest6_7 = PlayerPrefs.GetInt("chest6_73");
                    chest7_1 = PlayerPrefs.GetInt("chest7_13");
                    chest8_1 = PlayerPrefs.GetInt("chest8_13");
                    break;
            }

            if   (boots_int == 1) waterBoots = true; else waterBoots = false;
            if (weapon_int1 == 1)    weapon1 = true; else    weapon1 = false;
            if (weapon_int2 == 1)    weapon2 = true; else    weapon2 = false;
            if (weapon_int3 == 1)    weapon3 = true; else    weapon3 = false;
            if  (sword_int1 == 1)     sword1 = true; else     sword1 = false;
            if  (sword_int2 == 1)     sword2 = true; else     sword2 = false;
            if  (sword_int3 == 1)     sword3 = true; else     sword3 = false;

        } else {
		    heroLevel = 1;
            hp = 1000;
			currentHP = hp;
            str = 5;
            vit = 4;
            spd = 10;
            potions = 99;
            gold = 100;
            currentLevel = 8;
            lastLevel = 8;
            newLevel = 8;
		    currentExperience = 0;
		    expToNextLevel = 100;
			waterBoots = false;
			weapon1 = true;
			weapon2 = false;
			weapon3 = false;
			sword1 = true;
			sword2 = false;
			sword3 = false;
            orb_earth = 0;
            orb_fire = 0;
            orb_water = 0;
            orb_wind = 0;
            chest1_1 = 0;
            chest1_2 = 0;
            chest5_1 = 0;
            chest6_1 = 0;
            chest6_2 = 0;
            chest6_3 = 0;
            chest6_4 = 0;
            chest6_5 = 0;
            chest6_6 = 0;
            chest6_7 = 0;
            chest7_1 = 0;
            chest8_1 = 0;
            str++;
        }

        switchLevel = false;
	}
	
	// Update is called once per frame
	void Update () {
		updateLevel();

        if (waterBoots)   boots_int = 1; else   boots_int = 0;
        if    (weapon1) weapon_int1 = 1; else weapon_int1 = 0;
        if    (weapon2) weapon_int2 = 1; else weapon_int2 = 0;
        if    (weapon3) weapon_int3 = 1; else weapon_int3 = 0;
        if     (sword1)  sword_int1 = 1; else  sword_int1 = 0;
        if     (sword2)  sword_int2 = 1; else  sword_int2 = 0;
        if     (sword3)  sword_int3 = 1; else  sword_int3 = 0;

        if (waterBoots) { if (GameObject.Find("Lake")) GameObject.Destroy(GameObject.Find("Lake")); }

        if (chest1_1 == 1) { if (GameObject.Find("chest1_1")) GameObject.Destroy(GameObject.Find("chest1_1"));
        } else {
            if ((play.xpos == 0 && play.ypos == 0 && (play.anim.GetInteger("Direction") == 0 || play.anim.GetInteger("Direction") == 1)) ||
                (play.xpos == -1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 10 || play.anim.GetInteger("Direction") == 11)) ||
                (play.xpos == 0 && play.ypos == 2 && (play.anim.GetInteger("Direction") == 20 || play.anim.GetInteger("Direction") == 21)) ||
                (play.xpos ==  1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 30 || play.anim.GetInteger("Direction") == 31))) {
                    chest1_1 = 1;
                    gold += 1000;
            }
        }
        if (chest1_2 == 1) { if (GameObject.Find("chest1_2")) GameObject.Destroy(GameObject.Find("chest1_2"));
        } else {
            if ((play.xpos == 0 && play.ypos == 0 && (play.anim.GetInteger("Direction") == 0 || play.anim.GetInteger("Direction") == 1)) ||
                (play.xpos == -1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 10 || play.anim.GetInteger("Direction") == 11)) ||
                (play.xpos == 0 && play.ypos == 2 && (play.anim.GetInteger("Direction") == 20 || play.anim.GetInteger("Direction") == 21)) ||
                (play.xpos ==  1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 30 || play.anim.GetInteger("Direction") == 31))) {
                    chest1_2 = 1;
                    weapon2 = true; 
            }
        }
        if (chest5_1 == 1) { if (GameObject.Find("chest5_1")) GameObject.Destroy(GameObject.Find("chest5_1"));
        } else {
            if ((play.xpos == 0 && play.ypos == 0 && (play.anim.GetInteger("Direction") == 0 || play.anim.GetInteger("Direction") == 1)) ||
                (play.xpos == -1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 10 || play.anim.GetInteger("Direction") == 11)) ||
                (play.xpos == 0 && play.ypos == 2 && (play.anim.GetInteger("Direction") == 20 || play.anim.GetInteger("Direction") == 21)) ||
                (play.xpos ==  1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 30 || play.anim.GetInteger("Direction") == 31))) {
                    chest5_1 = 1;
                    orb_wind = 1;
            }
        }
        if (chest6_1 == 1) { if (GameObject.Find("chest6_1")) GameObject.Destroy(GameObject.Find("chest6_1"));
        } else {
            if ((play.xpos == 0 && play.ypos == 0 && (play.anim.GetInteger("Direction") == 0 || play.anim.GetInteger("Direction") == 1)) ||
                (play.xpos == -1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 10 || play.anim.GetInteger("Direction") == 11)) ||
                (play.xpos == 0 && play.ypos == 2 && (play.anim.GetInteger("Direction") == 20 || play.anim.GetInteger("Direction") == 21)) ||
                (play.xpos ==  1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 30 || play.anim.GetInteger("Direction") == 31))) {
                    chest6_1 = 1;
                    gold += 1000;
            }
        }
        if (chest6_2 == 1) { if (GameObject.Find("chest6_2")) GameObject.Destroy(GameObject.Find("chest6_2"));
        } else {
            if ((play.xpos == 0 && play.ypos == 0 && (play.anim.GetInteger("Direction") == 0 || play.anim.GetInteger("Direction") == 1)) ||
                (play.xpos == -1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 10 || play.anim.GetInteger("Direction") == 11)) ||
                (play.xpos == 0 && play.ypos == 2 && (play.anim.GetInteger("Direction") == 20 || play.anim.GetInteger("Direction") == 21)) ||
                (play.xpos ==  1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 30 || play.anim.GetInteger("Direction") == 31))) {
                    chest6_2 = 1;
                    gold += 1000;
            }
        }
        if (chest6_3 == 1) { if (GameObject.Find("chest6_3")) GameObject.Destroy(GameObject.Find("chest6_3"));
        } else {
            if ((play.xpos == 0 && play.ypos == 0 && (play.anim.GetInteger("Direction") == 0 || play.anim.GetInteger("Direction") == 1)) ||
                (play.xpos == -1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 10 || play.anim.GetInteger("Direction") == 11)) ||
                (play.xpos == 0 && play.ypos == 2 && (play.anim.GetInteger("Direction") == 20 || play.anim.GetInteger("Direction") == 21)) ||
                (play.xpos ==  1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 30 || play.anim.GetInteger("Direction") == 31))) {
                    chest6_3 = 1;
                    gold += 1000;
            }
        }
        if (chest6_4 == 1) { if (GameObject.Find("chest6_4")) GameObject.Destroy(GameObject.Find("chest6_4"));
        } else {
            if ((play.xpos == 0 && play.ypos == 0 && (play.anim.GetInteger("Direction") == 0 || play.anim.GetInteger("Direction") == 1)) ||
                (play.xpos == -1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 10 || play.anim.GetInteger("Direction") == 11)) ||
                (play.xpos == 0 && play.ypos == 2 && (play.anim.GetInteger("Direction") == 20 || play.anim.GetInteger("Direction") == 21)) ||
                (play.xpos ==  1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 30 || play.anim.GetInteger("Direction") == 31))) {
                    chest6_4 = 1;
                    gold += 1000;
            }
        }
        if (chest6_5 == 1) { if (GameObject.Find("chest6_5")) GameObject.Destroy(GameObject.Find("chest6_5"));
        } else {
            if ((play.xpos == 0 && play.ypos == 0 && (play.anim.GetInteger("Direction") == 0 || play.anim.GetInteger("Direction") == 1)) ||
                (play.xpos == -1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 10 || play.anim.GetInteger("Direction") == 11)) ||
                (play.xpos == 0 && play.ypos == 2 && (play.anim.GetInteger("Direction") == 20 || play.anim.GetInteger("Direction") == 21)) ||
                (play.xpos ==  1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 30 || play.anim.GetInteger("Direction") == 31))) {
                    chest6_5 = 1;
                    weapon3 = true;
            }
        }
        if (chest6_6 == 1) { if (GameObject.Find("chest6_6")) GameObject.Destroy(GameObject.Find("chest6_6"));
        } else {
            if ((play.xpos == 0 && play.ypos == 0 && (play.anim.GetInteger("Direction") == 0 || play.anim.GetInteger("Direction") == 1)) ||
                (play.xpos == -1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 10 || play.anim.GetInteger("Direction") == 11)) ||
                (play.xpos == 0 && play.ypos == 2 && (play.anim.GetInteger("Direction") == 20 || play.anim.GetInteger("Direction") == 21)) ||
                (play.xpos ==  1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 30 || play.anim.GetInteger("Direction") == 31))) {
                    chest6_6 = 1;
                    gold += 1000;
            }
        }
        if (chest6_7 == 1) { if (GameObject.Find("chest6_7")) GameObject.Destroy(GameObject.Find("chest6_7"));
        } else {
            if ((play.xpos == 0 && play.ypos == 0 && (play.anim.GetInteger("Direction") == 0 || play.anim.GetInteger("Direction") == 1)) ||
                (play.xpos == -1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 10 || play.anim.GetInteger("Direction") == 11)) ||
                (play.xpos == 0 && play.ypos == 2 && (play.anim.GetInteger("Direction") == 20 || play.anim.GetInteger("Direction") == 21)) ||
                (play.xpos ==  1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 30 || play.anim.GetInteger("Direction") == 31))) {
                    chest6_7 = 1;
                    orb_fire = 1;
            }
        }
        if (chest7_1 == 1) { if (GameObject.Find("chest7_1")) GameObject.Destroy(GameObject.Find("chest7_1"));
        } else {
            if ((play.xpos == 0 && play.ypos == 0 && (play.anim.GetInteger("Direction") == 0 || play.anim.GetInteger("Direction") == 1)) ||
                (play.xpos == -1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 10 || play.anim.GetInteger("Direction") == 11)) ||
                (play.xpos == 0 && play.ypos == 2 && (play.anim.GetInteger("Direction") == 20 || play.anim.GetInteger("Direction") == 21)) ||
                (play.xpos ==  1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 30 || play.anim.GetInteger("Direction") == 31))) {
                    chest7_1 = 1;
                    orb_earth = 1;
            }
        }
        if (chest8_1 == 1) { if (GameObject.Find("chest8_1")) GameObject.Destroy(GameObject.Find("chest8_1"));
        } else {
            if ((play.xpos == 0 && play.ypos == 0 && (play.anim.GetInteger("Direction") == 0 || play.anim.GetInteger("Direction") == 1)) ||
                (play.xpos == -1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 10 || play.anim.GetInteger("Direction") == 11)) ||
                (play.xpos == 0 && play.ypos == 2 && (play.anim.GetInteger("Direction") == 20 || play.anim.GetInteger("Direction") == 21)) ||
                (play.xpos ==  1 && play.ypos == 1 && (play.anim.GetInteger("Direction") == 30 || play.anim.GetInteger("Direction") == 31))) {
                    chest8_1 = 1;
                    orb_water = 1;
            }
        }

        if (currentLevel != newLevel && switchLevel) {
            lastLevel = currentLevel;
            currentLevel = newLevel;
            switchLevel = false;
	    }
		
		//Check for which sword is equipped
		if(removingS2){
			str = str - 3;
			if(sword3){
				str = str + 5;
			}
			else if(sword1){
				str = str + 1;
			}
			removingS2 = false;
		}
		else if(removingS3){
			str = str - 5;
			if(sword2){
				str = str + 3;
			}
			else if(sword1){
				str = str + 1;
			}
			removingS3 = false;
		}
		else if(removingS1){
			str = str - 1;
			if(sword2){
				str = str + 3;
			}
			else if(sword3){
				str = str + 5;
			}
			removingS1 = false;
		}
		
		switch(heroLevel) {
			case 2:
				expToNextLevel = 200;
				break;
			case 3:
				expToNextLevel = 300;
				break;
			case 4:
				expToNextLevel = 400;
				break;
			case 5:
				expToNextLevel = 500;
				break;
			case 6:
				expToNextLevel = 700;
				break;
			case 7:
				expToNextLevel = 1000;
				break;
			case 8:
				expToNextLevel = 1200;
				break;
			case 9:
				expToNextLevel = 1350;
				break;
			case 10:
				expToNextLevel = 1500;
				break;
			case 11:
				expToNextLevel = 1700;
				break;
			case 12:
				expToNextLevel = 1800;
				break;
			case 13:
				expToNextLevel = 2000;
				break;
			case 14:
				expToNextLevel = 2250;
				break;
			case 15:
				expToNextLevel = 2500;
				break;
			case 16:
				expToNextLevel = 2750;
				break;
			case 17:
				expToNextLevel = 3000;
				break;
			case 18:
				expToNextLevel = 3500;
				break;
			case 19:
				expToNextLevel = 4000;
				break;
			case 20:
				expToNextLevel = 5000;
				break;
		}
	}

    Vector3 getLocation(int savePoint) {
        // this goes in save.cs (or whatever it will be named)
        return new Vector3(0,0,0);
    }
	
	public void updateLevel(){
		if(currentExperience >= expToNextLevel){
			heroLevel = heroLevel + 1;
			currentExperience = 0 + (currentExperience - expToNextLevel);
			rand = Random.Range(1,101);
			if(rand < 90){
				str = str + 1;
				strGained = 1;
			}
			else{
				str = str + 2;
				strGained = 2;
			}
			rand = Random.Range(1,101);
			if(rand < 90){
				vit = vit + 1;
				vitGained = 1;
			}
			else{
				vit = vit + 2;
				vitGained = 2;
			}
			spd = spd + 1;
			hp = hp + 100;
		}
	}

}
