using UnityEngine;
using System.Collections;

public class HighScores : MonoBehaviour {

	private string[] arrayNames;
	private int[] arrayScores;
	public GUIStyle textStyle;

	public GameObject[] scoreTexts;
	//public GameObject g;
	//public Transform nameText;
	//public Vector2 x;
	private GUIText[] guiChilds;


	void Awake(){
		arrayNames= PlayerPrefsX.GetStringArray("ScoreNames",','," ",10);
		arrayScores =PlayerPrefsX.GetIntArray("ScoreScores",0,10);
	}
	// Use this for initialization
	void Start () {
		for (int i=0; i<arrayScores.Length; i++) {
			if(arrayScores[i]>0){
				guiChilds=scoreTexts[i].GetComponentsInChildren<GUIText>();
				guiChilds[1].text=arrayNames[i];
				guiChilds[2].text=arrayScores[i]+"";
			}
		}
	}

	void OnGUI(){

	}
}
