using UnityEngine;
using System.Collections;

public class destination_minus_1_control : MonoBehaviour {
	private GameObject player_sp;
	private Rigidbody destination_rb;
	void OnTriggerEnter (Collider other ) {
		if (other.gameObject.CompareTag ("MainCamera")) {
			player_sp.GetComponent<onStart> ().level_up (-15f, 30f, 5f);
			//add_life_text_control.run("-8");
			Destroy(gameObject);

		}

	}
	// Use this for initialization
	void Start () {
		player_sp = GameObject.FindGameObjectWithTag ("MainCamera");
		destination_rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		destination_rb.AddTorque (0.2f,0.1f,0.1f);
		destination_rb.AddForce (Random.onUnitSphere * scenes_intermediate.getScoreBest()*0.4f);
		if (Vector3.Distance (transform.position, player_sp.transform.position) > 700)
			transform.position = Random.insideUnitSphere * 700+player_sp.transform.position;
	}
}
