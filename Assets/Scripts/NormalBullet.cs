using UnityEngine;
using System.Collections;

public class NormalBullet : MonoBehaviour {

		// Use this for initialization
	private Shoot shoot;

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
			//Destroy de bullet
			DestroyAndAllowCanShoot();
		}else if(col.tag == "DestroyableWall"){
			col.gameObject.GetComponent<CubeCollisions>().Hit();
			//Destroy de bullet
			DestroyAndAllowCanShoot();
		}
	}

	void DestroyAndAllowCanShoot(){
		//Destroy de bullet
		if (shoot.numShoots < 2) {
			shoot.numShoots += 1;
		}
		shoot.AllowCanShootBullet1();
		Destroy (gameObject);
	}
}
