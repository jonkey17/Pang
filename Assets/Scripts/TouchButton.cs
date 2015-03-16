using UnityEngine;
using System.Collections;

public class TouchButton : TouchLogicV2 {
	public GameObject gun;
	private Shoot s;//=GameObject.Find ("Gun").GetComponent<Shoot>();
	void Awake(){
		s=gun.GetComponent<Shoot> ();
	}
	public override void OnTouchBegan()
	{
		//print ("TOUCH BEGAN!");
		s.Shooting ();
	}



}
