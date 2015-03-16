using UnityEngine;
using System.Collections;

public class Bullet2 : MonoBehaviour {

		// Use this for initialization
	private Shoot shoot;

	public Rigidbody2D bullet3;
	void Awake(){
		shoot = GameObject.Find ("Gun").GetComponent<Shoot>();
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		//hit enemy
		if (col.tag == "BigBall" || col.tag == "MediumBall" ||col.tag == "SmallBall"||col.tag == "MiniBall") {
			col.gameObject.GetComponent<EnemyBall>().Hit();
			GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddScoreEnemy(col.tag);
			DestroyAndAllowCanShoot();
		}else if(col.tag == "Wall"){
			Rigidbody2D intanceBullet3=Instantiate (bullet3, transform.position - new Vector3(0,0,0), Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
			Destroy (gameObject);
		}else if(col.tag == "DestroyableWall"){
			col.gameObject.GetComponent<CubeCollisions>().Hit();
			//Destroy de bullet
			DestroyAndAllowCanShoot();
		}
	}

	void DestroyAndAllowCanShoot(){
		//Destroy de bullet
		shoot.AllowCanShootBullet2();
		Destroy (gameObject);
	}
}
