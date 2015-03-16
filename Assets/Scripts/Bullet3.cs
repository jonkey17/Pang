using UnityEngine;
using System.Collections;

public class Bullet3 : MonoBehaviour {

		// Use this for initialization
	private Shoot shoot;
	private SpriteRenderer spriteRenderer;
	private float time=5;
	void Awake(){
		shoot = GameObject.Find ("Gun").GetComponent<Shoot>();
		spriteRenderer = renderer as SpriteRenderer;
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		time-=Time.deltaTime;
		if(time<=0){
			DestroyAndAllowCanShoot();
		}else if (time <= 1) {
			spriteRenderer.color = Color.red; 
		}else if(time <=2){
			spriteRenderer.color = Color.yellow; 
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		//hit enemy
		if (col.tag == "BigBall" || col.tag == "MediumBall" ||col.tag == "SmallBall"||col.tag == "MiniBall") {
			col.gameObject.GetComponent<EnemyBall>().Hit();
			GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddScoreEnemy(col.tag);
			DestroyAndAllowCanShoot();
		}
	}

	void DestroyAndAllowCanShoot(){
		//Destroy de bullet
		shoot.AllowCanShootBullet2();
		Destroy (gameObject);
	}
}
