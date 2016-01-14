using UnityEngine;
using System.Collections;


public class menu_control : MonoBehaviour {

	public GUISkin custom;
	int Scorecurrent=0;
	int Scorebest=0;
	void Start()
	{
		Scorecurrent = Mathf.RoundToInt( scenes_intermediate.getScore ());
		Scorebest = save_record.Save (Scorecurrent);
		custom.button.fontSize = Screen.height / 10;
		custom.label.fontSize = Screen.height / 10;
	}

	void OnGUI()
	{
		GUI.skin = custom;
		GUI.Label(new Rect(Screen.width*0.35f, Screen.height*0.05f,
		                   Screen.width*0.5f,Screen.height*0.1f), "Game Over");
		 
		if (Scorebest == Scorecurrent) {
			Color current_color = GUI.color;
			GUI.color = Color.red;
			if (GUI.Button (new Rect (Screen.width * 0.01f, Screen.height * 0.15f,
			                          Screen.width * 0.99f, Screen.height * 0.3f),
			                "Hey, It is the new record! : " + Scorebest)) {
				Sharing_script.shareText(
					"Hey, i am gain the new record in  the HUNGRY FLY GAME: "+Scorebest
						+" can you do it?"
				);

			}
			GUI.color = current_color;
		} else {

			if (GUI.Button (new Rect (Screen.width * 0.01f, Screen.height * 0.15f,
		                         	 Screen.width * 0.99f, Screen.height * 0.3f),
		                			"Score: " + Scorecurrent
									+" of best: " + Scorebest)) {
				Sharing_script.shareText (
					"What's up! I am playing in the HUNGRY FLY GAME and get "
						+Scorecurrent+" score points"
				);
			}

		}



		if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.7f,
		                          Screen.width * 0.5f, Screen.height * 0.1f), "Rate me!")) {
			//Application.LoadLevel (0);
		}
		if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.85f,
		                          Screen.width * 0.5f, Screen.height * 0.1f), " Play Again?")) {
			Application.LoadLevel (1);
		}
	}
}
