using UnityEngine;
using System.Collections;

public class destination_plus_control : destination_control {

	public destination_plus_control()
	{
		set_param(new Vector3(5,150,1),//time,speed,iteration
		          new Vector3(0.5f,700f,0f),//speed,border_distance
		          new Vector3(10f,10f,10f)*5);//add torque
	}
}
