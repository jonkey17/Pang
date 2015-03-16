using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	//public Rigidbody2D[] bullet;

	public Transform[] bullet;
	public bool canShootBullet1= true;
	public bool canShootBullet2= true;
	public int bulletType=0;
	public AudioClip[] shootClip;

	//public Joystick joystick;
	public bool keyboard= true;

	public int numShoots=1;

	public bool canShoot=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(canShoot){
			if(Input.GetButtonDown("Jump")){//||joystick.position.x>0){//space
				Shooting();
			}
		}
	}

	public void Shooting(){
		if(bulletType==2){
			AudioSource.PlayClipAtPoint(shootClip[1], transform.position);
			Rigidbody2D bulletInstance= Instantiate(bullet[bulletType], transform.position + new Vector3(0,7.2f,0), Quaternion.Euler(new Vector3(0,0,0)))as Rigidbody2D;
		}else if(bulletType==1){
			if(canShootBullet2){
				AudioSource.PlayClipAtPoint(shootClip[0], transform.position);
				Rigidbody2D bulletInstance= Instantiate(bullet[bulletType], transform.position, Quaternion.Euler(new Vector3(0,0,0)))as Rigidbody2D;
				canShootBullet2=false;
			}
		}else{
			if(canShootBullet1){
				AudioSource.PlayClipAtPoint(shootClip[0], transform.position);
				Rigidbody2D bulletInstance= Instantiate(bullet[bulletType], transform.position, Quaternion.Euler(new Vector3(0,0,0)))as Rigidbody2D;
				numShoots-=1;
				if(numShoots==0){
					canShootBullet1=false;
				}
			}
		}
	}
	
	public void AllowCanShootBullet1(){
		//numShoots+=1;
		canShootBullet1 = true;
	}

	public void AllowCanShootBullet2(){
		//numShoots+=1;
		canShootBullet2 = true;
	}

	public void setBulletType(int index){
		bulletType = index;
	}
}
