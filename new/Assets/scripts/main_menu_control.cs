using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class main_menu_control : MonoBehaviour {

	public GUISkin custom;
	bool about_menu = false;
	bool set_menu=false;
	float sensetivity=0.20f;


	void Start()
	{
		save_record.Read ();
		custom.button.fontSize = Screen.height / 10;
		custom.label.fontSize = Screen.height / 15;
		custom.box.fontSize = Screen.height / 7;
		sensetivity = scenes_intermediate.getConSens ();
	}
	
	void OnGUI()
	{
		GUI.skin = custom;

		if (!set_menu) {
			GUI.Box (new Rect (Screen.width * 0.00f, Screen.height * 0.05f,
		                   	Screen.width * 1f, Screen.height * 0.9f), "Hungry Fly Game");

			if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.2f,
			                          Screen.width * 0.5f, Screen.height * 0.1f),
		                	"Game")) {
				Application.LoadLevel (1);
			}
			if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.35f,
			                          Screen.width * 0.5f, Screen.height * 0.1f),
			                "Settings")) {
				
				set_menu=!set_menu;
				about_menu=false;
			}

			if (about_menu) {
				GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.45f,
			                   Screen.width * 0.8f, Screen.height * 0.4f),
			         		   "set the direction of the sliding movements on the screen\n" +
							   "collect items until the time runs out\n" +
							   "items add or take away time and increase or decrease the speed");
			}
			if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.85f,
		                          		Screen.width * 0.5f, Screen.height * 0.1f), "?")) {
				about_menu = !about_menu;
				set_menu = false;
			}
		} else {
			GUI.Box (new Rect (Screen.width * 0.00f, Screen.height * 0.05f,
			                   	Screen.width * 1f, Screen.height * 0.9f), "Settings");
			
			if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.2f,
			                          	Screen.width * 0.5f, Screen.height * 0.1f),
			                				"flags")) {
				
				
				//Application.LoadLevel (0);
			}
			GUI.Label (new Rect (Screen.width * 0.25f, Screen.height * 0.35f,
			                               Screen.width * 0.5f, Screen.height * 0.1f),
			                     			"Touchscreen Sensitivity");

			float newsens = GUI.HorizontalSlider (new Rect (Screen.width * 0.25f, Screen.height * 0.41f,
			                                		Screen.width * 0.5f, Screen.height * 0.1f),
			                      						sensetivity,0.10f, 3f);

			sensetivity=newsens;



			
			if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.85f,
			                          Screen.width * 0.5f, Screen.height * 0.1f),
			                				"Game")) {
				scenes_intermediate.setConSens(sensetivity);
				save_record.Save();
				Application.LoadLevel (1);
			}
		}
	}
}
