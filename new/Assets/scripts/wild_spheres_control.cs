using UnityEngine;
using System.Collections;

public class wild_spheres_control : destination_control {

	public wild_spheres_control()
	{
		set_param(new Vector3(0,10,0),//time,speed,iteration
		          new Vector3(400f,700f,0f),//speed,border_distance
		          new Vector3(30,20,30)*135);//add torque
	}

	public override void OnTriggerDo()
	{
		player_sp.GetComponent<camera_control> ().instant (transform.position);
	}

	void OnCollisionEnter (Collision other ) {
		if (other.gameObject.CompareTag ("wild_sphere")) {
			OnTriggerDo();
			Destroy (gameObject);
		} 
		if (other.gameObject.CompareTag ("MainCamera")&&
		    (scenes_intermediate.Sound>0)) {
			Handheld.Vibrate();
		}
	}
}
