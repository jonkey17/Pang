using UnityEngine;
using System.Collections;

public class ItemsMovement : MonoBehaviour {

	public int speed;

	public Vector2 direction= new Vector2(0,1);

	void FixedUpdate(){
		rigidbody2D.velocity = new Vector2(speed * direction.x,speed * direction.y);
	}
}
