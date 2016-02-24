using UnityEngine;
using System.Collections;

public class destination_control : MonoBehaviour {
	protected GameObject player_sp;
	private Rigidbody destination_rb;
	private float scorebest =0f;
	private Vector3 change;//time,speed,iteration
	private Vector3 self;//speed,border_distance
	private Vector3 torque=Vector3.zero;//add torque

	public Vector3 Change
	{
		set
		{
			change=value;
		}
		get
		{
			return change;
		}
	}

	public Vector3 Self
	{
		set
		{
			self=value;
		}
		get
		{
			return self;
		}
	}

	public Vector3 Tor
	{
		set
		{
			torque=value;
		}
		get
		{
			return torque;
		}
	}

	public destination_control(Vector3 tsi,Vector3 sb,Vector3 tor)
	{
		set_param (tsi,//time,speed,iteration
		          sb,//speed,border_distance
		          tor);//add torque
	}

	public destination_control()
	{
		set_param(new Vector3(2,100,0),//time,speed,iteration
		          new Vector3(0.3f,700f,0f),//speed,border_distance
		          new Vector3(0.0f,10f,1f)*5);//add torque
	}

	public void set_param (Vector3 ch,Vector3 se,Vector3 tor)
	{
		Change = ch;
		Self = se;
		torque = tor;
	}

	public virtual void OnTriggerDo()
	{
		player_sp.GetComponent<camera_control> ().level_up(change.x,change.y,change.z);
	}

	public virtual void OnTriggerEnter (Collider other ) {
		if (other.gameObject.CompareTag ("MainCamera")) {
			OnTriggerDo();
		}
		Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
		player_sp = GameObject.FindGameObjectWithTag ("MainCamera");
		destination_rb = GetComponent<Rigidbody> ();
		scorebest = scenes_intermediate.ScoreBest;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		destination_rb.AddForce (Random.onUnitSphere*scorebest*self.x*Time.deltaTime); 
		if (Vector3.Distance (transform.position, player_sp.transform.position) > self.y)
			transform.position = (player_sp.transform.position + Random.insideUnitSphere*self.y);
		destination_rb.AddTorque (torque*Time.deltaTime);
	}
}
