using UnityEngine;
using System.Collections;

public class scenes_intermediate : MonoBehaviour
{
	static float score=0f;
	static float scorebest=0f;
	static float control_sensetivity=0.35f;
	static bool sound=true;
	static int language=0;

	public static float getScoreBest()
	{
		return scorebest;
	}
	
	public static void setScoreBest(float val)
	{
		scorebest = val;
	}

	public static float getScore()
	{
		return score;
	}

	public static void setScore(float val)
	{
			score = val;

	}

	public static float getConSens()
	{
		return control_sensetivity;
	}

	public static void setConSens(float val)
	{
		control_sensetivity = val;
	}

	public static bool getSound()
	{
		return sound;
	}
	
	public static void setSound(bool val)
	{
		sound = val;
	}

	public static int getLang()
	{
		return language;
	}
	
	public static void setLang(int val)
	{
		language = val;
	}

}

