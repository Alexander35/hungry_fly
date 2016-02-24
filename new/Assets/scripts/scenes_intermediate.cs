using UnityEngine;
using System.Collections;

public class scenes_intermediate : MonoBehaviour
{
	static int milk=0;
	static float score=0f;
	static float scorebest=0f;
	static float control_sensetivity=0.35f;
	static float sound=1;
	static int language=0;


	public static int Milk
	{
		get
		{
			return milk;
		}
		set
		{
			milk=value;
		}
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

	public static float ScoreBest
	{
		get{
			return scorebest;
		}
		set{
			scorebest=value;
		}
	}

	public static float Score
	{
		get{
			return score;
		}
		set{
			score=value;
		}
	}

	public static float ConSens
	{
		get{
			return control_sensetivity;
		}
		set{
			control_sensetivity=value;
		}
	}
	
	public static float Sound
	{
		get{
			return sound;
		}
		set{
			sound=value;
		}
	}

	public static int Lang
	{
		get{
			return language;
		}
		set{
			language=value;
		}
	}
}

