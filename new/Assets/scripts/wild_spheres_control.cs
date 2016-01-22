using UnityEngine;
using System.Collections;

public class wild_spheres_control : MonoBehaviour {
	private Rigidbody rb;
	public Transform player_sp;


	void OnTriggerEnter (Collider other ) {
		if(other.gameObject.CompareTag ("wild_sphere"))
			Destroy(gameObject);
	}

	void Start () {
		rb = GetComponent<Rigidbody>();
		player_sp=GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	

	void Update () {
	
	}
	void FixedUpdate()
	{
		rb.AddForce (Random.onUnitSphere*100); 
		rb.AddTorque (1,10,1);
		if (Vector3.Distance (transform.position, player_sp.transform.position) > 500)
			transform.position = player_sp.transform.position + Random.onUnitSphere * 250;

	}

}
