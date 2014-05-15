using UnityEngine;
using System.Collections;

public class BattleMenu : MonoBehaviour{
	public GUISkin guiSkin;
	
	public AudioSource run_away;
	
	battle battleScene;
	Stats hero;
    playerBattle anim;
	
	int randomNumber;
	public int counter;
	
	public bool usingItem;
	public bool runAway;
	public bool runSuccessful;
	public bool playedOnce;								//Keeps track of whether or not run_away has played
	public bool potionUsed;								//Keeps track of whether or not a potion has been used
	
	public string Text;

    public bool anim_guard;
	
	void Start(){
		battleScene = (battle)FindObjectOfType(typeof(battle));
		hero = (Stats)FindObjectOfType(typeof(Stats));
        anim = (playerBattle)FindObjectOfType(typeof(playerBattle));
		
		run_away = (AudioSource)gameObject.AddComponent("AudioSource");
        AudioClip myAudioClipf;
        myAudioClipf = (AudioClip)Resources.Load("Sound FX/run_away");
        run_away.clip = myAudioClipf;
        run_away.volume = 1;
        run_away.loop = false;
		
		runAway = false;
		playedOnce = false;
		potionUsed = false;
		
		

        anim_guard = false;
	}
	
	void Update(){
		Text = "Potion " + hero.potions;
	}
	
	void OnGUI(){
		GUI.skin = guiSkin;
		if(battleScene.actionCommitted == false){
			if(runAway == false){
				if(battleScene.displayWinText == false){
					GUI.Box(new Rect(Screen.width/2 - (float)((Screen.width * 0.2)/2),(float)0.8 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.14)),"");
				
					if(GUI.Button(new Rect(Screen.width/2 - (float)(Screen.width * 0.05) - (float)(Screen.width * 0.03), (float)(0.8 * Screen.height) + (float)(Screen.height * 0.03), (float)(Screen.width *.05), (float)(Screen.height * 0.03)), "Attack"))
					{
						battleScene.playerAttacking = true;
					}
		
					if(GUI.Button(new Rect((float)(Screen.width/2 + (float)(Screen.width * 0.03)),(float)(0.8 * Screen.height) + (float)(Screen.height * 0.03), (float)(Screen.width * .05),(float)(Screen.height * 0.03)),"Guard"))
					{
						battleScene.playerGuarding = true;
                        anim.bat = 2;
					}	
			
					if(GUI.Button(new Rect(Screen.width/2 - (float)(Screen.width * 0.05) - (float)(Screen.width * 0.03),(float)(Screen.height * .8) + (float)(Screen.height * 0.09),(float)(Screen.width * .05),(float)(Screen.height * 0.03)),Text) || Input.GetKey(KeyCode.P)){
						//add item code
						if(hero.potions > 0 && battleScene.playerCurrentHP < battleScene.playerMaxHP && potionUsed == false){
							battleScene.playerCurrentHP = battleScene.playerCurrentHP + 500;
							Debug.Log(battleScene.playerCurrentHP > battleScene.playerMaxHP);
							if(battleScene.playerCurrentHP > battleScene.playerMaxHP){
								battleScene.playerCurrentHP = battleScene.playerMaxHP;
							}
							battleScene.usingItem = true;
							potionUsed = true;
							hero.potions = hero.potions - 1;
						}
					}

					if(GUI.Button(new Rect((float)(Screen.width/2 + (float)(Screen.width * 0.03)),(float)(0.8 * Screen.height) + (float)(Screen.height * 0.09),(float)(Screen.width * .05) , (float)(Screen.height * 0.03)),"Run") || Input.GetKey(KeyCode.R)){
						runAway = true;
						battleScene.canHit = false;
						battleScene.canGuard = false;
						battleScene.canPotion = false;
						counter = 0;
						randomNumber = Random.Range(0,100);
						// 10% chance to not run successfully
						if(randomNumber > 25){
							runSuccessful = true;
						}
						else{
							runSuccessful = false;
						}
					}
				}
				}
			else{
				//draw box
				if(runSuccessful == true){
					if(playedOnce == false){
						run_away.Play();
						playedOnce = true;
					}
					GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"You have escaped!");
					if(GUI.Button(new Rect((float)(Screen.width/2 - (float)(Screen.width * 0.05)/2),(float)(Screen.height * .85), (float)(Screen.width * .05),20),"Exit") || Input.GetKey(KeyCode.E)){
						battleScene.battleOver = true;
						battleScene.battleEscaped = true;
					}
				}
				else{
					//print failure
					GUI.Box(new Rect((float)(Screen.width/2) - (float)((Screen.width * 0.2)/2), (float)0.3 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.2)),"Could not escape!");
					//delay
					if(counter > 100){
						battleScene.enemyTurn = true;
						battleScene.playerTurn = false;
						runAway = false;
					}
					counter = counter + 1;
				}
			}
		}
	}
}