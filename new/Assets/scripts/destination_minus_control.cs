using UnityEngine;
using System.Collections;

public class destination_minus_control : destination_control {

	public destination_minus_control()
	{
		set_param(new Vector3(3,0f,0),//time,speed,iteration
		          new Vector3(0.5f,700f,0f),//speed,border_distance
		          new Vector3(0.0f,10f,0.0f)*5);//add torque
	}
	public override void OnTriggerDo()
	{
		scenes_intermediate.incMilk();
		base.OnTriggerDo ();
	}	
}
