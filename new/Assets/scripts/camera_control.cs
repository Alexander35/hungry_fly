using UnityEngine;
using System.Collections;

public class camera_control : onStart {

	static float minimal_speed=4000;
	float maximum_speed=10000;
	float speed=minimal_speed;
	Rigidbody rb;
	static float sensetivity=15f;
	Vector3 V;

	public static float Sens
	{
		set{
			sensetivity=value;
		}
		get{
			return sensetivity;
		}
	}

	public void level_up(float time_plus,float speed_plus,float k)
	{
		for (float i = 1; i <= k; i += 1) {
			Instantiate (wild_sphere, Random.insideUnitSphere * 400 + transform.position, Random.rotation);
			Instantiate (destination, Random.insideUnitSphere * 200 + transform.position, Random.rotation);
			Instantiate (destination_plus, Random.insideUnitSphere * 300 + transform.position, Random.rotation);
			Instantiate (destination_minus, Random.insideUnitSphere *100 + transform.position, Random.rotation);
		}
		
		Sound_Play (0);
		time_plus -= (Score / (ScoreBest+40));
		Time_ += time_plus;
		IncreaseSpeed (speed_plus); 
		add_life_text_control.run (Mathf.RoundToInt(time_plus)+" Time");
	}

	void Awake ()
	{
		Sound_Init ();
		save_record.Read ();
		scenes_intermediate.Milk=2;
		ScoreBest = scenes_intermediate.ScoreBest;
		rb = GetComponent<Rigidbody>();
		sensetivity = scenes_intermediate.ConSens;
		speed = minimal_speed;
		level_up (ScoreBest/10 + 40,ScoreBest*3,20);
		decrease_time ();
	}

	public void IncreaseSpeed(float speed_plus)
	{
		speed += speed_plus;
		speed = Mathf.Clamp (speed, minimal_speed, maximum_speed);
		Camera.main.fieldOfView = speed/100;
		gameObject.GetComponent<add_life_text_control> ().Set_Speed (speed/100);
	}
	void Update()
	{
			for (int i = 0; i < Input.touchCount; i++) {
				
			if((Input.GetTouch(i).phase==TouchPhase.Moved) && (Input.GetTouch(i).phase!=TouchPhase.Began) &&
			   		(Input.GetTouch (i).position.x > Screen.width * 0.3) && (Input.GetTouch (i).position.x < Screen.width * 1))
				{
					V = Input.GetTouch(i).deltaPosition;
				}
			}
		decrease_time ();
	}
	void FixedUpdate () {

		rb.AddRelativeTorque (-V.y*sensetivity*speed*Time.deltaTime,V.x*sensetivity*speed*Time.deltaTime,0);
		V = Vector2.zero;
		rb.AddRelativeForce (0, 0, speed*Time.deltaTime*2);
	}
}
