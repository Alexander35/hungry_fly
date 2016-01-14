using UnityEngine;
using System.Collections;

public class add_life_text_control : MonoBehaviour {

	GUIStyle add_Life_Font;
	GUIStyle Life_Font;
	GUIStyle Score_Font;
	string title = "";
	string Life_Text="Life :";
	string Score_Text="Score :";
	bool show=false;
	public GUISkin custom;
	
	void Start()
	{
		custom.label.fontSize = Screen.height / 20;
		add_Life_Font = new GUIStyle();
		add_Life_Font.fontSize = 1;
		add_Life_Font.normal.textColor= Color.red;

	}

	void OnGUI()
	{
		GUI.skin = custom;
		GUI.Label(new Rect(Screen.width*0.5f, Screen.height*0.05f,
		                   Screen.width*0.5f,Screen.height*1f), title, add_Life_Font);

		GUI.Label (new Rect (Screen.width / 2.5f, Screen.height * 0.05f,
		                   Screen.width / 2.5f, Screen.height * 1f), Life_Text);

		GUI.Label (new Rect (Screen.width / 2.5f, Screen.height * 0.9f,
		                   Screen.width /2.5f, Screen.height * 1f), Score_Text);
	}

	public void run(string t)
	{
		show=true;
		title=t;
	}
	public void Set_Text(float L, float S)
	{
		Life_Text = "Life : "+ Mathf.RoundToInt(L).ToString();
		Score_Text = "Score: "+ Mathf.RoundToInt(S).ToString();
		if (L <= 10) {
			show=true;
			title="time is left out!";
		} 
	}
	void Show_Effect()
	{
		if (show) {
			add_Life_Font.fontSize += 2;
			if (add_Life_Font.fontSize > Screen.height/10)
			{
				add_Life_Font.fontSize=1;
				title="";
				show=false;
			}

		}
	}
	// Update is called once per frame
	void Update () {

		Show_Effect ();

			
		}
}
