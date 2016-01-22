using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class onStart : MonoBehaviour {
	public int level=1;
	public Text score_text; 
	public Text level_text;
	public Text life_text; 
	float score=0f;
	public float time=60f;
	public Transform wild_sphere;
	public Transform destination;
	public Transform destination_plus;
	public Transform destination_minus;

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}

	void die_menu()
	{
		scenes_intermediate.setScore (score);
		if(Mathf.RoundToInt(score)%4==0)
			ShowAd ();
		Application.LoadLevel (2);

	}

	void decrease_time()
	{
		time -= 1*Time.deltaTime;
		score += 1 * Time.deltaTime;
		GetComponent<add_life_text_control> ().Set_Text(time,score);

		if (time <= 0)
			die_menu ();
	}

	void set_wild_scene()
	{
		Vector3 destination_pos;
		for (int i=0; i<10; i++) {
			Instantiate (wild_sphere, Random.onUnitSphere * 150f, Random.rotation);
		
			destination_pos = Random.onUnitSphere *20;
			Instantiate (destination, destination_pos, Random.rotation);
			destination_pos = Random.onUnitSphere *20;
			Instantiate (destination_plus, destination_pos, Random.rotation);
		}
	}
	//add wild_spheres on scene when levelUP
	public void level_up_set_wild_scene(float time_plus,float speed_plus)
	{
		Vector3 destination_pos;
		level ++;

		for (int i=0; i<5; i++) {
			Instantiate (wild_sphere, (Random.onUnitSphere + transform.position) * 100f, Random.rotation);
			destination_pos = Random.onUnitSphere * 50 * level;
			Instantiate (destination, (destination_pos + transform.position), Random.rotation);
			destination_pos = Random.onUnitSphere * 50 * level;
			Instantiate (destination_plus, (destination_pos + transform.position), Random.rotation);
			destination_pos = Random.onUnitSphere * 50 * level;
			Instantiate (destination_minus, (destination_pos + transform.position), Random.rotation);
		}
		time += time_plus;
		this.GetComponent<camera_control> ().IncreaseSpeed (speed_plus);
	}

	void Awake () {	
		decrease_time ();
		set_wild_scene ();
	}

	void Update () {
		decrease_time ();
	}

}
