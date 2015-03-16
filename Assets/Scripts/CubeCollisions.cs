using UnityEngine;
using System.Collections;

public class CubeCollisions : MonoBehaviour {
	public Rigidbody2D animatedObject;
	public AudioClip breakClip;

	public int scorepointOnHit=500;
	private ScoreManager scoreManager;
	// Use this for initialization
	void Start () {
		scoreManager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
	}

	public void Hit(){
		AudioSource.PlayClipAtPoint(breakClip, transform.position, 1);
		Rigidbody2D intanceBullet3=Instantiate (animatedObject, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
		scoreManager.AddScore(scorepointOnHit);
		Destroy (gameObject);
	}
}
