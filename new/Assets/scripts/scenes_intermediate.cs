using UnityEngine;
using System.Collections;

public class scenes_intermediate : MonoBehaviour
{
	static int milk=0;
	static float score=0f;
	static float scorebest=0f;
	static float control_sensetivity=0.35f;
	static float control_angle_sensetivity=25f;
	static float sound=1;
	static int language=0;


	public static int getMilk()
	{
		return milk;
	}
	
	public static void setMilk(int val)
	{
		milk = val;
	}

	public static void incMilk()
	{
		milk++;
	}
	
	public static void decMilk()
	{
		milk--;
		if (milk < 0)
			milk = 0;
	}

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

	public static float getConSensAngle()
	{
		return control_angle_sensetivity;
	}
	
	public static void setConSensAngle(float val)
	{
		control_angle_sensetivity = val;
	}

	public static float getConSens()
	{
		return control_sensetivity;
	}

	public static void setConSens(float val)
	{
		control_sensetivity = val;
	}

	public static float getSound()
	{
		return sound;
	}
	
	public static void setSound(float val)
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

