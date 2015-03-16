using UnityEngine;
using System.Collections;

public class TouchButonHighScore : TouchLogicV2 {

	public int option=0;
	public GameObject scores;
	public override void OnTouchBegan()
	{
		switch(option){
			case 0: 
					scores.GetComponent<Menu1>().delete=false;
					break;
			//delete
			case 1: 
					PlayerPrefsX.SetStringArray("ScoreNames",',', new string[10]);
					PlayerPrefsX.SetIntArray("ScoreScores",new int[10]);
					break;
		}

	}
}
