using UnityEngine;
using System.Collections;

public class camera_control : MonoBehaviour {
	static float minimal_speed=400;
	float maximum_speed=1100;
	float speed=minimal_speed;
	Rigidbody rb;
	static float sensetivity=15f;
	Vector3 V;

	void OnCollisionEnter (Collision other ) {
		if ((other.gameObject.CompareTag ("wild_sphere")||other.gameObject.CompareTag ("wild_sphere_1")) && scenes_intermediate.getSound()>0) {
			Handheld.Vibrate();
		} 
	}

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		UpdateData ();
		speed = minimal_speed;
	}

	public static void UpdateData()
	{
		sensetivity = scenes_intermediate.getConSens ();
	}

	public void IncreaseSpeed(float speed_plus)
	{
		speed += speed_plus*2;
		if (speed < minimal_speed)
			speed = minimal_speed;
		if (speed > maximum_speed)
			speed = maximum_speed;

		Camera.main.fieldOfView = speed/10;
	}
	void Update()
	{
			for (int i = 0; i < Input.touchCount; i++) {
				if ((scenes_intermediate.getMilk ()>0) && (Input.GetTouch (i).phase == TouchPhase.Began) && 
					(Input.GetTouch (i).position.x > 0) && (Input.GetTouch (i).position.x < Screen.width * 0.2) &&
					(Input.GetTouch (i).position.y > 0) && (Input.GetTouch (i).position.y < Screen.height * 0.2)) {
						this.GetComponent<onStart> ().level_up(-1f, 15f,0f);
						scenes_intermediate.decMilk();
				}
				
			if((Input.GetTouch(i).phase==TouchPhase.Moved) && (Input.GetTouch(i).phase!=TouchPhase.Began) &&
			   		(Input.GetTouch (i).position.x > Screen.width * 0.3) && (Input.GetTouch (i).position.x < Screen.width * 1))
				{
					V = Input.GetTouch(i).deltaPosition;
				}
			}
	}
	void FixedUpdate () {

		rb.AddRelativeTorque (-V.y*sensetivity*speed*Time.deltaTime,V.x*sensetivity*speed*Time.deltaTime,0);
		V = Vector2.zero;
		rb.AddRelativeForce (0, 0, speed);
	}
}
