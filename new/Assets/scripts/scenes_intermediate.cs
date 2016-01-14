using UnityEngine;
using System.Collections;

public class scenes_intermediate : MonoBehaviour
{
	static float score=0f;

	public static float getScore()
	{
		return score;
	}

	public static void setScore(float Sc)
	{
		score = Sc;
	}
}

