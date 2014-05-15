using UnityEngine;
using System.Collections;

public class boss_battle : MonoBehaviour {
	public GUISkin guiSkin;

	public Vector3 enemyPosition;
	
	public GameObject battlePlane;
	public Texture2D templeScene;
	
	public Transform boss_1;
	public Transform boss_2;
	public Transform boss_3;
	
	public AudioSource enemy_hit;
	public AudioSource player_hit;
	public AudioSource player_hit_guarding;
	public AudioSource level_up;
	public AudioSource potion_use;
	public AudioSource battle_music;

	player play;
	Stats hero;
	Boss_BattleMenu battleGUI;
	//Move_To_Player camera;
	
	public float playerMaxHP, playerCurrentHP;	        //For keeping track of Hero's HP
	public float enemyMaxHP, enemyCurrentHP;	        //For keeping track of enemy's HP
	public int enemyStr, enemyVit;				        //Enemy's stats
	public int playerStr, playerVit;			        //Hero's stats
	public int expGained;						        //Experience gained by winning the battle
	public int goldGained;								//Gold amount gained by winning the battle
	public int playerLevel, playerNewLevel;		        //For keeping track of whether or not player gains a level
	public int counter;
	public int counter2;								//For running delay
	public int counter3, counter4;						//For boss attack 1 and 2
	public int strGained, vitGained;					//The amount of str and vit gained on level up
	public int monsterNumber;							//Keeps track of which form is currently out
	public int randomNumber;							//Calculates whether boss attacks or guards
	public double hitValue;						        //for keeping track of what damage value each person attacks for
	public double hitPercent;						    //determines if an attack hits for less or more
	
	public bool battleOver, battleWon, battleEscaped;	//for keeping track of battle status and win status
	public bool playerTurn, enemyTurn;					//for keeping track of whose turn it is
	public bool playerAttacking;						//keeps track of whether or not player is attacking
	public bool enemyGuarding, playerGuarding;			//keeps track of Guarding status
	public bool actionCommitted;						//lets the game know that you have clicked attack or guard
	public bool usingDelay;								//delay is active
	public bool expGiven;								//keeps track of whether or not exp has been given
	public bool displayWinText;							//displays exp gained if battle won
	public bool leveledUp;								//keeps track of whether or not player gained a level
	public bool usingItem;								//player uses an item
	public bool canHit, canGuard, canPotion;			//whether or not the player is able to use these commands
	public bool monsterChangedOnce, monsterChangedTwice;//whether or not the monster has changed forms
	public bool secondBoss1, secondBoss2, thirdBoss1, thirdBoss2;	//for special battle attacks
	public bool bossGuarding;							//whether or not boss is guarding
	
	public string winText, Text, Text2, Text3, Text4, goldText;							//the text to be shown to the screen

	// Use this for initialization
	void Start () {
		GameObject.Destroy(GameObject.Find("Manager"));
		
		play = (player)FindObjectOfType(typeof(player));
		hero = (Stats)FindObjectOfType(typeof(Stats));
		battleGUI = (Boss_BattleMenu)FindObjectOfType(typeof(Boss_BattleMenu));
		//camera = (Move_To_Player)FindObjectOfType(typeof(Move_To_Player));

		play.counter = 0;
	
		//enemyPosition = camera.transform.position + new Vector3(5, -4, 8);
		enemyPosition = new Vector3(5, -4, -2);
		monsterNumber = 1;
		determineMonster();

		// Re-skin background to Temple
		//templeScene = (Texture2D)Resources.LoadAssetAtPath("Assets/Resources/Art/Backgrounds/TempleScreen.png", typeof(Texture2D));
		//battlePlane.renderer.material.mainTexture = templeScene;

		
		//write code here to initialize stats based on monster you are battling
		playerTurn = true;
		enemyTurn = false;
		enemyGuarding = false;
		playerGuarding = false;
		usingDelay = false;
		displayWinText = false;
		leveledUp = false;
		usingItem = false;
		canHit = true;
		canGuard = true;
		canPotion = true;
		monsterChangedOnce = false;
		monsterChangedTwice = false;
		secondBoss1 = false;
		secondBoss2 = false;
		thirdBoss1 = false;
		thirdBoss2 = false;
				
		playerLevel = hero.heroLevel;
		//playerMaxHP = hero.hp;
		playerMaxHP = 2200;
		playerCurrentHP = hero.currentHP;		//pull from stats.cs
		enemyMaxHP = 11000;
		enemyCurrentHP = enemyMaxHP;
		
		//playerStr = hero.str;
		//playerVit = hero.vit;
		playerStr = 22;
		playerVit = 20;
		enemyStr = 50;
		enemyVit = 50;
		
		winText = "You have defeated the boss!";
		Text = "+ " + 1000 + " experience.";
		Text2 = "You've gained a level.";
		goldText = "+ " + 5000 + " Gold.";
		
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
		
		battle_music = (AudioSource)gameObject.AddComponent("AudioSource");
        AudioClip myAudioClipf;
        myAudioClipf = (AudioClip)Resources.Load("Music/Blam");
        battle_music.clip = myAudioClipf;
        battle_music.volume = 0.25F;
        battle_music.loop = true;
		battle_music.Play();
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
			//cannot escape, so else means death
			else{
				//go to game over screen
				Application.LoadLevel(5);
			}
		}
		
