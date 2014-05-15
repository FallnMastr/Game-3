using UnityEngine;
using System.Collections;
using System;

public class Move_To_Player : MonoBehaviour {
	player play;	                    // Finds the player controlled object
    Stats stat;

	public Vector3 playerPos;	        // Hold's the player position
	public Vector3	distanceFromWorld;	// Holds the distance the camera is from the player

    public float xDist, yDist;
	
	// Use this for initialization
	void Start () {
        // gets the player's object
        play = (player)FindObjectOfType(typeof(player));
        stat = (Stats)FindObjectOfType(typeof(Stats));

		// change this vector to change camera zoom
		distanceFromWorld = new Vector3(0,0,-10);

        if (PlayerPrefs.GetInt("Load") == 1) {
            switch (stat.saveState) {
                case 1:
                    xDist = PlayerPrefs.GetFloat("xDist1");
                    yDist = PlayerPrefs.GetFloat("yDist1");
                    break;
                case 2:
                    xDist = PlayerPrefs.GetFloat("xDist2");
                    yDist = PlayerPrefs.GetFloat("yDist2");
                    break;
                case 3:
                    xDist = PlayerPrefs.GetFloat("xDist3");
                    yDist = PlayerPrefs.GetFloat("yDist3");
                    break;
            }
        } else {
            xDist = -19;
            yDist = -22;
        }

        transform.position = new Vector3(xDist, yDist, -10);
	}
	
