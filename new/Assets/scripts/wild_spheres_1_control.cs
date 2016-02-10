using UnityEngine;
using System.Collections;

public class wild_spheres_1_control : MonoBehaviour {
	private Rigidbody rb;
	public Transform player_sp;



	void OnCollisionEnter (Collision other ) {
		if (other.gameObject.CompareTag ("wild_sphere")||other.gameObject.CompareTag ("wild_sphere_1")) {
			//player_sp.GetComponent<onStart> ().instant (transform.position);
			//Debug.Log("OnTriggerEnter");
			Destroy (gameObject);
		}
	}

	void Start () {
		rb = GetComponent<Rigidbody>();
		player_sp=GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	

	void Update () {
	
	}
	void FixedUpdate()
	{
		rb.AddForce (Random.onUnitSphere*scenes_intermediate.getScoreBest()*0.7f); 
		rb.AddTorque (15,150,15);
		if (Vector3.Distance (transform.position, player_sp.transform.position) > 700)
			transform.position = Random.insideUnitSphere*700+player_sp.transform.position;

	}

}
