using UnityEngine;
using System.Collections;

public class PickUpTool : MonoBehaviour {

	public int type=0;
	public AudioClip pickupClip;
	private ScoreManager scoreManager;
	public float time=6.0f;
	// Use this for initialization
	void Start () {
		scoreManager = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time < 0.0) {
			Destroy(gameObject);
		}else if(time <0.5){
			renderer.enabled=true;
		}else if(time <1.0){
			renderer.enabled=false;
		}else if(time <1.5){
			renderer.enabled=true;
		}else if(time <2.0){
			renderer.enabled=false;
		}else if(time <2.5){
			renderer.enabled=true;
		}else if(time <3.0){
			renderer.enabled=false;
		}
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			AudioSource.PlayClipAtPoint(pickupClip, transform.position);
			Shoot shoot=GameObject.Find ("Gun").GetComponent<Shoot>();
			shoot.setBulletType(type);
			shoot.numShoots=2;
			GameObject.Find ("GunType").GetComponent<GunType>().changeTool(type);
			GameObject.Find ("ScoreManager").GetComponent<ScoreManager>().AddScore(100);
			scoreManager.AddScore(100);
			Destroy(gameObject);
		}
	}
}
