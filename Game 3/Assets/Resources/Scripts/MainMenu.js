var guiSkin : GUISkin;

public var saved_games = false;
public var new_game = false;
public var fileExists = false;


function Menu() {

	
	GameObject.Destroy(GameObject.Find("Manager"));
	
	GUI.BeginGroup(Rect(0,0,Screen.width,Screen.height));
	
	//GUI.Box(Rect(0,0,Screen.width,Screen.height), "");
	
	GUI.skin.label.normal.textColor = Color.black;
	GUI.Label(new Rect(Screen.width/2 - 252,100,500,200),"The DraLoren Temple");
	GUI.Label(new Rect(Screen.width/2 - 248,100,500,200),"The DraLoren Temple");
	GUI.Label(new Rect(Screen.width/2 - 250,102,500,200),"The DraLoren Temple");
	GUI.Label(new Rect(Screen.width/2 - 250,98,500,200),"The DraLoren Temple");
	GUI.skin.label.normal.textColor = Color.white;
	GUI.Label(new Rect(Screen.width/2 - 250,100,500,200),"The DraLoren Temple");
	
	
	if (saved_games == false && new_game == false) {
		if(GUI.Button(Rect(50,Screen.height - 80,180,40),"Load Game")) {
			saved_games = true;
		}
	
		if(GUI.Button(Rect(Screen.width/2 - 90,Screen.height - 80,180,40),"New Game")) {
			new_game = true;
		}	
	
		if(GUI.Button(Rect(Screen.width - 230,Screen.height - 80,180,40),"Credits")) {
			Application.LoadLevel(19);
		}	
	}
	if (saved_games == true && new_game == false) {
		if(GUI.Button(Rect(50,Screen.height - 120,180,40),"File 1") && PlayerPrefs.GetInt("file1") == 1) {
			PlayerPrefs.SetInt("saveState", 1);
			PlayerPrefs.SetInt("Load", 1);
			Application.LoadLevel(7);
		}
	
		if(GUI.Button(Rect(Screen.width/2 - 90,Screen.height - 120,180,40),"File 2") && PlayerPrefs.GetInt("file2") == 1) {
			PlayerPrefs.SetInt("saveState", 2);
			PlayerPrefs.SetInt("Load", 1);
			Application.LoadLevel(7);
		}	
	
		if(GUI.Button(Rect(Screen.width - 230,Screen.height - 120,180,40),"File 3") && PlayerPrefs.GetInt("file3") == 1) {
			PlayerPrefs.SetInt("saveState", 3);
			PlayerPrefs.SetInt("Load", 1);
			Application.LoadLevel(7);
		}
		if(GUI.Button(Rect(Screen.width/2 - 90,Screen.height - 80,180,40),"Return")) {
			saved_games = false;
		}		
	}
	if (new_game == true) {
		if(GUI.Button(Rect(50,Screen.height - 120,180,40),"File 1")) {
			PlayerPrefs.SetInt("saveState", 1);
			PlayerPrefs.SetInt("file1", 1);
			PlayerPrefs.SetInt("Load", 0);
			Application.LoadLevel(6);
		}
	
		if(GUI.Button(Rect(Screen.width/2 - 90,Screen.height - 120,180,40),"File 2")) {
			PlayerPrefs.SetInt("saveState", 2);
			PlayerPrefs.SetInt("file2", 1);
			PlayerPrefs.SetInt("Load", 0);
			Application.LoadLevel(6);
		}	
	
		if(GUI.Button(Rect(Screen.width - 230,Screen.height - 120,180,40),"File 3")) {
			PlayerPrefs.SetInt("saveState", 3);
			PlayerPrefs.SetInt("file3", 1);
			PlayerPrefs.SetInt("Load", 0);
			Application.LoadLevel(6);
		}
		if(GUI.Button(Rect(Screen.width/2 - 90,Screen.height - 80,180,40),"Return")) {
			saved_games = false;
			new_game = false;
		}
	}
	GUI.EndGroup();
}

function OnGUI() {
	GUI.skin = guiSkin;
	Menu();
}