using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {
	player play;
	Stats hero;

    public int hp, str, vit, spd;   	// Enemy stats to be used during battles
	public int monsterLevel;			// Level of monster
    public int monsterNumber;			// type of monster
	public int isInArea;				// area that the hero is in
	
    /*void Awake () {
        DontDestroyOnLoad(gameObject);
    }*/

	// Use this for initialization
	void Start () {
		play = (player)FindObjectOfType(typeof(player));
		hero = (Stats)FindObjectOfType(typeof(Stats));		
	}
	
	// Update is called once per frame
	void Update () {
        isInArea = play.isInArea;
	}
	
	public void decideMonster () {
		switch(isInArea) {
			case 1: //Plains Area
				monsterNumber = Random.Range(1,4);
				// 1,4
				break;
			case 2: //Plains Area 2
				monsterNumber = Random.Range(1,5);
				break;
			case 3: //Town
				break;
			case 4: //The Hub
				monsterNumber = Random.Range(2,5);
				break;
			case 5: //Mountains
				monsterNumber = Random.Range(4,7);
				break;
			case 6: //Desert
				monsterNumber = Random.Range(6,10);
				break;
			case 7: //Plains Maze
				monsterNumber = Random.Range(10,13);
				break;
			case 8: //Lake
				monsterNumber = Random.Range(13,15);
				break;
			case 9: //Temple Front
				break;
			case 10: //Temple 1
				monsterNumber = Random.Range(15,20);
				break;
			case 11: //Temple 2
				break;
		}
	}
	
	public void setMonsterStats () {
		switch(monsterNumber) {
			case 1:
				monsterLevel = hero.heroLevel;
				hp = 350 + (monsterLevel * 30);
				str = 2 + monsterLevel;
				vit = 1 + (monsterLevel * 3);
				spd = 10;
				break;
			case 2:
				monsterLevel = hero.heroLevel + 3;
				hp = 450 + (monsterLevel * 30);
				str = 2 + monsterLevel;
				vit = 1 + (monsterLevel * 3);
				spd = 10;
				break;
			case 3:
				monsterLevel = hero.heroLevel + 2;
				hp = 400 + (monsterLevel * 30);
				str = 2 + monsterLevel;
				vit = 1 + (monsterLevel * 3);
				spd = 10;
				break;
			case 4:
				monsterLevel = hero.heroLevel + 2;
				hp = 500 + (monsterLevel * 30);
				str = 3 + monsterLevel;
				vit = 2 + (monsterLevel * 3);
				spd = 10;
				break;
			case 5:
				monsterLevel = hero.heroLevel + 3;
				hp = 600 + (monsterLevel * 30);
				str = 5 + monsterLevel;
				vit = 4 + (monsterLevel * 3);
				spd = 10;
				break;
			case 6:
				monsterLevel = hero.heroLevel + 4;
				hp = 750 + (monsterLevel * 30);
				str = 6 + monsterLevel;
				vit = 8 + (monsterLevel * 3);
				spd = 10;
				break;
			case 7:
				monsterLevel = hero.heroLevel + 3;
				hp = 600 + (monsterLevel * 30);
				str = 4 + monsterLevel;
				vit = 3 + (monsterLevel * 3);
				spd = 10;
				break;
			case 8:
				monsterLevel = hero.heroLevel + 5;
				hp = 1000 + (monsterLevel * 30);
				str = 8 + monsterLevel;
				vit = 6 + (monsterLevel * 3);
				spd = 10;
				break;
			case 9:
				monsterLevel = hero.heroLevel + 4;
				hp = 650 + (monsterLevel * 30);
				str = 12 + monsterLevel;
				vit = 4 + (monsterLevel * 3);
				spd = 10;
				break;
			case 10:
				monsterLevel = hero.heroLevel + 4;
				hp = 650 + (monsterLevel * 30);
				str = 2 + monsterLevel;
				vit = 20 + (monsterLevel * 3);
				spd = 10;
				break;
			case 11:
				monsterLevel = hero.heroLevel + 4;
				hp = 1050 + (monsterLevel * 30);
				str = 10 + monsterLevel;
				vit = 8 + (monsterLevel * 3);
				spd = 10;
				break;
			case 12:
				monsterLevel = hero.heroLevel + 3;
				hp = 850 + (monsterLevel * 30);
				str = 8 + monsterLevel;
				vit = 8 + (monsterLevel * 3);
				spd = 10;
				break;
			case 13:
				monsterLevel = hero.heroLevel + 3;
				hp = 1200 + (monsterLevel * 30);
				str = 14 + monsterLevel;
				vit = 10 + (monsterLevel * 3);
				spd = 10;
				break;
			case 14:
				monsterLevel = hero.heroLevel + 5;
				hp = 1500 + (monsterLevel * 30);
				str = 20 + monsterLevel;
				vit = 15 + (monsterLevel * 3);
				spd = 10;
				break;
			case 15:
				monsterLevel = hero.heroLevel + 4;
				hp = 2000 + (monsterLevel * 30);
				str = 20 + monsterLevel;
				vit = 10 + (monsterLevel * 3);
				spd = 10;
				break;
			case 16:
				monsterLevel = hero.heroLevel + 5;
				hp = 2250 + (monsterLevel * 30);
				str = 25 + monsterLevel;
				vit = 20 + (monsterLevel * 3);
				spd = 10;
				break;
			case 17:
				monsterLevel = hero.heroLevel + 7;
				hp = 3000 + (monsterLevel * 30);
				str = 22 + monsterLevel;
				vit = 22 + (monsterLevel * 3);
				spd = 10;
				break;
			case 18:
				monsterLevel = hero.heroLevel + 7;
				hp = 2250 + (monsterLevel * 30);
				str = 22 + monsterLevel;
				vit = 40 + (monsterLevel * 3);
				spd = 10;
				break;
			case 19:
				monsterLevel = hero.heroLevel + 7;
				hp = 1500 + (monsterLevel * 30);
				str = 30 + monsterLevel;
				vit = 22 + (monsterLevel * 3);
				spd = 10;
				break;
		}
	}
}
