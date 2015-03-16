using UnityEngine;
using System.Collections;

public class Bullet4_Gun : MonoBehaviour {

	// Use this for initialization
	//private Shoot shoot;
	public AudioClip colosion;
	void Awake(){
		//shoot = GameObject.Find ("Gun").GetComponent<Shoot>();
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
			Animator anim = GetComponent<Animator> ();
			anim.SetBool ("WallHit", true);
			Destroy (gameObject);
		}else if(col.tag == "DestroyableWall"){
			//col.gameObject.GetComponent<CubeCollisions>().Hit();
			//Destroy de bullet
			AudioSource.PlayClipAtPoint(colosion, transform.position);
			DestroyAndAllowCanShoot();
		}
	}
	
	void DestroyAndAllowCanShoot(){
		//Destroy de bullet
		//shoot.AllowCanShoot();
		Destroy (gameObject);
	}
}
