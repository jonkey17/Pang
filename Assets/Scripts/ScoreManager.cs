using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ScoreManager : MonoBehaviour {


	private int lives=2;
	public GameObject[] liveObjects;
	public GUIText moreLives;

	private int score=0;
	public GUIText scoreGuiText;
	public GUIText HighText;
	//private int highScoreWhenStart;
	private string tempType=" ";
	private int scoreIndex=1;
	private Dictionary<string, int> enemiesScore = new Dictionary<string, int>();
	//public int[][]  enemiesScores={{50,100,200,400},{100,200,400,600},{150,300,600,1200},{200,400,800,1600}};

	public string nextLevelName;


	private string textFieldString= "Player-1";
	private GUIStyle textStyle;
	
	private float texfieldWidth=200;
	
	private int scoreListSize=10;

	public bool gameOver=false;
	public GUIText gamOverTimeText;
	private float gamOverTime=15.0f;
	public AudioClip timeSound;
	private int sonar=9;

	public GUIStyle InsertName;

	//private GeneralProperties generalProperties;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteKey("ScoreNames");
		//PlayerPrefs.DeleteKey("ScoreScores");

		//generalProperties = GameObject.Find ("GeneralProperties").GetComponent<GeneralProperties> ();
		//score = generalProperties.getScore ();
		score = GeneralProperties.score;
		scoreGuiText.text = "Score: "+score;
		//highScoreWhenStart = PlayerPrefsX.GetIntArray ("ScoreScores",0,10) [0];

		HighText.text = "HI: "+GeneralProperties.highScore;
		//lives = generalProperties.getLives();
		lives = GeneralProperties.lives;
		for (int i=0; i<lives; i++) {
			liveObjects [i].renderer.enabled = true;
		}
		enemiesScore.Add ("BigBall", 50);
		enemiesScore.Add ("MediumBall", 100);
		enemiesScore.Add ("SmallBall", 150);
		enemiesScore.Add ("MiniBall", 200);
	}
	
	// Update is called once per frame
	void Update () {
		if(gameOver){
			gamOverTime -=Time.deltaTime;
			gamOverTimeText.text=""+(int)gamOverTime;
			if(gamOverTime<sonar){
				sonar-=1;
				AudioSource.PlayClipAtPoint(timeSound, transform.position);
			}
			if(gamOverTime<=0){
				passToHighScore();
			}

		}
	}

	public void increaseLives(){
		lives+=1;
		//generalProperties.setLives (lives);
		GeneralProperties.lives = lives;
		if (lives < 5) {
			liveObjects[lives-1].renderer.enabled=true;
		}else{
			moreLives.enabled=true;
			moreLives.text=lives+"";
		}
	}

	public int deceaseLives(){
		lives -= 1;
		//generalProperties.setLives (lives);
		GeneralProperties.lives = lives;
		if (lives < 0) {
			//Game Over
			gameOver=true;
			gamOverTimeText.enabled=true;
			textFieldString=PlayerPrefs.GetString("LastPlayer", "Player-1");
//			Debug.Log("muerto score");
		}else if(lives<4){
			liveObjects[lives].renderer.enabled=false;
		}else if(lives==4){
			moreLives.enabled=false;
		}else{
			moreLives.text=lives+"";
		}
		return lives;
	}

	public void AddScoreEnemy(string type){

		if (type.Equals (tempType)) {
			if(scoreIndex<8){
				scoreIndex=scoreIndex*2;
			}
		}else{
			tempType=type;
			scoreIndex=1;
		}

		score += enemiesScore[type]*scoreIndex;
		scoreGuiText.text = "Score: "+score;
		//generalProperties.setScore (score);
		GeneralProperties.score = score;

		if(score>GeneralProperties.highScore){
			HighText.text = "HI: "+score;
			GeneralProperties.highScore=score;
		}

		if(type.Equals("MiniBall")){
			//checkIfEndLevel();
			Invoke("checkIfEndLevel", 1);
		}
	}

	public void AddScore(int value){
		score += value;
		scoreGuiText.text = "Score: "+score;
		//generalProperties.setScore (score);
		GeneralProperties.score = score;

		if(score>GeneralProperties.highScore){
			HighText.text = "HI: "+score;
			GeneralProperties.highScore=score;
		}
	}

	void checkIfEndLevel(){
	
		if (existFromTag ("MiniBall") || existFromTag ("SmallBall") || existFromTag ("MediumBall") || existFromTag ("BigBall")) {
			//continuar

		}else{
			//Pass to next level

			Application.LoadLevel(nextLevelName);
		}

	}

	bool existFromTag(string tag){
		GameObject[] gos= GameObject.FindGameObjectsWithTag(tag);
		if(gos.Length>0){
			return true;
		}else{
			return false;
		}
	}

	void OnGUI(){
		if (gameOver) {
			textStyle = new GUIStyle (GUI.skin.textField);
			textStyle.fontSize = 40;
			textStyle.alignment = TextAnchor.MiddleCenter;
		
			textFieldString = GUI.TextField (new Rect ((Screen.width / 2) , 25, texfieldWidth, 50), textFieldString, 10, textStyle);
		
			GUI.Label (new Rect (((Screen.width / 2)-texfieldWidth), 25, texfieldWidth, 50), "Name: ", InsertName);
	
			const int anchoBoton = 144;
			const int altoBoton = 120;
			//GUI.backgroundColor=Color.clear;
			// Dibujamos un boton  de inicio del juego
			if (
				GUI.Button (new Rect (Screen.width / 2 - (anchoBoton / 2),
			(2 * Screen.height / 3) - (altoBoton / 2),anchoBoton,altoBoton),
			"Continue")) {
			
						//Debug.Log("Presionado");
						//GeneralProperties.score=5;
					passToHighScore();
						
				}
		}
	}

	void passToHighScore(){
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
			PlayerPrefs.SetString("LastPlayer",textFieldString);
		}
		
		Application.LoadLevel ("HighScores");
	}
}