	// Update is called once per frame
	void Update () {
		
		// holds the camera out from the game world by ten units
		playerPos = play.transform.position+distanceFromWorld;
		//transform.position = playerPos;

        if (play.xposOld <= cameraBoundsE(stat.currentLevel) && play.xposOld >= cameraBoundsW(stat.currentLevel)) {
            xDist = play.xposOld;
        } else {
            if (play.xposOld >= cameraBoundsE(stat.currentLevel)) {
                xDist = cameraBoundsE(stat.currentLevel);
            }
            if (play.xposOld <= cameraBoundsW(stat.currentLevel)) {
                xDist = cameraBoundsW(stat.currentLevel);
            }
        }
        if (play.yposOld <= cameraBoundsN(stat.currentLevel) && play.yposOld >= cameraBoundsS(stat.currentLevel)) {
            yDist = play.yposOld - 0.5f;
        } else {
            if (play.yposOld >= cameraBoundsN(stat.currentLevel)) {
                yDist = cameraBoundsN(stat.currentLevel);
            }
            if (play.yposOld <= cameraBoundsS(stat.currentLevel)) {
                yDist = cameraBoundsS(stat.currentLevel);
            }
        }

        if (play.switching) {
            if (transform.position == new Vector3(xDist ,yDist, -10)) {
                play.switching = false;
            } else {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(xDist, yDist, -10), Time.deltaTime * 25);
            }
        } else {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(xDist, yDist, -10), Time.deltaTime * 3.6f);
        }

        if (stat.currentLevel == 8) {
            if (play.xpos == 33 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 9;
                play.switching = true;
                play.keysDisabled = true;
            }
        } else if (stat.currentLevel == 9) {
            if (play.xpos == 32 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 8;
                play.switching = true;
                play.keysDisabled = true;
            } else if (play.ypos == 83.5 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 10;
                play.switching = true;
                play.keysDisabled = true;
            }
        } else if (stat.currentLevel == 10) {
            if (play.ypos == 82.5 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 9;
                play.switching = true;
                play.keysDisabled = true;
            } else if (play.ypos == 148.5 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 11;
                play.switching = true;
                play.keysDisabled = true;
            }
        } else if (stat.currentLevel == 11) {
            if (play.ypos == 147.5 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 10;
                play.switching = true;
                play.keysDisabled = true;
            } else if ((play.xpos == -7 && play.ypos > 180) && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 12;
                play.switching = true;
                play.keysDisabled = true;
            } else if ((play.xpos == -7 && play.ypos < 180) && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 13;
                play.switching = true;
                play.keysDisabled = true;
            } else if ((play.xpos == 99 && play.ypos > 180) && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 14;
                play.switching = true;
                play.keysDisabled = true;
            } else if ((play.xpos == 99 && play.ypos < 180) && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 15;
                play.switching = true;
                play.keysDisabled = true;
            } else if (play.ypos == 214.5 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 16;
                play.switching = true;
                play.keysDisabled = true;
            }
        } else if (stat.currentLevel == 12) {
            if (play.xpos == -6 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 11;
                play.switching = true;
                play.keysDisabled = true;
            }
        } else if (stat.currentLevel == 13) {
            if (play.xpos == -6 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 11;
                play.switching = true;
                play.keysDisabled = true;
            }
        } else if (stat.currentLevel == 14) {
            if (play.xpos == 98 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 11;
                play.switching = true;
                play.keysDisabled = true;
            }
        } else if (stat.currentLevel == 15) {
            if (play.xpos == 98 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 11;
                play.switching = true;
                play.keysDisabled = true;
            }
        } else if (stat.currentLevel == 16) {
            if (play.ypos == 213.5 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 11;
                play.switching = true;
                play.keysDisabled = true;
            } else if (play.ypos == 233.5 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 17;
                play.switching = true;
                play.keysDisabled = true;
            }
        } else if (stat.currentLevel == 17) {
            if ((play.ypos == 232.5 && play.xpos > 44 && play.xpos < 47) && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 16;
                play.switching = true;
                play.keysDisabled = true;
            } else if (play.ypos == 254.5 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 18;
                play.switching = true;
                play.keysDisabled = true;
            }
        } else if (stat.currentLevel == 18) {
            if (play.ypos == 253.5 && play.keysDisabled == false) {
                stat.switchLevel = true;
                stat.newLevel = 17;
                play.switching = true;
                play.keysDisabled = true;
            }
        }
	}

    // Functions used to keep the camera from scrolling past the edge of the plane
    int cameraBoundsN (int currentLevel) {
        // according to the currentLevel it returns the camera's northern bounds
        if (currentLevel == 8) {
            return 22;
        } else if (currentLevel == 9) {
            return 73;
        } else if (currentLevel == 10) {
            return 138;
        } else if (currentLevel == 11) {
			return 203;
		} else if (currentLevel == 12) {
            return 205;
		} else if (currentLevel == 13) {
            return 170;
		} else if (currentLevel == 14) {
            return 206;
		} else if (currentLevel == 15) {
            return 170;
		} else if (currentLevel == 16) {
            return 238;
		} else if (currentLevel == 17) {
            return 1000;
		} else if (currentLevel == 18) {
            return 1000;
		}

        return 0;
    }
    int cameraBoundsS (int currentLevel) {
        // according to the currentLevel it returns the camera's southern bounds
        if (currentLevel == 8) {
            return -22;
        } else if (currentLevel == 9) {
            return 20;
        } else if (currentLevel == 10) {
            return 94;
        } else if (currentLevel == 11) {
            return 159;
		} else if (currentLevel == 12) {
            return 191;
		} else if (currentLevel == 13) {
            return 156;
		} else if (currentLevel == 14) {
            return 192;
		} else if (currentLevel == 15) {
            return 156;
		} else if (currentLevel == 16) {
            return 224;
		} else if (currentLevel == 17) {
            return -1000;
		} else if (currentLevel == 18) {
            return -1000;
		}

        return 0;
    }
    int cameraBoundsE (int currentLevel) {
        // according to the currentLevel it returns the camera's eastern bounds
        if (currentLevel == 8) {
            return 19;
        } else if (currentLevel == 9) {
            return 46;
        } else if (currentLevel == 10) {
            return 85;
        } else if (currentLevel == 11) {
            return 85;
		} else if (currentLevel == 12) {
            return -20;
		} else if (currentLevel == 13) {
            return -20;
		} else if (currentLevel == 14) {
            return 120;
		} else if (currentLevel == 15) {
            return 120;
		} else if (currentLevel == 16) {
            return 65;
		} else if (currentLevel == 17) {
            return 1000;
		} else if (currentLevel == 18) {
            return 1000;
		}
		
        return 0;
    }
    int cameraBoundsW (int currentLevel) {
        // according to the currentLevel it returns the camera's western bounds
        if (currentLevel == 8) {
            return -19;
        } else if (currentLevel == 9) {
            return 46;
        } else if (currentLevel == 10) {
            return -3;
        } else if (currentLevel == 11) {
            return 7;
		} else if (currentLevel == 12) {
            return -28;
		} else if (currentLevel == 13) {
            return -28;
		} else if (currentLevel == 14) {
            return 112;
		} else if (currentLevel == 15) {
            return 112;
		} else if (currentLevel == 16) {
            return 27;
		} else if (currentLevel == 17) {
            return -1000;
		} else if (currentLevel == 18) {
            return -1000;
		}

        return 0;
    }
}
