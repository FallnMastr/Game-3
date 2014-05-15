using UnityEngine;
using System.Collections;

public class Boss_BattleMenu : MonoBehaviour{
	public GUISkin guiSkin;
	
	public AudioSource run_away;
	
	boss_battle battleScene;
	Stats hero;
    playerBattle anim;
	
	int randomNumber;
	public int counter;
	public int counter2;
	
	public bool usingItem;
	public bool runAway;
	public bool runSuccessful;
	public bool playedOnce;								//Keeps track of whether or not run_away has played
	public bool potionUsed;								//Keeps track of whether or not a potion has been used
	public bool bossChanging;							//Boss is changing its form
	public bool bossGuarding;							//Boss is guarding
	public bool secondBoss1, thirdBoss1;				//Boss's special moves
	
	public string Text;

    public bool anim_guard;
	
	void Start(){
		battleScene = (boss_battle)FindObjectOfType(typeof(boss_battle));
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
		bossGuarding = false;

        anim_guard = false;
	}
	
	void Update(){
		Text = "Potion " + hero.potions;
	}
	
	void OnGUI(){
		GUI.skin = guiSkin;
		if(battleScene.actionCommitted == false){
			if(!secondBoss1 && !thirdBoss1 && !bossChanging && !bossGuarding){
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
						/*runAway = true;
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
						}*/
					}
				}
			}
			else if(bossChanging){
				GUI.Box(new Rect(Screen.width/2 - (float)((Screen.width * 0.2)/2),(float)0.8 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.14)),"It's changing its form!");
				//GUI.Label(new Rect((float)(Screen.width/2) - (float)((Screen.width *0.2)/2), (float)0.85 * UnityEngine.Screen.height, (float)(Screen.width *0.2, 500), "Its changing its form!");
				if(counter2 > 250){
					bossChanging = false;
					counter2 = 0;
				}
				counter2 = counter2 + 1;
			}
			else if(bossGuarding){
				GUI.Box(new Rect(Screen.width/2 - (float)((Screen.width * 0.2)/2),(float)0.8 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.14)),"Boss is guarding");
				//GUI.Label(new Rect((float)0.46 * UnityEngine.Screen.width, (float)0.85 * UnityEngine.Screen.height, 500, 500), "Boss is guarding.");
				if(counter2 > 250){
					bossGuarding = false;
					counter2 = 0;
				}
				counter2 = counter2 + 1;
			}
			else{
				GUI.Box(new Rect(Screen.width/2 - (float)((Screen.width * 0.2)/2),(float)0.8 * Screen.height,(float)(Screen.width * 0.2),(float)(Screen.height * 0.14)),"Boss moves around frantically");
				//GUI.Label(new Rect((float)0.46 * UnityEngine.Screen.width, (float)0.85 * UnityEngine.Screen.height, 500, 500), "Boss moves around frantically!");
			}
		}
	}
}