using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class onStart : MonoBehaviour {
	public Text score_text; 
	public Text life_text; 
	float score=0f;
	float scorebest=0f;
	float time=0f;
	public Transform wild_sphere;
	public Transform destination;
	public Transform destination_plus;
	public Transform destination_minus;
	public Transform[] dest_1;

	AudioSource audio;
	public AudioClip pick_up_sound;
	public AudioClip time_sound;

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
		scenes_intermediate.setMilk (0);
		if(Mathf.RoundToInt(score)%4==0)
			ShowAd ();
		Application.LoadLevel (2);
	}

	void decrease_time()
	{
		time -= Time.deltaTime;
		score += Time.deltaTime;
		GetComponent<add_life_text_control> ().Set_Text(time,score);

		if(time < 10 && scenes_intermediate.getSound() >0)
			audio.PlayOneShot (time_sound,1f);

		if (time <= 0)
			die_menu ();
	}

	public  void instant(Vector3 pos)
	{
		int rand =  Mathf.RoundToInt(((score+scorebest+time)/10) % 3);
		Instantiate (dest_1[rand], pos+Random.insideUnitSphere*50, Random.rotation);
	}

	//add wild_spheres on scene when levelUP
	public void level_up(float time_plus,float speed_plus,float k)
	{
		for (float i = 1; i <= k; i += 1) {
			Instantiate (wild_sphere, Random.insideUnitSphere * 400 + transform.position, Random.rotation);
			Instantiate (destination, Random.insideUnitSphere * 400 + transform.position, Random.rotation);
			Instantiate (destination_plus, Random.insideUnitSphere * 400 + transform.position, Random.rotation);
			Instantiate (destination_minus, Random.insideUnitSphere *400 + transform.position, Random.rotation);
		}
		if (scenes_intermediate.getSound ()>0) {
			audio.PlayOneShot (pick_up_sound, 1f);
		}
		time_plus -= score / 60;
		time += time_plus;
		this.GetComponent<camera_control> ().IncreaseSpeed (speed_plus); 
		add_life_text_control.run ( "Time  "+ Mathf.RoundToInt( time_plus).ToString());

	}

	void Awake () {	
		save_record.Read ();
		audio = gameObject.GetComponent<AudioSource> ();
		scenes_intermediate.setMilk (1);
		scorebest = scenes_intermediate.getScoreBest ();
		level_up (scorebest/100 + 40,scorebest/100,30);
		decrease_time ();
	}

	void Update () {
		decrease_time ();
	}

}
