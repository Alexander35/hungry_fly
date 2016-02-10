using UnityEngine;
using System.Collections;

public class wild_spheres_control : MonoBehaviour {
	private Rigidbody rb;
	public Transform player_sp;


	void OnCollisionEnter (Collision other ) {
		if (other.gameObject.CompareTag ("wild_sphere")) {
			player_sp.GetComponent<onStart> ().instant (transform.position);
			//Debug.Log("C");
			Destroy (gameObject);

		} 
	}

	/*void OnTriggerEnter (Collider other ) {
		if (other.gameObject.CompareTag ("wild_sphere")) {
			player_sp.GetComponent<onStart> ().instant (transform.position);	
			Destroy (gameObject);
		} 
	}*/

	void Start () {
		rb = GetComponent<Rigidbody>();
		player_sp=GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	

	void Update () {
	
	}
	void FixedUpdate()
	{
		rb.AddForce (Random.onUnitSphere*scenes_intermediate.getScoreBest()*0.5f); 
		rb.AddTorque (30,200,30);
		if (Vector3.Distance (transform.position, player_sp.transform.position) > 700)
			transform.position = (player_sp.transform.position + Random.insideUnitSphere*700);

	}

}
