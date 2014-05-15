using UnityEngine;
using System.Collections;

public class loadOverlay : MonoBehaviour {

    player play;
    Stats stat;

    bool battle;            // True means a battle is in place
    bool pause;             // True means the game is paused
    bool inventory;         // True means the inventory is open
	bool statsScreen;		// True means the stats screen is open
    
    int delay;              // Set to 0 when one of the scenes loads/unloads

    public KeyCode esc;
    public KeyCode i;
	public KeyCode c;

    void Awake () {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        play = (player)FindObjectOfType(typeof(player));
        stat = (Stats)FindObjectOfType(typeof(Stats));

        esc = KeyCode.Escape;
        i = KeyCode.I;
		c = KeyCode.C;

        battle = play.battle;

        //Application.LoadLevelAdditive(8);

        delay = 0;
	}
	
	// Update is called once per frame
	void Update () {
        delay++;
        bool pau = Input.GetKey(esc);
        bool inv = Input.GetKey(i);
		bool cstats = Input.GetKey(c);

        battle = play.battle;

        if (stat.newLevel == stat.currentLevel) {
            if (stat.currentLevel == 8) {			// Level01
                if (!GameObject.Find("Level01")) Application.LoadLevelAdditive(8);

                if (play.xpos > 19 && play.ypos > 17 && !GameObject.Find("Level02")) {
                    Application.LoadLevelAdditive(9);
                } else if ((play.xpos < 19 || play.ypos < 17) && GameObject.Find("Level02")) {
                    GameObject.Destroy(GameObject.Find("Level02"));
                }
            } else if (stat.currentLevel == 9) {	// Level02
                if (!GameObject.Find("Level02")) Application.LoadLevelAdditive(9);

                if (play.ypos < 26 && !GameObject.Find("Level01")) {
                    Application.LoadLevelAdditive(8);
                } else if (play.ypos > 26 && GameObject.Find("Level01")) {
                    GameObject.Destroy(GameObject.Find("Level01"));
                }

                if (play.ypos > 78 && !GameObject.Find("Level03")) {
                    Application.LoadLevelAdditive(10);
                } else if (play.ypos < 78 && GameObject.Find("Level03")) {
                    GameObject.Destroy(GameObject.Find("Level03"));
                }
            } else if (stat.currentLevel == 10) {	// Level03
                if (!GameObject.Find("Level03")) Application.LoadLevelAdditive(10);

                if ((play.ypos < 94 && play.xpos > 40 && play.xpos < 50) && !GameObject.Find("Level02")) {
                    Application.LoadLevelAdditive(9);
                } else if ((play.ypos > 94 || play.xpos < 40 || play.xpos > 50) && GameObject.Find("Level02")) {
                    GameObject.Destroy(GameObject.Find("Level02"));
                }
				
				if ((play.ypos > 138 && play.xpos > 40 && play.xpos < 50) && !GameObject.Find("Level04")) {
                    Application.LoadLevelAdditive(11);
                } else if ((play.ypos <138 || play.xpos < 40 || play.xpos > 50) && GameObject.Find("Level04")) {
                    GameObject.Destroy(GameObject.Find("Level04"));
                }
            } else if (stat.currentLevel == 11) {	// Level04
                if (!GameObject.Find("Level04")) Application.LoadLevelAdditive(11);

				if ((play.ypos < 159 && play.xpos > 40 && play.xpos < 50) && !GameObject.Find("Level03")) {
                    Application.LoadLevelAdditive(10);
                } else if ((play.ypos > 159 || play.xpos < 40 || play.xpos > 50) && GameObject.Find("Level03")) {
                    GameObject.Destroy(GameObject.Find("Level03"));

                }
				
				if ((play.xpos < 4 && play.ypos > 180) && !GameObject.Find("Level05")) {
                    Application.LoadLevelAdditive(12);
                } else if (play.xpos > 4 && GameObject.Find("Level05")) {
                    GameObject.Destroy(GameObject.Find("Level05"));
                }

                if ((play.xpos < 4 && play.ypos < 180) && !GameObject.Find("Level06")) {
                    Application.LoadLevelAdditive(13);
                } else if (play.xpos > 4 && GameObject.Find("Level06")) {
                    GameObject.Destroy(GameObject.Find("Level06"));
                }

                if ((play.xpos > 88 && play.ypos > 180)  && !GameObject.Find("Level07")) {
                    Application.LoadLevelAdditive(14);
                } else if (play.xpos < 88 && GameObject.Find("Level07")) {
                    GameObject.Destroy(GameObject.Find("Level07"));
                }

                if ((play.xpos > 88 && play.ypos < 180) && !GameObject.Find("Level08")) {
                    Application.LoadLevelAdditive(15);
                } else if (play.xpos < 88 && GameObject.Find("Level08")) {
                    GameObject.Destroy(GameObject.Find("Level08"));
                }

                if ((play.ypos > 204 && play.xpos > 40 && play.xpos < 50) && !GameObject.Find("Level09")) {
                    Application.LoadLevelAdditive(16);
                } else if ((play.ypos < 204 || play.xpos < 40 || play.xpos > 50) && GameObject.Find("Level09")) {
                    GameObject.Destroy(GameObject.Find("Level09"));
                }
			} else if (stat.currentLevel == 12) {	// Level05
                if (!GameObject.Find("Level05")) Application.LoadLevelAdditive(12);

				if (play.xpos > -10 && !GameObject.Find("Level04")) {
                    Application.LoadLevelAdditive(11);
                } else if (play.xpos < -10 && GameObject.Find("Level04")) {
                    GameObject.Destroy(GameObject.Find("Level04"));
                }
			} else if (stat.currentLevel == 13) {	// Level06
                if (!GameObject.Find("Level06")) Application.LoadLevelAdditive(13);

				if (play.xpos > -10 && !GameObject.Find("Level04")) {
                    Application.LoadLevelAdditive(11);
                } else if (play.xpos < -10 && GameObject.Find("Level04")) {
                    GameObject.Destroy(GameObject.Find("Level04"));
                }
			} else if (stat.currentLevel == 14) {	// Level07
                if (!GameObject.Find("Level07")) Application.LoadLevelAdditive(14);

				if (play.xpos < 102 && !GameObject.Find("Level04")) {
                    Application.LoadLevelAdditive(11);
                } else if (play.xpos > 102 && GameObject.Find("Level04")) {
                    GameObject.Destroy(GameObject.Find("Level04"));
                }
			} else if (stat.currentLevel == 15) {	// Level08
                if (!GameObject.Find("Level08")) Application.LoadLevelAdditive(15);

				if (play.xpos < 102 && !GameObject.Find("Level04")) {
                    Application.LoadLevelAdditive(11);
                } else if (play.xpos > 102 && GameObject.Find("Level04")) {
                    GameObject.Destroy(GameObject.Find("Level04"));
                }
			} else if (stat.currentLevel == 16) {	// Level09
                if (!GameObject.Find("Level09")) Application.LoadLevelAdditive(16);

				if ((play.ypos < 224 && play.xpos > 40 && play.xpos < 50) && !GameObject.Find("Level04")) {
                    Application.LoadLevelAdditive(11);
                } else if ((play.ypos > 224 || play.xpos < 40 || play.xpos > 50) && GameObject.Find("Level04")) {
                    GameObject.Destroy(GameObject.Find("Level04"));
                }

                if ((play.ypos == 233.5 && play.xpos > 44 && play.xpos < 47) && !GameObject.Find("Level10")) {
                    Application.LoadLevelAdditive(17);
                } else if (play.ypos == 232.5 && GameObject.Find("Level10")) {
                    GameObject.Destroy(GameObject.Find("Level10"));
                }
			} else if (stat.currentLevel == 17) {	// Level10
                if (!GameObject.Find("Level10")) Application.LoadLevelAdditive(17);

                if (stat.orb_earth == 0) GameObject.Destroy(GameObject.Find("orb_earth"));
                if (stat.orb_fire == 0) GameObject.Destroy(GameObject.Find("orb_fire"));
                if (stat.orb_water == 0) GameObject.Destroy(GameObject.Find("orb_water"));
                if (stat.orb_wind == 0) GameObject.Destroy(GameObject.Find("orb_wind"));

                if (stat.orb_earth == 1 && stat.orb_fire == 1 && stat.orb_water == 1 && stat.orb_wind == 1) GameObject.Destroy(GameObject.Find("Door"));

                if ((play.ypos == 254.5 && play.xpos > 44 && play.xpos < 47) && !GameObject.Find("Level11")) {
                    Application.LoadLevelAdditive(18);
                } else if (play.ypos == 253.5 && GameObject.Find("Level11")) {
                    GameObject.Destroy(GameObject.Find("Level11"));
                }
			} else if (stat.currentLevel == 18) {
                if (!GameObject.Find("Level11")) Application.LoadLevelAdditive(18);
            }
        }

        if (delay >= 50) {
            if (!battle) {
                if (!pause) {
                    if (!inventory) {
						if(!statsScreen) {
						   if (pau) {
							   Time.timeScale = 0;
							   Application.LoadLevelAdditive(1);
							   delay = 0;
							   pause = true;
						   } else if (inv) {
							   Time.timeScale = 0;
							   Application.LoadLevelAdditive(2);
							   delay = 0;
							   inventory = true;
						   } else if (cstats) {
								//code to open cstats screen
								Time.timeScale = 0;
								Application.LoadLevelAdditive(20);
								delay = 0;
								statsScreen = true;
						   }
						} else {
							if (cstats) {
								//code to close cstats screen
								Time.timeScale = 1;
								GameObject.Destroy(GameObject.Find("char stats"));
								delay = 0;
								statsScreen = false;
							}
						}
                    } else {
                        if (inv) {
                            Time.timeScale = 1;
                            GameObject.Destroy(GameObject.Find("Inventory"));
                            delay = 0;
                            inventory = false;
                        }
                    }
                } else {
                    if (pau) {
                        Time.timeScale = 1;
                        GameObject.Destroy(GameObject.Find("Pause"));
                        delay = 0;
                        pause = false;
                    }
                }
            } else {
                /*if (!pause) {
                    if (pau) {
                        Time.timeScale = 0;
                        Application.LoadLevelAdditive(1);
                        delay = 0;
                        pause = true;
                    }
                } else {
                    if (pau) {
                        Time.timeScale = 1;
                        GameObject.Destroy(GameObject.Find("Pause"));
                        delay = 0;
                        pause = false;
                    }
                }*/
            }
        }
	}
}
