using UnityEngine;
using System.Collections;

public class destination_1_control : destination_control {

	public destination_1_control()
	{
		set_param(new Vector3(7,150,1),//time,speed,iteration
		          new Vector3(1f,700f,0f),//speed,border_distance
		          new Vector3(10f,30f,10f)*5);//add torque
	}
}
