using UnityEngine;
using System.Collections;

public class add_life_text_control : MonoBehaviour {
	//private GameObject player_sp;
	GUIStyle add_Life_Font;
	string title = "";
	string Life_Text= "Time :";
	string Score_Text="Score:";
	Color current_label_color;
	public GUISkin custom;
	float _show=0;
	
	void Start()
	{
		//player_sp = GameObject.FindGameObjectWithTag ("MainCamera");
		custom.label.fontSize = Screen.height / 20;
		current_label_color = custom.label.normal.textColor;
	}

	void OnGUI()
	{
		GUI.skin = custom;
		if(GUI.Button(new Rect (Screen.width * 0.0f, Screen.height * 0.9f,
		                     Screen.width * 0.1f, Screen.height * 0.1f), "Got Milk"))
		{
			 this.GetComponent<onStart> ().level_up_set_wild_scene (-3f, 40f);
			 run("forward to the new cakes");
			//this.GetComponent<camera_control> ().IncreaseSpeed ();
		}

		GUI.Label (new Rect (Screen.width * 0.0f, Screen.height * 0.49f,
		                   Screen.width * 1f, Screen.height * 0.2f), title);//add_Life_Font);

		GUI.Label (new Rect (Screen.width * 0.0f, Screen.height * 0.01f,
		                   Screen.width * 1f, Screen.height * 0.1f), Life_Text);

		GUI.Label (new Rect (Screen.width * 0.0f, Screen.height * 0.89f,
		                   Screen.width *1f, Screen.height * 0.1f), Score_Text);
	}

	public void run(string t)
	{
		_show = 0;
		title=t;
	}
	public void Set_Text(float L, float S)
	{
		Life_Text =  "Time : "+ Mathf.RoundToInt(L).ToString();
		Score_Text = "Score: "+ Mathf.RoundToInt(S).ToString();
		if (L <= 10) {
			_show=0;
			title="time!";
		} 
	}
	void Show_Effect()
	{
		if (_show<=20) {
			custom.label.normal.textColor= Color.Lerp(current_label_color ,Color.red,Mathf.Cos (Time.time*10) );
			custom.label.fontSize = Mathf.RoundToInt( Mathf.Lerp(Screen.height / 20,Screen.height / 10,Mathf.Cos( Time.time*10)));
			_show ++;
			if (_show== 21)
			{
				custom.label.fontSize= Screen.height / 20;
				custom.label.normal.textColor=current_label_color;
				title="";
			}
		}
	}
	// Update is called once per frame
	void Update () {

		Show_Effect ();
	}
}
