using UnityEngine;
using System.Collections;

public class PickUpItemps : MonoBehaviour {

	public int type=0;//0-TNT 1-Time 2-Clock 3-Live 4-star
	public AudioClip pickupClip;
	private ScoreManager scoreManager;

	public float time=6.0f;
	// Use this for initialization
	void Start () {
		scoreManager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time < 0.0) {
			Destroy(gameObject);
		}else if(time <0.5){
			renderer.enabled=true;
		}else if(time <1.0){
			renderer.enabled=false;
		}else if(time <1.5){
			renderer.enabled=true;
		}else if(time <2.0){
			renderer.enabled=false;
		}else if(time <2.5){
			renderer.enabled=true;
		}else if(time <3.0){
			renderer.enabled=false;
		}

	}
	
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			AudioSource.PlayClipAtPoint(pickupClip, transform.position);
			if(type==0){
				HitATag("BigBall");
				HitATag("MediumBall");
				HitATag("SmallBall");
			}else if(type==1){

			}else if(type==2){
				TimeControl timeControl = GameObject.Find ("TimeControl").GetComponent<TimeControl>();
				timeControl.StopMoving();
				/*StopAnEnemyType("BigBall");
				StopAnEnemyType("MediumBall");
				StopAnEnemyType("SmallBall");*/
			}else if(type==3){
				//GameObject.Find ("ScoreManager").GetComponent<ScoreManager>().increaseLives();
				scoreManager.increaseLives();
			}else if(type==4){
				GameObject.Find ("Shield").GetComponent<ShieldManager>().activate();
			}


			scoreManager.AddScore(100);
			Destroy(gameObject);
		}
	}

	void HitATag(string tag){
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag(tag);
		//Debug.Log(gos.Length);
		for(int i= 0; i<gos.Length; i++){
			gos[i].GetComponent<EnemyBall>().Hit();
			scoreManager.AddScore(100);
		}
	}
}
