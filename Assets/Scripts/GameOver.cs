using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class GameOver : MonoBehaviour {

	private string textFieldString= "Player-1";
	private GUIStyle textStyle;

	private float texfieldWidth=200;

	private int scoreListSize=10;

	public GUIStyle InsertName;


	// Use this for initialization
	void Start () {
		//PlayerPrefsX.SetStringArray("ScoreNames",',', new string[]{"Koko","Wev","Koko"});
		//PlayerPrefsX.SetIntArray("ScoreScores",new int[]{100,75,10});
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		textStyle = new GUIStyle (GUI.skin.textField);
		textStyle.fontSize = 40;
		textStyle.alignment = TextAnchor.MiddleCenter;
		
		textFieldString = GUI.TextField (new Rect ((Screen.width / 2) , Screen.height/2, texfieldWidth, 50), textFieldString, 10, textStyle);
		
		GUI.Label (new Rect (((Screen.width / 2.2f)-texfieldWidth), Screen.height/2, texfieldWidth, 50), "Insert Name: ", InsertName);
		
		const int anchoBoton = 144;
		const int altoBoton = 120;
		//GUI.backgroundColor=Color.clear;
		// Dibujamos un boton  de inicio del juego
		if (
			GUI.Button (new Rect (Screen.width / 2 - (anchoBoton / 2),
		                      (2*Screen.height / 2.6f) - (altoBoton / 2),anchoBoton,altoBoton),
		            "Continue")) {
			
			//Debug.Log("Presionado");
			//GeneralProperties.score=5;
			
			bool scorePositionFind = false;			
			string[] arrayNames = PlayerPrefsX.GetStringArray ("ScoreNames", ',', " ", 10);
			int[] arrayScores = PlayerPrefsX.GetIntArray ("ScoreScores", 0, 10);
			int index = scoreListSize;
			
			if (arrayScores.Length < scoreListSize) {//Only when the game execute de first time and there arent scores
				arrayNames = new string[10];
				arrayScores = new int[10];
				PlayerPrefsX.SetStringArray ("ScoreNames", ',', arrayNames);
				PlayerPrefsX.SetIntArray ("ScoreScores", arrayScores);
			}
			
			//Find the position of score in hig score list
			for (int i =0; i<scoreListSize&&!scorePositionFind; i++) {
				if (GeneralProperties.score > arrayScores [i]) {
					scorePositionFind = true;
					index = i;
				}
			}
			if (index < 10) {
				//Debug.Log("Actualizamos la lista de scores");
				//create new arrays with new values
				int[] arrayScores2 = new int[scoreListSize];
				arrayScores.CopyTo (arrayScores2, 0);			
				//move all to right from a position
				for (int i=arrayScores2.Length-2; i>=index; i--) {
					arrayScores2 [i + 1] = arrayScores2 [i];
				}
				//insert the score in the correct position
				arrayScores2 [index] = GeneralProperties.score;
				string[] arrayNames2 = new string[scoreListSize];
				arrayNames.CopyTo (arrayNames2, 0);			
				//move all to right from a position
				for (int i=arrayNames2.Length-2; i>=index; i--) {
					arrayNames2 [i + 1] = arrayNames2 [i];
				}			
				arrayNames2 [index] = textFieldString;
				
				PlayerPrefsX.SetStringArray ("ScoreNames", ',', arrayNames2);
				PlayerPrefsX.SetIntArray ("ScoreScores", arrayScores2);
			}
			
			Application.LoadLevel ("HighScores");
		}
	}


}
