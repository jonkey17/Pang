using UnityEngine;
using System.Collections;

public class Ladder2 : MonoBehaviour {

	private bool[] inLadder={false,false};
	private bool[] inTopLadder={false,false};

	public BoxCollider2D topLadderCollider;

	public MoveCharacter player;

	
	void Awake(){
		player=GameObject.Find ("Player").GetComponent<MoveCharacter>();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setInLadder(int LR, bool t){
		inLadder [LR] = t;
		if(isInLadder()){
			player.inLadder=true;
			player.rigidbody2D.gravityScale=0;
			//player.anim.enabled=false;
			topLadderCollider.enabled=false;
		}else{
			//Debug.Log("NO in Ladder");
			player.inLadder=false;
			player.rigidbody2D.gravityScale=1;
			player.anim.enabled=true;
			topLadderCollider.enabled=true;
		}
		//player.inLadder=isInLadder();

	}

	public bool isInLadder(){
		//Debug.Log ("sad "+ inLadder [0]+" "+inLadder [1]);
		if (inLadder [0]==true && inLadder [1]==true) {
			return true;
		}else{
			return false;
		}
	}

	public void setInTopLadder(int LR, bool t){
		inTopLadder [LR] = t;
		player.inTopLadder = isInTopLadder ();

	}

	public bool isInTopLadder(){
		//Debug.Log ("sad "+ inLadder [0]+" "+inLadder [1]);
		if (inTopLadder [0]==true && inTopLadder [1]==true) {
			return true;
		}else{
			return false;
		}
	}




	/*void OnCollisionEnter2D(Collision2D col){
		Debug.Log ("TOP");
	}*/

}
