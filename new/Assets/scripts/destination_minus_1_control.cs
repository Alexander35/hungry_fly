using UnityEngine;
using System.Collections;

public class destination_minus_1_control : destination_control {

	public destination_minus_1_control()
	{
		set_param(new Vector3(-15,300,5),//time,speed,iteration
		          new Vector3(0.7f,700f,0f),//speed,border_distance
		          new Vector3(20f,10f,10f)*5);//add torque
	}
}
