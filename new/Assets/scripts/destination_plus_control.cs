﻿using UnityEngine;
using System.Collections;

public class destination_plus_control : MonoBehaviour {
	private GameObject player_sp;
	private Rigidbody destination_rb;
	void OnTriggerEnter (Collider other ) {
		if (other.gameObject.CompareTag ("MainCamera")) {
			player_sp.GetComponent<onStart> ().level_up_set_wild_scene (5f, -8f);
			player_sp.GetComponent<add_life_text_control>().run("+5");
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
		destination_rb.AddTorque (0.1f,0.1f,0.1f);
		destination_rb.AddForce (Random.onUnitSphere * 10);
		if (Vector3.Distance (transform.position, player_sp.transform.position) > 100)
			transform.position = player_sp.transform.position + Random.onUnitSphere * 90;
	}
}