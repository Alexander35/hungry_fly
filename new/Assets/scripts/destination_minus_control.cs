using UnityEngine;
using System.Collections;

public class destination_minus_control : MonoBehaviour {
	private GameObject player_sp;
	private Rigidbody destination_rb;
	void OnTriggerEnter (Collider other ) {
		if (other.gameObject.CompareTag ("MainCamera")) {

			scenes_intermediate.incMilk();
			//add_life_text_control.run ("milk on the board +10!");
			player_sp.GetComponent<onStart> ().level_up(3f, 0f,0f);
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
		destination_rb.AddTorque (0.0f,0.1f,0.0f);
		destination_rb.AddForce (Random.onUnitSphere * scenes_intermediate.getScoreBest()*0.3f);
		if (Vector3.Distance (transform.position, player_sp.transform.position) > 700)
			transform.position =   Random.insideUnitSphere * 700+player_sp.transform.position;
	}
}
