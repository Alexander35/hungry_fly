﻿using UnityEngine;
using System.Collections;


public class menu_control : MonoBehaviour {

	public GUISkin custom;
	int Scorecurrent=0;
	int Scorebest=0;
	void Start()
	{
		Scorecurrent = Mathf.RoundToInt( scenes_intermediate.getScore ());
		Scorebest=Mathf.RoundToInt( scenes_intermediate.getScoreBest ());
		if (Scorecurrent > Scorebest) {
			Scorebest=Scorecurrent;
			scenes_intermediate.setScore(Scorecurrent);
			scenes_intermediate.setScoreBest(Scorecurrent);
			save_record.Save();
		}
		custom.button.fontSize = Screen.height / 10;
		custom.label.fontSize = Screen.height / 10;
		custom.box.fontSize = Screen.height / 7;
	}

	void OnGUI()
	{
		GUI.skin = custom;
		GUI.Box(new Rect(Screen.width*0.00f, Screen.height*0.05f,
		                   Screen.width*1f,Screen.height*0.9f), "It is not the end!");
		 
		if (Scorebest == Scorecurrent) {
			Color current_color = GUI.color;
			GUI.color = Color.red;
			if (GUI.Button (new Rect (Screen.width * 0.01f, Screen.height * 0.15f,
			                          Screen.width * 0.99f, Screen.height * 0.3f),
			                "Hey, you get "+Scorebest+ " score points\nthis is the new record!")) {
				Sharing_script.shareText(
					"Hey, i am gain the new record in  the HUNGRY FLY GAME: "+Scorebest
						+" can you do it better?"
				);

			}
			GUI.color = current_color;
		} else {

			if (GUI.Button (new Rect (Screen.width * 0.01f, Screen.height * 0.15f,
		                         	 Screen.width * 0.99f, Screen.height * 0.3f),
		                			" You Score: " + Scorecurrent
									+"\nBest Score: " + Scorebest)) {
				Sharing_script.shareText (
					"What's up! I am playing in the HUNGRY FLY GAME and this time i am get "
						+Scorecurrent+" score points"
				);
			}

		}



		if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.7f,
		                          Screen.width * 0.5f, Screen.height * 0.1f), "Rate me!")) {
			Application.OpenURL ("THISISWWW");
		}
		if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.85f,
		                          Screen.width * 0.5f, Screen.height * 0.1f), "Play Again?")) {
			Application.LoadLevel (1);
		}
	}
}
