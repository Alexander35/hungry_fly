using UnityEngine;
using System.Collections;

public class add_life_text_control : MonoBehaviour {
	GUIStyle add_Life_Font;
	static string title = "";
	string Life_Text= "Time :";
	string Score_Text="Score:";
	string Speed_text="Speed:";
	Color current_label_color;
	public GUISkin custom;
	static float _show=0;
	bool set_menu=false;
	float sensetivity=0.35f;
	float sound_toggle=1f;
	Texture2D speedTexture;
	float speed;
	
	void Awake()
	{
		custom.label.fontSize = Screen.height / 20;
		custom.button.fontSize = Screen.height / 17;
		custom.box.fontSize = Screen.height / 7;
		current_label_color = Color.yellow;//custom.label.normal.textColor;
		_show = 0;
		sensetivity = scenes_intermediate.ConSens;
		sound_toggle = scenes_intermediate.Sound;
		speedTexture = new Texture2D (1,1);
		speedTexture.SetPixel (0,0,Color.white);
		speedTexture.Apply ();
	}

	void OnGUI()
	{
		GUI.skin = custom;
		GUI.skin.horizontalSliderThumb.fixedWidth = Screen.width * 0.1f;
		GUI.skin.verticalSlider.fixedWidth = Screen.width * 0.02f;

		if (!set_menu) {
			custom.label.alignment= TextAnchor.MiddleCenter;

			if(GUI.Button (new Rect (Screen.width * 0.0f, Screen.height * 0.55f,
			                     Screen.width * 0.2f, Screen.height * 0.2f),Speed_text))
			{
				this.GetComponent<camera_control> ().IncreaseSpeed (-100f); 

			}

			GUI.DrawTexture(new Rect (Screen.width * 0.01f, Screen.height * 0.64f,
			                          Screen.width * 0.2f*(speed/100), Screen.height * 0.01f),speedTexture);

			if (scenes_intermediate.Milk > 0) {
				if (GUI.Button (new Rect (Screen.width * 0.0f, Screen.height * 0.8f,
			                        Screen.width * 0.2f, Screen.height * 0.2f), "Milk Jet\n X " + scenes_intermediate.Milk)) {
					this.GetComponent<camera_control> ().level_up(-1f*scenes_intermediate.Milk,50*scenes_intermediate.Milk*scenes_intermediate.Milk,0f);
					scenes_intermediate.Milk=0;
				}
			}

			if (GUI.Button (new Rect (Screen.width * 0.0f, Screen.height * 0.01f,
			                     Screen.width * 0.2f, Screen.height * 0.1f), "Settings")) {
				set_menu = !set_menu;
			}

			GUI.Label (new Rect (Screen.width * 0.0f, Screen.height * 0.49f,
		                   Screen.width * 1f, Screen.height * 0.2f), title);

			GUI.Label (new Rect (Screen.width * 0.0f, Screen.height * 0.01f,
		                   Screen.width * 1f, Screen.height * 0.1f), Life_Text);

			GUI.Label (new Rect (Screen.width * 0.0f, Screen.height * 0.89f,
		                   Screen.width * 1f, Screen.height * 0.1f), Score_Text);
		} else {
			custom.label.fontSize= Screen.height / 20;
			custom.label.alignment= TextAnchor.MiddleLeft;
			GUI.Box (new Rect (Screen.width * 0.00f, Screen.height * 0.05f,
			                   Screen.width * 1f, Screen.height * 0.9f), "Game Settings");
			GUI.Label (new Rect (Screen.width * 0.20f, Screen.height * 0.35f,
			                     Screen.width * 0.6f, Screen.height * 0.1f),
			           				"Touchscreen Sensitivity " + sensetivity);
			float newsens = GUI.HorizontalSlider (new Rect (Screen.width * 0.20f, Screen.height * 0.41f,
			                                                Screen.width * 0.6f, Screen.height * 0.1f),
			                                      			sensetivity, 0.1f, 10f);
			
			sensetivity = newsens;
			scenes_intermediate.ConSens=sensetivity;

			GUI.Label (new Rect (Screen.width * 0.20f, Screen.height * 0.45f,
			                     Screen.width * 0.6f, Screen.height * 0.1f),
			           			"Sound Volume ");

			float new_sound_toggle=GUI.HorizontalSlider(new Rect (Screen.width * 0.20f, Screen.height * 0.51f,
			                                  Screen.width * 0.6f, Screen.height * 0.1f),sound_toggle ,0,1f);

			sound_toggle=new_sound_toggle;
			scenes_intermediate.Sound=sound_toggle;
			
			if (GUI.Button (new Rect (Screen.width * 0.25f, Screen.height * 0.85f,
			                          Screen.width * 0.5f, Screen.height * 0.1f),
			                "Game")) {

				camera_control.Sens = sensetivity;
				save_record.Save ();
				set_menu = !set_menu;
			    Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	public static void run(string t)
	{
		_show = 0;
		title=t;
	}
	public void Set_Text(float L, float S)
	{
		Life_Text  =  "Time : "+ Mathf.RoundToInt(L).ToString();
		Score_Text = "Score: "+ Mathf.RoundToInt(S).ToString();
		if (L < 10) {
			_show=0;
			title="time!";
		} 
	}

	public void Set_Speed(float Speed)
	{
		Speed_text = "Speed\n" + Speed+"%";
		speed = Speed;

	}
	void Show_Effect()
	{
		if (_show < 2 && !set_menu) {
			custom.label.normal.textColor= Color.Lerp(current_label_color ,Color.red,Mathf.Cos( Time.time*5));
			custom.label.fontSize = Mathf.RoundToInt( Mathf.Lerp(Screen.height / 20,Screen.height / 10,Mathf.Sin( Time.time*10)));
			_show+=Time.deltaTime;
			if (_show > 1)
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
