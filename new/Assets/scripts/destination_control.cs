using UnityEngine;
using System.Collections;

public class destination_control : MonoBehaviour {
	private GameObject player_sp;
	private Rigidbody destination_rb;
	private float scorebest =0f;
	void OnTriggerEnter (Collider other ) {
		if (other.gameObject.CompareTag ("MainCamera")) {
			player_sp.GetComponent<onStart> ().level_up(2f, 10f,0f);
			//add_life_text_control.run( "+1");
		}
		Destroy(gameObject);
	}
	// Use this for initialization
	void Start () {
		player_sp = GameObject.FindGameObjectWithTag ("MainCamera");
		destination_rb = GetComponent<Rigidbody> ();
		scorebest = scenes_intermediate.getScoreBest ();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{

		destination_rb.AddForce (Random.onUnitSphere*scorebest*0.01f); 
		if (Vector3.Distance (transform.position, player_sp.transform.position) > 700)
			transform.position = (player_sp.transform.position + Random.insideUnitSphere*700);
		destination_rb.AddTorque (0.0f,0.1f,0.01f);
	}
}
