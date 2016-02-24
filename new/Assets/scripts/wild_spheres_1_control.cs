using UnityEngine;
using System.Collections;

public class wild_spheres_1_control : destination_control {

	public wild_spheres_1_control()
	{
		set_param(new Vector3(0,0,0),//time,speed,iteration
		          new Vector3(800f,700f,0f),//speed,border_distance
		          new Vector3(15,15,15)*115);//add torque
	}

	void OnCollisionEnter (Collision other ) {
		if (other.gameObject.CompareTag ("wild_sphere")||other.gameObject.CompareTag ("wild_sphere_1")) {
			Destroy (gameObject);
		}
	}	
}
