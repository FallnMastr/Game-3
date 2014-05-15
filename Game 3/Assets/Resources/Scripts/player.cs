using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public GUISkin guiSkin;
	
    Stats stat;

    public float xpos, ypos;            // The current position of the character
	public float xposOld, yposOld;      // The position the character was previously in
    public int dir;                     // The number used to loading the proper animation when loading a save game
    int count;                          // Prevents the player from moving while the sprite is animating (ex: can't walk while turning)
	public int isInArea;				// Tells what area the player is in
	public int counter;					// A counter for the battle algorithm
	public int battleChance;			// The chance for the player to get into a battle
	public int delay;					// A delay for the item menu

    public float player_speed = 2.8f;   // The player speed, higher means faster

	public bool battle;            		// True means a battle is in place
    bool doneMoving;                    // True means the player has finished moving/animating and can move/animate again
    bool pause;                         // Forces the animations to pause while the player is turning
    public bool keysDisabled;           // Disable the movement keys if the battle scene was entered
	public bool shopOpen;				// Opens the shop
	public bool feedback, boughtPotion, didntBuyPotion, boughtShoes, didntBuyShoes;		// Variables for shop scene
	public bool noMoneyForPots, noMoneyForBoots;										// Variables for shop scene
	public bool orb1, orb2, orb3, orb4;				//Whether or not player has picked up an orb
	public bool orb1GUI, orb2GUI, orb3GUI, orb4GUI;	//Displays a message when you pick  up an orb
	public bool chest1_1, chest1_2, chest6_1, chest6_2, chest6_3, chest6_4, chest6_5, chest6_6;
	public bool chest1, chest2, chest3, chest4, chest5, chest6, chest7, chest8;
	public bool bossLoaded;				// Keeps track of is boss battle loaded
	bool rBattle;
	
	public string Text;

    public bool switching;
	
    public KeyCode u;
    public KeyCode u2;
    public KeyCode r;
    public KeyCode r2;
    public KeyCode d;
    public KeyCode d2;
    public KeyCode l;
    public KeyCode l2;

    public bool up = false;
    public bool up2 = false;
    public bool right = false;
    public bool right2 = false;
    public bool down = false;
    public bool down2 = false;
    public bool left = false;
    public bool left2 = false;

	public bool canBattle;
	
    public Animator anim;

    int saveState;
	
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
        stat = (Stats)FindObjectOfType(typeof(Stats));

        saveState = PlayerPrefs.GetInt("saveState");
        Debug.Log(saveState);

	    // Call external scripts which set variables (load variables from a save file or load start variables)
        if (PlayerPrefs.GetInt("Load") == 1) {
            switch (saveState) {
                case 1:
                    xpos = PlayerPrefs.GetFloat("xpos1");
                    Debug.Log(PlayerPrefs.GetFloat("xpos1"));
                    ypos = PlayerPrefs.GetFloat("ypos1");
                    Debug.Log(PlayerPrefs.GetFloat("ypos1"));
                    dir = PlayerPrefs.GetInt("dir1");
                    break;
                case 2:
                    xpos = PlayerPrefs.GetFloat("xpos2");
                    ypos = PlayerPrefs.GetFloat("ypos2");
                    dir = PlayerPrefs.GetInt("dir2");
                    break;
                case 3:
                    xpos = PlayerPrefs.GetFloat("xpos3");
                    ypos = PlayerPrefs.GetFloat("ypos3");
                    dir = PlayerPrefs.GetInt("dir3");
                    break;
            }
        } else {
            xpos = -26;
            ypos = -21.5f;
            dir = 10;
        }

        count = 0;
		counter = 0;
		battleChance = 0;
		delay = 0;
        isInArea = stat.currentLevel - 7;
        player_speed = 3.6f;

        u = KeyCode.W;
        u2 = KeyCode.UpArrow;
        r = KeyCode.D;
        r2 = KeyCode.RightArrow;
        d = KeyCode.S;
        d2 = KeyCode.DownArrow;
        l = KeyCode.A;
        l2 = KeyCode.LeftArrow;

        anim = this.GetComponent<Animator>();
        anim.SetInteger("Direction", dir);

        battle = false;
        switching = false;
		shopOpen = false;
		bossLoaded = false;
		orb1 = false;
		orb2 = false;
		orb3 = false;
		orb4 = false;
		
        transform.position = new Vector3(xpos, ypos, -0.05f);
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody2D.fixedAngle = true;

        isInArea = stat.currentLevel - 7;

		Text = "Your Gold: " + stat.gold;
		
        if (isInArea == 3 || isInArea == 9 || isInArea == 11) {        //if in city, cannot battle
			canBattle = false;
		} else {
            canBattle = true;
        }

        count++;
        up = Input.GetKey(u);
        up2 = Input.GetKey(u2);
        right = Input.GetKey(r);
        right2 = Input.GetKey(r2);
        down = Input.GetKey(d);
        down2 = Input.GetKey(d2);
        left = Input.GetKey(l);
        left2 = Input.GetKey(l2);

        if (GameObject.Find("Battle") || GameObject.Find("Pause") || GameObject.Find("Inventory")) keysDisabled = true;
        else if (!switching) keysDisabled = false;

        if (transform.position == new Vector3(xpos, ypos, -0.05f)) {
			doneMoving = true;
            player_speed = 3.6f;
			xposOld = xpos;
			yposOld = ypos;
		} else {
			doneMoving = false;
		}
		
		//Debug.Log(anim.GetInteger("Direction"));
		if(isInArea == 3 && Input.GetKey(KeyCode.Space) && xpos == 53 && ypos == 124.5 && (anim.GetInteger("Direction") == 0 || anim.GetInteger("Direction") == 1)){
			Debug.Log("Bring up shop menu.");
			shopOpen = true;
			keysDisabled = true;
		}
		
		if(isInArea == 5 && !orb1 && Input.GetKey(KeyCode.Space) && xpos == -25 && ypos == 210.5 && (anim.GetInteger("Direction") == 0 || anim.GetInteger("Direction") == 1)){
			stat.chest5_1 = 1;
			stat.orb_wind = 1;
			orb1 = true;
			orb1GUI = true;
		}
		if(isInArea == 6 && !orb2 && Input.GetKey(KeyCode.Space) && xpos == -39 && ypos == 147.5 && (anim.GetInteger("Direction") == 0 || anim.GetInteger("Direction") == 1)){
			stat.chest6_7 = 1;
			stat.orb_fire = 1;
			orb2 = true;
			orb2GUI = true;
		}
		if(isInArea == 7 && !orb3 && Input.GetKey(KeyCode.Space) && xpos == 132 && ypos == 198.5 && (anim.GetInteger("Direction") == 0 || anim.GetInteger("Direction") == 1)){
			stat.chest7_1 = 1;
			stat.orb_earth = 1;
			orb3 = true;
			orb3GUI = true;
		}
		if(isInArea == 8 && !orb4 && Input.GetKey(KeyCode.Space) && xpos == 116 && ypos == 162.5 && (anim.GetInteger("Direction") == 0 || anim.GetInteger("Direction") == 1)){
			stat.chest8_1 = 1;
			stat.orb_water = 1;
			orb4 = true;
			orb4GUI = true;
		}
		if(isInArea == 1 && !chest1_1 && Input.GetKey(KeyCode.Space) && xpos == 1 && ypos == 6.5 && (anim.GetInteger("Direction") == 0 || anim.GetInteger("Direction") == 1)){
			stat.chest1_1 = 1;
			//add item
			stat.gold = stat.gold + 1000;
			chest1_1 = true;
			chest1 = true;
		}

		if(isInArea == 1 && !chest1_2 && Input.GetKey(KeyCode.Space) && xpos == 21 && ypos == -3.5 && (anim.GetInteger("Direction") == 0 || anim.GetInteger("Direction") == 1)){
			stat.chest1_2 = 1;
			//add item
			stat.weapon2 = true;
			chest1_2 = true;
			chest2 = true;
		}

		if(isInArea == 6 && !chest6_1 && Input.GetKey(KeyCode.Space) && xpos == -29 && ypos == 177.5 && (anim.GetInteger("Direction") == 0 || anim.GetInteger("Direction") == 1)){
			stat.chest6_1 = 1;
			//add item
			stat.gold = stat.gold + 1000;
			chest6_1 = true;
			chest3 = true;
		}

		if(isInArea == 6 && !chest6_2 && Input.GetKey(KeyCode.Space) && xpos == -12 && ypos == 177.5 && (anim.GetInteger("Direction") == 0 || anim.GetInteger("Direction") == 1)){
			stat.chest6_2 = 1;
			//add item
			stat.gold = stat.gold + 1000;
			chest6_2 = true;
			chest4 = true;
		}

		if(isInArea == 6 && !chest6_3 && Input.GetKey(KeyCode.Space) && xpos == -27 && ypos == 172.5 && (anim.GetInteger("Direction") == 0 || anim.GetInteger("Direction") == 1)){
			stat.chest6_3 = 1;
			//add item
			stat.gold = stat.gold + 1000;
			chest6_3 = true;
			chest5 = true;
		}

		if(isInArea == 6 && !chest6_4 && Input.GetKey(KeyCode.Space) && xpos == -17 && ypos == 172.5 && (anim.GetInteger("Direction") == 0 || anim.GetInteger("Direction") == 1)){
			stat.chest6_4 = 1;
			//add item
			stat.gold = stat.gold + 1000;
			chest6_4 = true;
			chest6 = true;
		}

		if(isInArea == 6 && !chest6_5 && Input.GetKey(KeyCode.Space) && xpos == -27 && ypos == 162.5 && (anim.GetInteger("Direction") == 0 || anim.GetInteger("Direction") == 1)){
			stat.chest6_5 = 1;
			//add item
			stat.weapon3 = true;
			chest6_5 = true;
			chest7 = true;
		}

		if(isInArea == 6 && !chest6_6 && Input.GetKey(KeyCode.Space) && xpos == -17 && ypos == 162.5 && (anim.GetInteger("Direction") == 0 || anim.GetInteger("Direction") == 1)){
			stat.chest6_6 = 1;
			//add item
			stat.gold = stat.gold + 1000;
			chest6_6 = true;
			chest8 = true;
		}
		
		if(xpos > 40 && xpos < 52 && ypos == 268.5 && !bossLoaded){
			Application.LoadLevel (21);
			bossLoaded = true;
		}
		
		if(up || up2 || right || right2 || down || down2 || left || left2){
			counter = counter  + 1;
			if(counter % 70 == 0){
				battleChance = battleChance + 1;
			}
		}
		//Debug.Log(doneMoving);
		//Debug.Log(battleChance);
        if (count == 10) pause = false;

        if (!keysDisabled) {
            if (doneMoving && !pause) {
                if (anim.GetInteger("Direction") == 0) {
                    if (up || up2) {
                        anim.SetInteger("Direction", 1);
                        ypos++;
						BattleSelection();
                    } else if (right || right2) {
                        anim.SetInteger("Direction", 10);
                        count = 0;
                        pause = true;
                    } else if(down || down2) {
                        anim.SetInteger("Direction", 20);
                        count = 0;
                        pause = true;
                    } else if (left || left2) {
                        anim.SetInteger("Direction", 30);
                        count = 0;
                        pause = true;
                    }
                } else if (anim.GetInteger("Direction") == 1) {
                    if (up || up2) {
                        ypos++;
						BattleSelection();
                    } else {
                        anim.SetInteger("Direction", 0);
                    }
                } else if (anim.GetInteger("Direction") == 10) {
                    if (up || up2) {
                        anim.SetInteger("Direction", 0);
                        count = 0;
                        pause = true;
                    } else if (right || right2) {
                        anim.SetInteger("Direction", 11);
                        xpos++;
						BattleSelection();
                    } else if(down || down2) {
                        anim.SetInteger("Direction", 20);
                        count = 0;
                        pause = true;
                    } else if (left || left2) {
                        anim.SetInteger("Direction", 30);
                        count = 0;
                        pause = true;
                    }
                } else if (anim.GetInteger("Direction") == 11) {
                    if (right || right2) {
                        xpos++;
						BattleSelection();
                    } else {
                        anim.SetInteger("Direction", 10);
                    }
                } else if (anim.GetInteger("Direction") == 20) {
                    if (up || up2) {
                        anim.SetInteger("Direction", 0);
                        count = 0;
                        pause = true;
                    } else if (right || right2) {
                        anim.SetInteger("Direction", 10);
                        count = 0;
                        pause = true;
                    } else if(down || down2) {
                        anim.SetInteger("Direction", 21);
                        ypos--;
						BattleSelection();
                    } else if (left || left2) {
                        anim.SetInteger("Direction", 30);
                        count = 0;
                        pause = true;
                    }
                } else if (anim.GetInteger("Direction") == 21) {
                    if (down || down2) {
                        ypos--;
						BattleSelection();
                    } else {
                        anim.SetInteger("Direction", 20);
                    }
                } else if (anim.GetInteger("Direction") == 30) {
                    if (up || up2) {
                        anim.SetInteger("Direction", 0);
                        count = 0;
                        pause = true;
                    } else if (right || right2) {
                        anim.SetInteger("Direction", 10);
                        count = 0;
                        pause = true;
                    } else if(down || down2) {
                        anim.SetInteger("Direction", 20);
                        count = 0;
                        pause = true;
                    } else if (left || left2) {
                        anim.SetInteger("Direction", 31);
                        xpos--;
						BattleSelection();
                    }
                } else if (anim.GetInteger("Direction") == 31) {
                    if (left || left2) {
                        xpos--;
						BattleSelection();
                    } else {
                        anim.SetInteger("Direction", 30);
                    }
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(xpos, ypos, -0.05f), Time.deltaTime * player_speed);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(xpos, ypos, -0.05f), Time.deltaTime * player_speed);
            if (anim.GetInteger("Direction") == 1) anim.SetInteger("Direction", 0);
            else if (anim.GetInteger("Direction") == 11) anim.SetInteger("Direction", 10);
            else if (anim.GetInteger("Direction") == 21) anim.SetInteger("Direction", 20);
            else if (anim.GetInteger("Direction") == 31) anim.SetInteger("Direction", 30);
        }
	}

	void OnCollisionEnter2D(Collision2D c) {
		if(c.gameObject.tag == "Shop"){
			//code for battle scene
			if(!battle) {
                Time.timeScale = 0;
                Application.LoadLevelAdditive(4);
                battle = true;
            }
		} else {
			player_speed = 0.6f;
			xpos = xposOld;
			ypos = yposOld;
		}
	}

	void BattleSelection(){
		if (canBattle == true) {
			int i = Random.Range (1, 101);
			//i = 2000;
			if (i <= battleChance) {
				Time.timeScale = 0;
				Application.LoadLevelAdditive (3);
				battle = true;
			}
		}
	}
	
	void OnGUI(){
		GUI.skin = guiSkin;
		if(shopOpen){
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.5)/2), (float)0.2 * Screen.height,(float)(Screen.width * 0.5),(float)(Screen.height * 0.6)),"");
			GUI.Label(new Rect((float)(Screen.width/2) - (float)(Screen.width * 0.5/2), (float)(Screen.height * 0.25), (float)(Screen.width * 0.5), (float)(Screen.height * 0.1)), "Shop");
			GUI.Label(new Rect((float)(Screen.width * 0.5) - (float)(Screen.width * 0.2), (float)(Screen.height * 0.8) - (float)(Screen.height * 0.1), (float)(Screen.width * 0.1), (float)(Screen.height * 0.1)), Text);
			if(!feedback){
				if(GUI.Button(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2),(float)(Screen.height * .45), (float)(Screen.width * .2),(float)(Screen.height * 0.1)),"Potion: 50 Gold")){
					if(stat.potions < 99){
						feedback = true;
						if(stat.gold >= 50){
							boughtPotion = true;
							stat.gold = stat.gold - 50;
							stat.potions = stat.potions + 1;
						}
						else{
							noMoneyForPots = true;
						}
						delay = 0;
					}
					else{
						feedback = true;
						didntBuyPotion = true;
						delay = 0;
					}

				}
				if(GUI.Button(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2),(float)(Screen.height * .55), (float)(Screen.width * .2),(float)(Screen.height * 0.1)),"Water Walking Shoes: 5000 Gold")){
					if(!stat.waterBoots){
						feedback = true;
						if(stat.gold >= 5000){
							boughtShoes = true;
							stat.gold = stat.gold - 5000;
							stat.waterBoots = true;
						}
						else{
							noMoneyForBoots = true;
						}
						delay = 0;
					}
					else{
						feedback = true;
						didntBuyShoes = true;
						delay = 0;
					}
				}
				if(GUI.Button(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.1)/2),(float)(Screen.height * .65), (float)(Screen.width * 0.1),(float)(Screen.height * 0.1)),"Close")){
					shopOpen = false;
				}
			}
			else{
				if(delay > 150){
					feedback = false;
					boughtPotion = false;
					didntBuyPotion = false;
					noMoneyForPots = false;
					boughtShoes = false;
					noMoneyForBoots = false;
					didntBuyShoes = false;
				}
				delay = delay + 1;
				if(boughtPotion){
					GUI.Label(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.4)/2), (float)(Screen.height * 0.3), (float)(Screen.width * 0.4), (float)(Screen.height * 0.2)), "You've bought a potion!");
				}
				if(didntBuyPotion){
						GUI.Label(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.4)/2), (float)(Screen.height * 0.3), (float)(Screen.width * 0.4), (float)(Screen.height * 0.2)), "You already have the maximum amount of potions!");
						          }
				if(noMoneyForPots){
					GUI.Label(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.4)/2), (float)(Screen.height * 0.3), (float)(Screen.width * 0.4), (float)(Screen.height * 0.2)), "You don't have enough money for potions!");
				}
				if(boughtShoes){
					GUI.Label(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.4)/2), (float)(Screen.height * 0.3), (float)(Screen.width * 0.4), (float)(Screen.height * 0.2)), "You've bought Water Walking Shoes!");
				}
				if(noMoneyForBoots){
					GUI.Label(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.4)/2), (float)(Screen.height * 0.3), (float)(Screen.width * 0.4), (float)(Screen.height * 0.2)), "You don't have enough money for Water Walking Shoes!");
				}
				if(didntBuyShoes){
					GUI.Label(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.4)/2), (float)(Screen.height * 0.3), (float)(Screen.width * 0.4), (float)(Screen.height * 0.2)), "You already have Water Walking Shoes!");
				}
			}
		}
		if(orb1GUI){
			if(delay > 200){
				orb1GUI = false;
				delay = 0;
			}
			delay = delay + 1;
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"You have attained Wind Orb!");
		}
		if(orb2GUI){
			if(delay > 200){
				orb2GUI = false;
				delay = 0;
			}
			delay = delay + 1;
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"You have attained Fire Orb!");
		}
		if(orb3GUI){
			if(delay > 200){
				orb3GUI = false;
				delay = 0;
			}
			delay = delay + 1;
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"You have attained Earth Orb!");
		}
		if(orb4GUI){
			if(delay > 200){
				orb4GUI = false;
				delay = 0;
			}
			delay = delay + 1;
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"You have attained Water Orb!");
		}
		if(chest1){
			if(delay > 200){
				chest1 = false;
				delay = 0;
			}
			delay = delay + 1;
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"You found 1000 Gold!");
		}
		if(chest2){
			if(delay > 200){
				chest2 = false;
				delay = 0;
			}
			delay = delay + 1;
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"You found a new Sword!");
		}
		if(chest3){
			if(delay > 200){
				chest3 = false;
				delay = 0;
			}
			delay = delay + 1;
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"You found 1000 Gold!");
		}
		if(chest4){
			if(delay > 200){
				chest4 = false;
				delay = 0;
			}
			delay = delay + 1;
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"You found 1000 Gold!");
		}
		if(chest5){
			if(delay > 200){
				chest5 = false;
				delay = 0;
			}
			delay = delay + 1;
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"You found 1000 Gold!");
		}
		if(chest6){
			if(delay > 200){
				chest6 = false;
				delay = 0;
			}
			delay = delay + 1;
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"You found 1000 Gold!");
		}
		if(chest7){
			if(delay > 200){
				chest7 = false;
				delay = 0;
			}
			delay = delay + 1;
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"You found a new Sword!");
		}
		if(chest8){
			if(delay > 200){
				chest8 = false;
				delay = 0;
			}
			delay = delay + 1;
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"You found 1000 Gold!");
		}
	}
}
