using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

	public int speed=5;
	public BoxCollider2D idleCollider;
	public PolygonCollider2D walkingCollider;
	public Joystick joystick; 

	[HideInInspector]
	public bool movingRight = true;			// For determining which way the player is currently moving.
	public bool keyboard= true;
	[HideInInspector]
	public Animator anim;
	private float inputX=0, inputY=0;

	[HideInInspector]
	public bool inLadder=false;
	[HideInInspector]
	public bool climbing = false;
	//[HideInInspector]
	//public bool inflor=true;
	[HideInInspector]
	public bool inTopLadder=false;

	public Sprite[] climbSprites;
	private SpriteRenderer spriteRenderer;
	private int index=0;

	public Sprite dead;

	private float time;

	private ScoreManager scoreManager;

	public bool canMove=true;

	public AudioClip playerHit;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		spriteRenderer = renderer as SpriteRenderer;
		spriteRenderer.sprite=climbSprites[ index ];
		scoreManager=GameObject.Find ("ScoreManager").GetComponent<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (inLadder) {
			//Debug.Log("ladeeeeeeerrr");
			if(!climbing && inputY>0){
				//Debug.Log("1");
				climbing=true;
				anim.enabled=false;
				//rigidbody2D.gravityScale=0;
			}else if(climbing){
				//Debug.Log("2");
				if(inputY>0){
					index=(int)(Time.timeSinceLevelLoad * 10);//index+1;
				}else if(inputY<0){
					index=(int)(Time.timeSinceLevelLoad * 10);//index-1;
				}
				index = index % climbSprites.Length;
				//Debug.Log(index);
				spriteRenderer.sprite=climbSprites[ index ];
			}
		}else if(inTopLadder){
			//Debug.Log("Toppppppppppppppp");
			if (keyboard) {
				inputY = Input.GetAxis ("Vertical");
			}else{
				inputY = joystick.position.y;
			}
			//Debug.Log("3");
			if(inputY<0){
				Debug.Log("4");
				GameObject[] gos= GameObject.FindGameObjectsWithTag("Ladder");
				for(int i= 0; i<gos.Length; i++){
					gos[i].GetComponent<Ladder2>().topLadderCollider.enabled=false;
				}
				climbing=true;
				anim.enabled=false;
			}
		}
	}
	
	void FixedUpdate()
	{
		if(canMove){
			// Recibimos la informacion del eje X, Y segun presionamos el teclado
			if (keyboard) {
				inputX = Input.GetAxis ("Horizontal");
				if(inLadder){
					inputY = Input.GetAxis ("Vertical");
					if(climbing){
						inputX=0;
					}
				}else{
					inputY=0;
				}
			} else {
				inputX = joystick.position.x;
				if(inLadder){
					inputY = joystick.position.y;
					if(climbing){
						inputX=0;
					}
				}else{
					inputY=0;
				}
			}


			if (inputX == 0) {
				anim.SetBool ("walking", false);
				walkingCollider.enabled=false;
				idleCollider.enabled=true;
			} else {
				anim.SetBool ("walking", true);
				idleCollider.enabled=false;
				walkingCollider.enabled=true;

			}

			if (inputX > 0 && !movingRight) {
				Flip();
			} else if (inputX < 0 && movingRight) {
				Flip();
			}
			// Movemos segun la direccion
			rigidbody2D.velocity = new Vector2(speed * inputX,speed * inputY);
		}
		/*if (Input.GetKeyDown (KeyCode.Escape)) {
			//MENU PAUSA
		}*/
	}


	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		movingRight = !movingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "BigBall"||col.gameObject.tag == "MediumBall"||col.gameObject.tag == "SmallBall"||col.gameObject.tag == "MiniBall") {
			idleCollider.enabled=false;
			walkingCollider.enabled=false;
			canMove=false;
			anim.enabled=false;
			spriteRenderer.sprite=dead;
			StartCoroutine(PlayerHit());

		}
		if(col.gameObject.tag=="BaseWall"){
			//Debug.Log("suelo tocado");
			climbing=false;
			anim.enabled=true;
			//inflor=true;
			rigidbody2D.gravityScale=1;
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "FlyMode") {
			rigidbody2D.gravityScale=30;
		}
		/*if(col.tag=="TopLadder"){
			inflor=false;
			BoxCollider2D b= col.gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
			b.enabled=true;
			Debug.Log ("sdasdasdasdasasd");


		}*/
		/*else if(col.tag=="DownLadder"){
			inLadder=col.gameObject.transform.parent.GetComponent<Ladder2>().isInLadder();
			Debug.Log(inLadder);
		}*/
	}

	/*void OnTriggerExit2D(Collider2D col){
		if(col.tag=="DownLadder"){
			inLadder=col.gameObject.transform.parent.GetComponent<Ladder2>().isInLadder();
			//Debug.Log(inLadder);
		}	
	}*/

	IEnumerator PlayerHit(){
		AudioSource.PlayClipAtPoint(playerHit, transform.position);
		yield return new WaitForSeconds(playerHit.length);
		if(scoreManager.deceaseLives()>=0){
			Application.LoadLevel(Application.loadedLevel);
		}else{
			//GAME OVER
			//Debug.Log("muerto");
			//Application.LoadLevel("gameover");
		}
	}
}
