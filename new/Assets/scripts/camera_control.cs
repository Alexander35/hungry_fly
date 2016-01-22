using UnityEngine;
using System.Collections;

public class camera_control : MonoBehaviour {
	static float minimal_speed=40;
	float speed=minimal_speed;
	Rigidbody rb;
	float sensetivity=0.25f;
	float sensetivity_angle=45;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		sensetivity = scenes_intermediate.getConSens ();
	}

	public void IncreaseSpeed(float speed_plus)
	{
		speed += speed_plus;
		if (speed < minimal_speed)
			speed = minimal_speed;

		Camera.main.fieldOfView = speed / 2;
		//Camera.current.fieldOfView = speed/2;
		if (Camera.main.fieldOfView < 60)
			Camera.main.fieldOfView = 60;
		if (Camera.main.fieldOfView > 110)
			Camera.main.fieldOfView = 110;
	}

	void FixedUpdate () {
		if (Input.GetAxis ("Mouse Y")>sensetivity) {
			rb.AddRelativeTorque(-sensetivity_angle,0,0);
		}
		if (Input.GetAxis ("Mouse Y")<-sensetivity) {
			rb.AddRelativeTorque(sensetivity_angle,0,0);
		}
		if (Input.GetAxis ("Mouse X")<-sensetivity) {
			rb.AddRelativeTorque(0,-sensetivity_angle,0);
		}
		if (Input.GetAxis ("Mouse X")>sensetivity) {
			rb.AddRelativeTorque(0,sensetivity_angle,0);
		}
		rb.AddRelativeForce (0,0,speed);
	}
}
