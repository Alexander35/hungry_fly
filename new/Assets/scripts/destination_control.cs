using UnityEngine;
using System.Collections;

public class destination_control : MonoBehaviour {
	private GameObject player_sp;
	private Rigidbody destination_rb;
	void OnTriggerEnter (Collider other ) {
		if (other.gameObject.CompareTag ("MainCamera")) {
			player_sp.GetComponent<onStart> ().level_up_set_wild_scene (1f, 20f);
			player_sp.GetComponent<add_life_text_control> ().run( "+1");
			//Handheld.Vibrate();
		}
		Destroy(gameObject);
	}
	// Use this for initialization
	void Start () {
		player_sp = GameObject.FindGameObjectWithTag ("MainCamera");
		destination_rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		destination_rb.AddTorque (0.1f,0.2f,0.3f);
	}
}
