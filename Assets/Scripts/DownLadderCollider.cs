using UnityEngine;
using System.Collections;

public class DownLadderCollider : MonoBehaviour {

	public int LR=0;//Left or Rigt point
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			transform.parent.GetComponent<Ladder2>().setInLadder(LR,true);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			transform.parent.GetComponent<Ladder2>().setInLadder(LR,false);
		}
		
	}
}
