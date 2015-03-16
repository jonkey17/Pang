using UnityEngine;
using System.Collections;


public class MoveCharacterMobile : MonoBehaviour {


	public Joystick joystick; 

	public int speed=5;
	public BoxCollider2D idleCollider;
	public PolygonCollider2D walkingCollider;
	
	[HideInInspector]
	public bool movingRight = true;			// For determining which way the player is currently moving.

	//private float h = 0, v = 0;         // Horizontal and Vertical values
	
	
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate()
	{
		// Recibimos la informacion del eje X, Y segun presionamos el teclado
		float inputX = joystick.position.x;
		float inputY = joystick.position.y;

		//h = joystick.position.x;
		//v = joystick.position.y;
		//te.text = inputX+"";
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
		/*
		// Apply horizontal velocity
		if (Mathf.Abs(h) > 0) {
			rigidbody2D.velocity = new Vector2(h * speed, rigidbody2D.velocity.y);
		}
		
		// Apply vertical velocity
		if (Mathf.Abs(v) > 0) {
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, v * speed);
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

}
