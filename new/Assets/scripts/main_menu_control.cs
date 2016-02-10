using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class main_menu_control : MonoBehaviour {

	public GUISkin custom;
	bool about_menu = false;

	void Start()
	{
		custom.button.fontSize = Screen.height / 10;
		custom.label.fontSize = Screen.height / 15;
		custom.box.fontSize = Screen.height / 7;
	}
	
	void OnGUI()
	{
		GUI.skin = custom;

			GUI.Box (new Rect (Screen.width * 0.00f, Screen.height * 0.05f,
		                   	Screen.width * 1f, Screen.height * 0.9f), "Hungry Fly Game");

			if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.2f,
			                          Screen.width * 0.5f, Screen.height * 0.1f),
		                	"Game")) {
				Application.LoadLevel (1);
			}

			if (about_menu) {
				GUI.Label (new Rect (Screen.width * 0.1f, Screen.height * 0.45f,
			                   Screen.width * 0.8f, Screen.height * 0.4f),
				           	   "just slide your finger over the screen\n"+
				               "to set move direction and pick up the goodies\n"+
				               "while time is not come out");
			}
			if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.85f,
		                          		Screen.width * 0.5f, Screen.height * 0.1f), "?")) {
				about_menu = !about_menu;
			}
	}
}
