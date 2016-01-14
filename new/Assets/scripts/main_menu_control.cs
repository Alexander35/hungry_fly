using UnityEngine;
using System.Collections;


public class main_menu_control : MonoBehaviour {
	public GUISkin custom;
	bool about_menu=false;
	void Start()
	{
		custom.button.fontSize = Screen.height / 10;
		custom.label.fontSize = Screen.height / 10;
	}
	
	void OnGUI()
	{
		GUI.skin = custom;

		GUI.Label(new Rect(Screen.width*0.35f, Screen.height*0.05f,
		                   Screen.width*0.7f,Screen.height*0.1f), "Hungry Fly");

		if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.2f,
		                          Screen.width * 0.5f, Screen.height * 0.1f),
		                "Flags")) {
			//Application.LoadLevel (0);
		}

		if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.35f,
		                          Screen.width * 0.5f, Screen.height * 0.1f),
		                "Game")) {
			Application.LoadLevel (1);
		}


		if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.85f,
		                          Screen.width * 0.5f, Screen.height * 0.1f), "?")) {


			transform.Rotate(30,30,30);
			//Application.LoadLevel (0);
		}
		GUI.Box(new Rect(10,10,100,90), "Loader Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
			Application.LoadLevel(1);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
			Application.LoadLevel(2);
		}
	}
}
