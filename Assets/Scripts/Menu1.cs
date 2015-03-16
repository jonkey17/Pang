using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Menu1 : MonoBehaviour {

	public int option;
	public AudioClip press;

	public bool delete=false;
	private int deleteBigBoxWith=280;
	private int deleteBigBoxHeight=200;
	public GUIStyle deleteStyle;
	public GUIStyle deleteButtonsStyle;
	public GUITexture noButton;
	public GUITexture yesButton;


	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
	}

	void OnMouseEnter(){
		guiText.color=Color.blue;
		AudioSource.PlayClipAtPoint(press, transform.position);
		//renderer.material.color = Color.blue;
	}

	void OnMouseExit(){
		guiText.color=Color.white;
		//renderer.material.color = Color.blue;
	}

	void OnMouseUpAsButton(){
		switch(option){
			//Exit
			case 0: Application.Quit(); break;
			//Start
			case 1: GeneralProperties.Reset();
					Application.LoadLevel("1"); break;
			//Score
			case 2: Application.LoadLevel("HighScores"); break;
			case 3: Application.LoadLevel("menu");break;
			case 4: delete=true;break;
		}
	}

	void OnGUI(){
		if(delete){
			//deleteStyle = new GUIStyle (GUI.skin.box);
			//deleteStyle.normal.background=MakeTex( 4, 4, new Color( 1f, 1f, 1f, 1f ) );;
			//deleteStyle.font=f;
			
			GUI.Box (new Rect ((Screen.width / 2)-deleteBigBoxWith/2,Screen.height/2-deleteBigBoxHeight/2,deleteBigBoxWith,deleteBigBoxHeight), "You sure?", deleteStyle);

			if (GUI.Button (new Rect (((Screen.width / 2)-(deleteBigBoxWith/2))+20,(Screen.height/2-deleteBigBoxHeight/2)+100,115,60), "Yes",deleteButtonsStyle)) {
				PlayerPrefsX.SetStringArray("ScoreNames",',', new string[10]);
				PlayerPrefsX.SetIntArray("ScoreScores",new int[10]);
				//PlayerPrefs.DeleteAll();
				Application.LoadLevel(Application.loadedLevel);
				//PlayerPrefs.DeleteKey("ScoreNames");
				//PlayerPrefs.DeleteKey("ScoreScores");
			}
			if (GUI.Button  (new Rect (((Screen.width / 2)-(deleteBigBoxWith/2))+145,(Screen.height/2-deleteBigBoxHeight/2)+100,115,60), "No",deleteButtonsStyle)) {
				delete=false;
			}
			//MessageBox.Show(Callback, "Hello World!", "Hello", buttons, icon, defaultButton);
		}
	}

	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}
	
}