		if(enemyCurrentHP <= 7600 && monsterNumber != 3 && !monsterChangedOnce){
			monsterNumber = 2;
			GameObject.Destroy(GameObject.FindWithTag("Enemy"));
			determineMonster();
			monsterChangedOnce = true;
			secondBoss1 = true;
			battleGUI.bossChanging = true;
		}
		if(enemyCurrentHP <= 1400 && monsterNumber != 3 && !monsterChangedTwice){
			monsterNumber = 3;
			enemyCurrentHP = enemyMaxHP;
			GameObject.Destroy(GameObject.FindWithTag("Enemy"));
			determineMonster();
			monsterChangedTwice = true;
			thirdBoss1 = true;
			battleGUI.bossChanging = true;
		}
		
        if(playerTurn == true){
		
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
				
				if(!bossGuarding){
					hitValue = hitValue + (hitValue * hitPercent);
					enemyCurrentHP = enemyCurrentHP - (int)hitValue;
				}
				else{
					hitValue = hitValue + (hitValue * hitPercent);
					enemyCurrentHP = enemyCurrentHP - ((int)hitValue / 2);
				}

				enemy_hit.Play();
				actionCommitted = true;
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
					bossGuarding = false;
					actionCommitted = false;	//re-initialize actionCommitted
				}
				counter = counter + 1;
			}
		}
		else if(enemyTurn == true && battleOver == false){
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
			if(!secondBoss1 && !secondBoss2 && !thirdBoss1 && !thirdBoss2){
				randomNumber = Random.Range(1,101);
				if(randomNumber > 25){
					hitValue = ( ( enemyStr * 7) - (playerVit * 5) );
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
				}
				else{
					bossGuarding = true;
					battleGUI.bossGuarding = true;
				}
				actionCommitted = true;
			}
			else if(secondBoss1){
				battleGUI.secondBoss1 = true;
				if(counter3 > 250){
					secondBoss1 = false;
					battleGUI.secondBoss1 = false;
					secondBoss2 = true;
					actionCommitted = true;
				}
				counter3 = counter3 + 1;
			}
			else if(secondBoss2){
				hitValue = ( ( enemyStr * 7) - (playerVit * 5) );
				hitPercent = (Random.Range(-10.0F,11.0F) / 10) * 0.075;
				hitValue = hitValue + (hitValue * hitPercent);
				if(playerGuarding == false){
					playerCurrentHP = playerCurrentHP - ((int)hitValue * 3);
					player_hit.Play();
				}
				else{
					playerCurrentHP = playerCurrentHP - ((int)hitValue * 3/2);
					player_hit_guarding.Play();
				}
				actionCommitted = true;
				secondBoss2 = false;
			}
			else if(thirdBoss1){
				battleGUI.thirdBoss1 = true;
				if(counter4 > 250){
					thirdBoss1 = false;
					battleGUI.thirdBoss1 = false;
					thirdBoss2 = true;
					actionCommitted = true;
				}
				counter4 = counter4 + 1;
			}
			else if(thirdBoss2){
				hitValue = ( ( enemyStr * 7) - (playerVit * 5) );
				hitPercent = (Random.Range(-10.0F,11.0F) / 10) * 0.075;
				hitValue = hitValue + (hitValue * hitPercent);
				if(playerGuarding == false){
					playerCurrentHP = playerCurrentHP - ((int)hitValue * 4);
					player_hit.Play();
				}
				else{
					playerCurrentHP = playerCurrentHP - ((int)hitValue * 2);
					player_hit_guarding.Play();
				}
				actionCommitted = true;
				thirdBoss2 = false;
			}
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
			}
		}
	}

	void determineMonster(){
		switch(monsterNumber) {
			case 1:	//Form 1
				Instantiate(boss_1, enemyPosition, Quaternion.identity);
				break;
			case 2: //Form 2
				GameObject.Destroy(GameObject.FindWithTag("Enemy"));
				Instantiate(boss_2, enemyPosition, Quaternion.identity);
				break;
			case 3: //Form 3
				GameObject.Destroy(GameObject.FindWithTag("Enemy"));
				Instantiate(boss_3, enemyPosition, Quaternion.identity);
				break;
		}
	}
	
	void OnGUI() {
		GUI.skin = guiSkin;
		if(displayWinText == true){
			GameObject.Destroy(GameObject.FindWithTag("Enemy"));
			GUI.Box(new Rect((float)0.45 * Screen.width, (float)0.45 * Screen.height,200,200),"");
			GUI.Label(new Rect((float)0.46 * UnityEngine.Screen.width, (float)0.47 * UnityEngine.Screen.height, 500, 500), winText);
			GUI.Label(new Rect((float)0.46 * UnityEngine.Screen.width, (float)0.51 * UnityEngine.Screen.height, 500, 500), Text);
			GUI.Label(new Rect((float)0.46 * UnityEngine.Screen.width, (float)0.55 * UnityEngine.Screen.height, 500, 500), goldText);
			if(leveledUp){
				GUI.Label(new Rect((float)0.46 * UnityEngine.Screen.width, (float)0.58 * UnityEngine.Screen.height, 500, 500), Text2);
				GUI.Label(new Rect((float)0.46 * UnityEngine.Screen.width, (float)0.62 * UnityEngine.Screen.height, 500, 500), Text3);
				GUI.Label(new Rect((float)0.46 * UnityEngine.Screen.width, (float)0.645 * UnityEngine.Screen.height, 500, 500), Text4);
			}
			if(GUI.Button(new Rect((float)(Screen.width/2 - 100),(float)(Screen.height * .85), (float)(Screen.width * .05),20),"Exit") || Input.GetKey(KeyCode.E)){
				GameObject.Destroy(GameObject.Find("Boss_Battle"));
                Time.timeScale = 1;
				Application.LoadLevel(22);
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
}


