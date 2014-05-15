using UnityEngine;
using System.Collections;

public class battle : MonoBehaviour {
	public GUISkin guiSkin;
	
	public Vector3 enemyPosition;
	
	public GameObject battlePlane;
	public Texture2D waterScene;
	public Texture2D plainsMazeScene;
	public Texture2D desertScene;
	public Texture2D mountainsScene;
	public Texture2D templeScene;
	
	public Transform eyeball;
	public Transform big_worm;
	public Transform small_worm;
	public Transform snake;
	public Transform slime;
	public Transform ghost;
	public Transform man_eater_flower;
	public Transform pumpking;
	public Transform bee;
	public Transform bat;
	public Transform wolf;
	public Transform beetle;
	public Transform spider;
	public Transform blue_imp;
	public Transform green_imp;
	public Transform red_imp;
	
	public AudioSource enemy_hit;
	public AudioSource player_hit;
	public AudioSource player_hit_guarding;
	public AudioSource level_up;
	public AudioSource potion_use;

	player play;
	Stats hero;
	EnemyStats enemy;
	BattleMenu battleGUI;
	Move_To_Player camera;
	
	public float playerMaxHP, playerCurrentHP;	        //For keeping track of Hero's HP
	public float enemyMaxHP, enemyCurrentHP;	        //For keeping track of enemy's HP
	public int enemyStr, enemyVit;				        //Enemy's stats
	public int playerStr, playerVit;			        //Hero's stats
	public int expGained;						        //Experience gained by winning the battle
	public int goldGained;								//Gold amount gained by winning the battle
	public int playerLevel, playerNewLevel;		        //For keeping track of whether or not player gains a level
	public int counter;
	public int counter2;								//For running delay
	public int strGained, vitGained;					//The amount of str and vit gained on level up
	public double hitValue;						        //for keeping track of what damage value each person attacks for
	public double hitPercent;						    //determines if an attack hits for less or more
	
	public bool battleOver, battleWon, battleEscaped;	//for keeping track of battle status and win status
	public bool playerTurn, enemyTurn;					//for keeping track of whose turn it is
	public bool playerAttacking;						//keeps track of whether or not player is attacking
	public bool enemyGuarding, playerGuarding;			//keeps track of Guarding status
	public bool actionCommitted;						//lets the game know that you have clicked attack or guard
	public bool attackText;								//allows attack text to display
	public bool usingDelay;								//delay is active
	public bool expGiven;								//keeps track of whether or not exp has been given
	public bool displayWinText;							//displays exp gained if battle won
	public bool leveledUp;								//keeps track of whether or not player gained a level
	public bool usingItem;								//player uses an item
	public bool canHit, canGuard, canPotion;			//whether or not the player is able to use these commands
	

	public string Text, Text2, Text3, Text4, goldText;							//the text to be shown to the screen

