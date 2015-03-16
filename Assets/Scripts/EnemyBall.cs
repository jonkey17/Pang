using UnityEngine;
using System.Collections;

public class EnemyBall : MonoBehaviour {


	public float horizontalSpeed=2;
	public float verticalSpeed=2;
//	public float bump= 10;
	//public GameObject particle;
	//public GameObject childs;
	public int itemAppearPorcentage=20;
	public int[] itemsPorcentage={20,20,20,20,20};
	public GameObject[] items;

	public bool movingRight= true;

	public Transform childBalls;
	public AudioClip explodeClip;

	private float timeStoping=0;
	public Vector3 velocityBeforeStop;

	// Use this for initialization
	void Awake(){
		if (movingRight){
			rigidbody2D.velocity = new Vector2(horizontalSpeed,verticalSpeed);

		}else{
			rigidbody2D.velocity = new Vector2(-horizontalSpeed,verticalSpeed);
		}
		Physics2D.IgnoreLayerCollision(8,8);
		Physics2D.IgnoreLayerCollision(8,10);
	}
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//Physics2D.IgnoreLayerCollision(8,8);
		//Physics2D.IgnoreLayerCollision(8,10);

	}

	public void Hit(){
		if(childBalls!=null){
			int r=Random.Range(0,100);
			if(r<itemAppearPorcentage){
				r=Random.Range(0,100);
				int index=-1;
				int i=0;
				int sum=0;
				do{
					sum=sum+itemsPorcentage[i];
					//Debug.Log("r"+r+" i"+i+" sum"+sum);
					if(r<sum){
						//Debug.Log("Cambio index"+ index);
						index=i;
					}
					i++;
					//Debug.Log(i+" "+itemsPorcentage.Length);
				}while(index==-1);
				//Debug.Log(index);
				Rigidbody2D item =Instantiate (items[index], transform.position, Quaternion.Euler(new Vector3(0,0,0)))as Rigidbody2D;
			}
			Rigidbody2D mediumBallInstance = Instantiate (childBalls, transform.position, Quaternion.Euler(new Vector3(0,0,0)))as Rigidbody2D;
			if(rigidbody2D.isKinematic){
				GameObject[] gos= GameObject.FindGameObjectsWithTag("MediumBall");
				for(int i= 0; i<gos.Length; i++){
					gos[i].GetComponent<EnemyBall>().stop();
				}
				gos= GameObject.FindGameObjectsWithTag("SmallBall");
				for(int i= 0; i<gos.Length; i++){
					gos[i].GetComponent<EnemyBall>().stop();
				}
				gos= GameObject.FindGameObjectsWithTag("MiniBall");
				for(int i= 0; i<gos.Length; i++){
					gos[i].GetComponent<EnemyBall>().stop();
				}
			}
		}
		AudioSource.PlayClipAtPoint(explodeClip, transform.position);
		//Destroy big ball
		Destroy (gameObject);
	}

	float TimeToStartmoving(){
		float t = ((Time.time) - timeStoping);
		return t;
	}

	public void Hide(bool hide){
		gameObject.renderer.enabled = hide;
	}

	public void stop(){
		if (rigidbody2D.velocity != new Vector2 (0, 0)) {
			velocityBeforeStop=rigidbody2D.velocity;
		}
		rigidbody2D.isKinematic = true;
		Physics2D.IgnoreLayerCollision(8,9);
	}

	public void startMovingAgain(){
		rigidbody2D.isKinematic = false;
		Physics2D.IgnoreLayerCollision (8, 9, false);
		rigidbody2D.velocity = velocityBeforeStop;
	}

}
