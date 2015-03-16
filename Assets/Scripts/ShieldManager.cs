using UnityEngine;
using System.Collections;

public class ShieldManager : MonoBehaviour {

	// Use this for initialization
	public PolygonCollider2D shielCollider;

	public void activate(){
		renderer.enabled = true;
		shielCollider.enabled = true;
	}

	void desactivate(){
		renderer.enabled = false;
		shielCollider.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "BigBall" || col.tag == "MediumBall" || col.tag == "SmallBall" || col.tag == "MiniBall") {
			col.gameObject.GetComponent<EnemyBall>().Hit();
			GameObject.Find("ScoreManager").GetComponent<ScoreManager>().AddScoreEnemy(col.tag);
			desactivate();
		}
	}
}
