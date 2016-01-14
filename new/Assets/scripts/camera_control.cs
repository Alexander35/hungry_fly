using UnityEngine;
using System.Collections;

public class camera_control : MonoBehaviour {
	private float speed=20f;
	private float startx;
	private float starty;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void IncreaseSpeed(float speed_plus)
	{
		speed += speed_plus;
		if (speed < 20f)
			speed = 20f;
	}

	void FixedUpdate () {
		if (Input.GetAxis ("Mouse Y")>0.35f) {
			rb.AddRelativeTorque(-30,0,0);
		}
		if (Input.GetAxis ("Mouse Y")<-0.35f) {
			rb.AddRelativeTorque(30,0,0);
		}
		if (Input.GetAxis ("Mouse X")<-0.35f) {
			rb.AddRelativeTorque(0,-30,0);
		}
		if (Input.GetAxis ("Mouse X")>0.35f) {
			rb.AddRelativeTorque(0,30,0);
		}
		rb.AddRelativeForce (0,0,speed);
	}
}
