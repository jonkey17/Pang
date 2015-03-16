using UnityEngine;
using System.Collections;

public static class GeneralProperties{

	public static int lives=2;
	public static  int score=0;
	public static int highScore = PlayerPrefsX.GetIntArray ("ScoreScores",0,10) [0];

	public static float w = Screen.width / 1136f;
	public static float h = Screen.height / 640f;

	public static void Reset(){
		lives=2;
		score=0;
		highScore = PlayerPrefsX.GetIntArray ("ScoreScores",0,10) [0];
	}
}