	// Use this for initialization
	void Start () {
		play = (player)FindObjectOfType(typeof(player));
		hero = (Stats)FindObjectOfType(typeof(Stats));
		enemy = (EnemyStats)FindObjectOfType(typeof(EnemyStats));
		battleGUI = (BattleMenu)FindObjectOfType(typeof(BattleMenu));
		camera = (Move_To_Player)FindObjectOfType(typeof(Move_To_Player));
	
		play.battleChance = 0;
		play.counter = 0;
	
		enemyPosition = camera.transform.position + new Vector3(5, -4, 8);
		enemy.decideMonster();
		enemy.setMonsterStats();
		
		determineMonster();
		
        //textstyle.normal.textColor = UnityEngine.Color.red;
        //textstyle.alignment = TextAnchor.MiddleCenter;
        //textstyle.fontSize = 32;

		//Write code to re-skin background based on isInArea
		switch(play.isInArea){
			case 1:
			case 2:
			case 3:
			case 4:
				break;
			case 5:
				//re-skin background to mountain
				//mountainsScene = (Texture2D)Resources.LoadAssetAtPath("Assets/Resources/Art/Backgrounds/MountainsScreen.png", typeof(Texture2D));
				//battlePlane.renderer.material.mainTexture = mountainsScene;
				break;
			case 6:
				//re-skin background to desert
				//desertScene = (Texture2D)Resources.LoadAssetAtPath("Assets/Resources/Art/Backgrounds/DesertScreen.png", typeof(Texture2D));
				//battlePlane.renderer.material.mainTexture = desertScene;
				break;
			case 7:
				//re-skin to plains maze
				//plainsMazeScene = (Texture2D)Resources.LoadAssetAtPath("Assets/Resources/Art/Backgrounds/PlainsScreen.png", typeof(Texture2D));
				//battlePlane.renderer.material.mainTexture = plainsMazeScene;
				break;
			case 8:
				//re-skin background to lake
				//waterScene = (Texture2D)Resources.LoadAssetAtPath("Assets/Resources/Art/Backgrounds/LakeScreen.png", typeof(Texture2D));
				//battlePlane.renderer.material.mainTexture = waterScene;
				break;
			case 9:
				break;
			case 10:
				//re-skin background to temple
				//templeScene = (Texture2D)Resources.LoadAssetAtPath("Assets/Resources/Art/Backgrounds/TempleScreen.png", typeof(Texture2D));
				//battlePlane.renderer.material.mainTexture = templeScene;
				break;
		}
		
		//write code here to initialize stats based on monster you are battling
		playerTurn = true;
		enemyTurn = false;
		enemyGuarding = false;
		playerGuarding = false;
		attackText = false;
		usingDelay = false;
		displayWinText = false;
		leveledUp = false;
		usingItem = false;
		canHit = true;
		canGuard = true;
		canPotion = true;
				
		playerLevel = hero.heroLevel;
		playerMaxHP = hero.hp;
		playerCurrentHP = hero.currentHP;		//pull from stats.cs
		enemyMaxHP = enemy.hp;
		enemyCurrentHP = enemyMaxHP;		//pull from enemy
		
		playerStr = hero.str;
		playerVit = hero.vit;
		enemyStr = enemy.str;
		enemyVit = enemy.vit;
		
		Text = "+ " + expGained + " experience.";
		Text2 = "You've gained a level.";
		goldText = "+ " + goldGained + " Gold.";
		
		enemy_hit = (AudioSource)gameObject.AddComponent("AudioSource");
        AudioClip myAudioClipa;
        myAudioClipa = (AudioClip)Resources.Load("Sound FX/Hit_Sound_new");
        enemy_hit.clip = myAudioClipa;
        enemy_hit.volume = 1;
        enemy_hit.loop = false;
		
		player_hit = (AudioSource)gameObject.AddComponent("AudioSource");
        AudioClip myAudioClipb;
        myAudioClipb = (AudioClip)Resources.Load("Sound FX/Hit_Sound_new");
        player_hit.clip = myAudioClipb;
        player_hit.volume = 1;
        player_hit.loop = false;
		
		player_hit_guarding = (AudioSource)gameObject.AddComponent("AudioSource");
        AudioClip myAudioClipc;
        myAudioClipc = (AudioClip)Resources.Load("Sound FX/player_hit_guarding");
        player_hit_guarding.clip = myAudioClipc;
        player_hit_guarding.volume = 1;
        player_hit_guarding.loop = false;
		
		level_up = (AudioSource)gameObject.AddComponent("AudioSource");
        AudioClip myAudioClipd;
        myAudioClipd = (AudioClip)Resources.Load("Sound FX/level_up");
        level_up.clip = myAudioClipd;
        level_up.volume = 1;
        level_up.loop = false;
		
		potion_use = (AudioSource)gameObject.AddComponent("AudioSource");
        AudioClip myAudioClipe;
        myAudioClipe = (AudioClip)Resources.Load("Sound FX/potion_use");
        potion_use.clip = myAudioClipe;
        potion_use.volume = 1;
        potion_use.loop = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(battleOver == true){
			if(leveledUp == false){
				hero.currentHP = (int)playerCurrentHP;
			}
			if(battleWon ==  true){
				//give experience
				if(expGiven == false){
					//give Gold
					hero.gold = hero.gold + goldGained;
					//give exp
					hero.currentExperience = hero.currentExperience + expGained;
					hero.updateLevel();
					playerNewLevel = hero.heroLevel;
					if(playerNewLevel > playerLevel){
						leveledUp = true;
						hero.currentHP = hero.hp;
						strGained = hero.strGained;
						vitGained = hero.vitGained;
						Text3 = "+ " + strGained + " Str";
						Text4 = "+ " + vitGained + " Vit";
						level_up.Play();
					}
				}
				expGiven = true;
				
				//add delay to show user output
				displayWinText = true;
				GameObject.Destroy(GameObject.FindWithTag("Enemy"));
				play.battle = false;
			}
			else if(battleEscaped == true){
				if(counter2 > 50){
					Time.timeScale = 1;
					GameObject.Destroy(GameObject.Find("Battle"));
					GameObject.Destroy(GameObject.FindWithTag("Enemy"));
					play.battle = false;
				}
				counter2 = counter2 + 1;
			}
			else{
				//go to game over screen
				Application.LoadLevel(5);
			}
		}
		
        if(playerTurn == true){
			playerVit = hero.vit;			//re-initialize Vit, in case of Guarding
			
			//playerGuarding = false;		//re-initialize Guarding boolean
		
			if(Input.GetKey(KeyCode.F) && canHit){
				playerAttacking = true;
			}
			else if(Input.GetKey(KeyCode.G) && canGuard){
				playerGuarding = true;
			}
			else if(Input.GetKey(KeyCode.P) && canPotion){
				battleGUI.usingItem = true;
			}
		
			if(usingItem == true){
				actionCommitted = true;
				usingItem = false;
				potion_use.Play();
			}
		
			if(playerAttacking == true && actionCommitted == false){
				counter = 0;
				hitValue = ( ( playerStr * 50) - (enemyVit * 5) );
				hitPercent = (Random.Range(-10.0F,11.0F) / 10) * 0.075;
				hitValue = hitValue + (hitValue * hitPercent);
				enemyCurrentHP = enemyCurrentHP - (int)hitValue;

				enemy_hit.Play();
				actionCommitted = true;
				attackText = true;				//show to the player that they attacked
				//playerAttacking = false;		//re-initialize Attacking boolean
			}
			else if(playerGuarding == true && actionCommitted == false){
				//playerGuarding = true;
				actionCommitted = true;
			}
			
			if(enemyCurrentHP < 0){
				battleOver = true;
				battleWon = true;
			}
			
			//end of player's turn
			if(actionCommitted == true){
				playerAttacking = false;
				if(counter >= 100){
					playerTurn = false;
					enemyTurn = true;
					actionCommitted = false;	//re-initialize actionCommitted
				}
				counter = counter + 1;
			}
		}
		else if(enemyTurn == true && battleOver == false){
			enemyVit = enemy.vit;			//re-initialize Vit, in case of Guarding
			enemyGuarding = false;		//re-initialize Guarding boolean
		
			//if(player presses attack){
			//	playerCurrentHP = playerCurrentHP - ( ( playerStr * 35) - (enemyVit * 20) );
			//	actionCommitted = true;
			//}
		
			//if(enemy presses guard){
			//	enemyVit = enemyVit + 10;
			//	enemyGuarding = true;
			//	actionCommitted = true;
			//}
			
			//test - making enemy attack every time
			hitValue = ( ( enemyStr * 20) - (playerVit * 5) );
			hitPercent = (Random.Range(-10.0F,11.0F) / 10) * 0.075;
			hitValue = hitValue + (hitValue * hitPercent);
			if(playerGuarding == false){
				playerCurrentHP = playerCurrentHP - (int)hitValue;
				player_hit.Play();
			}
			else{
				playerCurrentHP = playerCurrentHP - ((int)hitValue / 2);
				player_hit_guarding.Play();
			}
			actionCommitted = true;
			//test - making enemy attack every time
			
			if(playerCurrentHP < 0){
				battleOver = true;
				battleWon = false;
			}
		
			//end of enemy's turn
			if(actionCommitted == true){
				enemyTurn = false;
				playerTurn = true;
				playerGuarding = false;		//re-initialize Guarding boolean
				actionCommitted = false;	//re-initialize actionCommitted
				battleGUI.potionUsed = false;
				canHit = true;
				canGuard = true;
				canPotion = true;
				counter = 0;
				attackText = false;
			}
		}
	}

	
    void OnGUI() {
		GUI.skin = guiSkin;
		if(displayWinText == true){
			GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.4)),"");
			GUI.Label(new Rect((float)0.46 * UnityEngine.Screen.width, (float)0.35 * UnityEngine.Screen.height, 500, 500), Text);
			GUI.Label(new Rect((float)0.46 * UnityEngine.Screen.width, (float)0.4 * UnityEngine.Screen.height, 500, 500), goldText);
			if(leveledUp){
				GUI.Label(new Rect((float)0.46 * UnityEngine.Screen.width, (float)0.5* UnityEngine.Screen.height, 500, 500), Text2);
				GUI.Label(new Rect((float)0.46 * UnityEngine.Screen.width, (float)0.55* UnityEngine.Screen.height, 500, 500), Text3);
				GUI.Label(new Rect((float)0.46 * UnityEngine.Screen.width, (float)0.6 * UnityEngine.Screen.height, 500, 500), Text4);
			}
			if(GUI.Button(new Rect((float)(Screen.width/2)-(float)((Screen.width * 0.05)/2),(float)(Screen.height * .85), (float)(Screen.width * .05),20),"Exit") || Input.GetKey(KeyCode.E)){
				GameObject.Destroy(GameObject.Find("Battle"));
                Time.timeScale = 1;
			}
		}
		/// Enemies' Health Bar ///////////////////
		if(enemyCurrentHP > 0){
			GUI.backgroundColor = Color.white;
			GUI.Box(new Rect((float)0.55 * Screen.width, (float)0.57 * Screen.height, (float)(Screen.width * 0.1), (float)(Screen.height* 0.03)), "");
			if ((enemyCurrentHP/enemyMaxHP) >.75){
				GUI.backgroundColor = Color.green;
			}
			else if((enemyCurrentHP/enemyMaxHP) > .25){
				GUI.backgroundColor = Color.yellow;
			}
			else if((enemyCurrentHP/enemyMaxHP) <= .25){
				GUI.backgroundColor = Color.red;
			}
			if((enemyCurrentHP <= enemyMaxHP) && ((enemyCurrentHP/enemyMaxHP) > .2)){
			GUI.Box(new Rect((float)0.55 * Screen.width, (float)0.57 * Screen.height, (enemyCurrentHP/enemyMaxHP)*(float)(Screen.width * 0.1), (float)(Screen.height * 0.03)), "");
			}
			else if((enemyCurrentHP/enemyMaxHP) <= .2){
				GUI.Box(new Rect((float)0.55 * Screen.width, (float)0.57 * Screen.height,(float)((Screen.width * 0.1)* 0.10), (float)(Screen.height * 0.03)), "");
			}
			else{
				GUI.Box(new Rect((float)0.55 * Screen.width, (float)0.57 * Screen.height, (float)(Screen.width * 0.1), (float)(Screen.height* 0.03)), "");
			}
		}
		////////////////////////////////////////////
		
		/// Player's Health Bar ////////////////////
		if(playerCurrentHP > 0 && !displayWinText){
			GUI.backgroundColor = Color.white;
			GUI.Box(new Rect((float)0.3 * Screen.width, (float)0.57 * Screen.height, (float)(Screen.width * 0.1), (float)(Screen.height* 0.03)), "");
			/// Green Health Bar
			if ((playerCurrentHP/playerMaxHP) >.75){
				GUI.backgroundColor = Color.green;
			}
			/// Yellow Health Bar
			else if((playerCurrentHP/playerMaxHP) > .25){
				GUI.backgroundColor = Color.yellow;
			}
			/// Red Health Bar
			else if((playerCurrentHP/playerMaxHP) <= .25){
				GUI.backgroundColor = Color.red;
			}
			if((playerCurrentHP == playerMaxHP)||(playerCurrentHP < playerMaxHP) && ((playerCurrentHP/playerMaxHP) > .2)){
				GUI.Box(new Rect((float)0.3 * Screen.width, (float)0.57 * Screen.height, (playerCurrentHP/playerMaxHP)*(float)(Screen.width * 0.1), (float)(Screen.height * 0.03)), "");
			}
			else if((playerCurrentHP/playerMaxHP) <= .2){
				GUI.Box(new Rect((float)0.3 * Screen.width, (float)0.57 * Screen.height, (float)((Screen.width * 0.1)* 0.10), (float)(Screen.height * 0.03)), "");
			}
			else{
				GUI.Box(new Rect((float)0.3 * Screen.width, (float)0.57 * Screen.height,(float)(Screen.width * 0.1), (float)(Screen.height* 0.03)), "");
			}
		}
		////////////////////////////////////////////
	}
	
	void determineMonster(){
		switch(enemy.monsterNumber) {
			case 1:	//Slime
				Instantiate(slime, enemyPosition, Quaternion.identity);
				expGained = 25;
				goldGained = 50;
				break;
			case 2: //Bee
				Instantiate(bee, enemyPosition, Quaternion.identity);
				expGained = 35;
				goldGained = 70;
				break;
			case 3: //Snake
				Instantiate(snake, enemyPosition, Quaternion.identity);
				expGained = 50;
				goldGained = 25;
				break;
			case 4: //Small Worm
				Instantiate(small_worm, enemyPosition, Quaternion.identity);
				expGained = 50;
				goldGained = 25;
				break;
			case 5: //Mountain Snake
				Instantiate(snake, enemyPosition, Quaternion.identity);
				expGained = 75;
				goldGained = 25;
				break;
			case 6: //Big Worm
				Instantiate(big_worm, enemyPosition, Quaternion.identity);
				expGained = 150;
				goldGained = 25;
				break;
			case 7: //Desert Small Worm
				Instantiate(small_worm, enemyPosition, Quaternion.identity);
				expGained = 75;
				goldGained = 25;
				break;
			case 8: //Eyeball
				Instantiate(eyeball, enemyPosition, Quaternion.identity);
				expGained = 200;
				goldGained = 25;
				break;
			case 9: //Wolf
				Instantiate(wolf, enemyPosition, Quaternion.identity);
				expGained = 175;
				goldGained = 25;
				break;
			case 10: //Beetle
				Instantiate(beetle, enemyPosition, Quaternion.identity);
				expGained = 200;
				goldGained = 70;
				break;
			case 11: //Spider
				Instantiate(spider, enemyPosition, Quaternion.identity);
				expGained = 250;
				goldGained = 25;
				break;
			case 12: //Bat
				Instantiate(bat, enemyPosition, Quaternion.identity);
				expGained = 200;
				goldGained = 25;
				break;
			case 13: //Slime 2
				Instantiate(slime, enemyPosition, Quaternion.identity);
				expGained = 250;
				goldGained = 50;
				break;
			case 14: //Man Eater Flower
				Instantiate(man_eater_flower, enemyPosition, Quaternion.identity);
				expGained = 350;
				goldGained = 25;
				break;
			case 15: //Ghost
				Instantiate(ghost, enemyPosition, Quaternion.identity);
				expGained = 300;
				goldGained = 25;
				break;
			case 16: //Pumpking
				Instantiate(pumpking, enemyPosition, Quaternion.identity);
				expGained = 450;
				goldGained = 25;
				break;
			case 17: //Blue Imp
				Instantiate(blue_imp, enemyPosition, Quaternion.identity);
				expGained = 550;
				goldGained = 25;
				break;
			case 18: //Green Imp
				Instantiate(green_imp, enemyPosition, Quaternion.identity);
				expGained = 700;
				goldGained = 25;
				break;
			case 19: //Red Imp
				Instantiate(red_imp, enemyPosition, Quaternion.identity);
				expGained = 550;
				goldGained = 25;
				break;
		}
	}
}


