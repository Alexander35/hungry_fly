using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class onStart : audio_control {
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

	public float Score
	{
		set{
			score=value;
		}
		get{
			return score;
		}
	}

	public float Time_
	{
		set{
			time=value;
		}
		get{
			return time;
		}
	}

	public float ScoreBest
	{
		set
		{
			scorebest=value;
		}
		get{
			return scorebest;
		}
	}

	void OnCollisionEnter (Collision other ) {
		if (other.gameObject.CompareTag ("wild_sphere") || other.gameObject.CompareTag("wild_sphere_1")) {
			Vibrate ();
		}
	}

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}

	void die_menu()
	{
		scenes_intermediate.Score=score;
		scenes_intermediate.Milk=0;
		if(Mathf.RoundToInt(score)%4==0)
			ShowAd ();
		Application.LoadLevel (2);
	}

	public void decrease_time()
	{
		time -= Time.deltaTime;
		score += Time.deltaTime;
		GetComponent<add_life_text_control> ().Set_Text(time,score);

		if (time < 10)
			Sound_Play (1);
		if (time <= 0)
			die_menu ();
	}

	public  void instant(Vector3 pos)
	{
		int rand = Random.Range (0,3);//Mathf.RoundToInt((score+scorebest+time) % 3);

		Instantiate (dest_1[rand], pos+Vector3.one*50, Random.rotation);
	}	
}
