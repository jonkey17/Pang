using UnityEngine;
using System.Collections;

public class TopLadderCollider : MonoBehaviour {

	public int LR=0;//Left or Rigt point
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player") {
			transform.parent.GetComponent<Ladder2>().setInTopLadder(LR,true);
		}
		
	}
	
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Player") {
			transform.parent.GetComponent<Ladder2>().setInTopLadder(LR,false);
		}
		
	}
}
