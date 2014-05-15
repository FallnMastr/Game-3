using UnityEngine;
using System.Collections;

public class GameDialogGUI : MonoBehaviour {

	public GUISkin Dialog_GUISkin;
	public GUISkin Thought_GUISkin;
	public GUISkin Sign_GUISkin;
	
	public Texture Dialog_Texture;
	public Texture Sign_Texture;
	public Texture Thought_Texture;

	int top;
	int left;
	int width;
	int height;

	int fontSize;
	int lineSpace;

	string textShown;

	// constants for type of dialog box to show
	const int typeSpeech = 1, typeSign = 2, typeThought = 3;

	// true if any dialog is needed to be shown
	bool doShowDialog,doShowThought,doShowSign;

	int counter;

	// Use this for initialization
	void Start () {
	
		counter = 0;

		top = Screen.height * 3 / 4;
		left = Screen.width/5;
		height = Screen.height - top - 10;
		width = Screen.width *3/5 ;

		doShowDialog = false;
		doShowSign = false;
		doShowThought = false;

		fontSize = Screen.height/25;
	}
	
	// Update is called once per frame
	void Update () {
		/*counter++;
		if (counter % 100 == 0) {
			close ();
			showDialog ("dialog");
		}
		if (counter % 200 == 0) {
			close ();
			showSign("sign");
		}
		if (counter % 300 == 0) {
			close ();
			showThought("thought");
		}
*/
	}

	void OnGUI(){

		Rect speechRect = new Rect (left, top, width, height);


		if (doShowDialog) {
			GUI.skin = Dialog_GUISkin;
			GUI.skin.textArea.fontSize = fontSize;
			GUI.DrawTexture(speechRect,Dialog_Texture);
			GUI.TextArea(speechRect,textShown);
				}
		if (doShowSign) {
			GUI.skin = Sign_GUISkin;
			GUI.skin.textArea.fontSize = fontSize;
			GUI.DrawTexture(speechRect,Sign_Texture);
			GUI.TextArea(speechRect,textShown);
				}
		if(doShowThought){
			GUI.skin = Thought_GUISkin;
			GUI.skin.textArea.fontSize = fontSize;
			GUI.DrawTexture(speechRect,Thought_Texture);
			GUI.TextArea(speechRect,textShown);
			}
	}

	public void showDialog(string text){
		textShown = text;
		doShowDialog = true;
	}
	public void showSign(string text){
		textShown = text;
		doShowSign = true;
	}
	public void showThought(string text){
		textShown = text;
		doShowThought = true;
	}
	// closes a dialog, sign, or thought box
	void close(){
		doShowDialog = false;
		doShowSign = false;
		doShowThought = false;
	}
}
