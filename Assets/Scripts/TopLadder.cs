using UnityEngine;
using System.Collections;

public class TopLadder : MonoBehaviour {

	private Ladder ld;

	private MoveCharacter player;

	public BoxCollider2D highLadderPoint;

	void Awake(){
		player=GameObject.Find ("Player").GetComponent<MoveCharacter>();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag=="Player"){
			Debug.Log ("sdasdasdasdasasd");
			highLadderPoint.enabled=true;
			//ld=transform.parent.gameObject.GetComponent<Ladder>();
			//ld.player.inflor=false;
		}
	}
}
