using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {

	public MoveCharacter player;

	void Awake(){
		player=GameObject.Find ("Player").GetComponent<MoveCharacter>();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			player.inLadder=true;
			//player.anim.enabled=false;
			player.rigidbody2D.gravityScale=0;
			//player.anim.SetBool("inLadder", true);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			player.inLadder=false;
			player.climbing=false;
			player.anim.enabled=true;
			player.rigidbody2D.gravityScale=30;
			//player.anim.SetBool("inLadder", false);

		}
	}
}
