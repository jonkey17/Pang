using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

	public float time;
	private float secondTime;
	private float thirdTime;
	//private float num=0;
	private bool ready=false;//CHAPUCILLA PORWUE NO ME PARABA EL READY
	private bool firstTime=true;
	public GUIText timeText;

	public AudioClip[] hurryUpClip;

	private bool firstSounded =false, secondSounded=false;

	private int numClocksToke = 0;

	public GUIText centerText;

	public AudioClip playerHit;
	private bool timeOut=false;
	// Use this for initialization
	void Awake(){
		stopFromAtag ("BigBall");
		stopFromAtag ("MediumBall");
		stopFromAtag ("SmallBall");
		stopFromAtag ("MiniBall");
		if (time < 100) {
			timeText.text="TIME:0"+(int)time;
		}else{
			timeText.text="TIME:"+(int)time;
		}

		secondTime = time + 2.0f;
		thirdTime = secondTime;

		timeText.fontSize = (int)(timeText.fontSize * GeneralProperties.w);
	}

	void Start () {

		//Debug.Log (Camera.main.WorldToViewportPoint (timeText.transform.position));
		//timeText.pixelOffset.x = Screen.width / 3;
		//timeText.pixelOffset.y = Screen.he / 3;
	}
	
	// Update is called once per frame
	void Update () {
		if ((time < secondTime)&&!ready) {

			secondTime -=Time.deltaTime;
			//Debug.Log(secondTime/0.4);
			if(secondTime<(thirdTime-0.5f)){
				thirdTime=secondTime;
				centerText.enabled=!centerText.enabled;
			}
		}else if (time > 0) {
			if(firstTime){
				firstTime=false;
				ready=true;
				centerText.enabled=false;
				startFromATag("BigBall");
				startFromATag("MediumBall");
				startFromATag("SmallBall");
				startFromATag("MiniBall");
				GameObject.Find("Player").GetComponent<MoveCharacter>().canMove=true;
				GameObject.Find("Gun").GetComponent<Shoot>().canShoot=true;
			}
			time -=Time.deltaTime;

			/*if(time<time-2.0f){
				centerText.enabled=false;
			}*/

			if(time>100){
				timeText.text="TIME:"+(int)time;
			}else{
				timeText.text="TIME:0"+(int)time;
				if(time<50&&!firstSounded){
					firstSounded=true;
					audio.Stop();
					audio.clip=hurryUpClip[0];
					audio.Play();
				}else if(time<20&&!secondSounded){
					secondSounded=true;
					audio.Stop();
					audio.clip=hurryUpClip[1];
					audio.Play();
				}
			}
		}else{
			if(!timeOut){
				timeOut=true;
				centerText.text="Time Over";
				centerText.enabled=true;
				stopFromAtag ("BigBall");
				stopFromAtag ("MediumBall");
				stopFromAtag ("SmallBall");
				stopFromAtag ("MiniBall");
				GameObject.Find("Player").GetComponent<MoveCharacter>().canMove=false;
				GameObject.Find("Gun").GetComponent<Shoot>().canShoot=false;
				StartCoroutine(TimeOut());
			}
		}
	}

	IEnumerator TimeOut(){
		audio.Stop();
		AudioSource.PlayClipAtPoint(playerHit, transform.position);
		yield return new WaitForSeconds(playerHit.length);
		if(GameObject.Find("ScoreManager").GetComponent<ScoreManager>().deceaseLives()>=0){
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void StopMoving(){
		StartCoroutine(StopObject(5f));
		numClocksToke +=1;
	}
	
	public IEnumerator StopObject(float timeInSeconds)
	{
		stopFromAtag ("BigBall");
		stopFromAtag ("MediumBall");
		stopFromAtag ("SmallBall");
		stopFromAtag ("MiniBall");
		yield return new WaitForSeconds(timeInSeconds);
		if(numClocksToke<2){
			HideObjectFromTag ("BigBall", false);
			HideObjectFromTag ("MediumBall", false);
			HideObjectFromTag ("SmallBall", false);
			HideObjectFromTag ("MiniBall", false);
			yield return new WaitForSeconds(0.5f);
			HideObjectFromTag ("BigBall", true);
			HideObjectFromTag ("MediumBall", true);
			HideObjectFromTag ("SmallBall", true);
			HideObjectFromTag ("MiniBall", true);
			yield return new WaitForSeconds(0.5f);
		}
		if(numClocksToke<2){
			HideObjectFromTag ("BigBall", false);
			HideObjectFromTag ("MediumBall", false);
			HideObjectFromTag ("SmallBall", false);
			HideObjectFromTag ("MiniBall", false);
			yield return new WaitForSeconds(0.5f);
			HideObjectFromTag ("BigBall", true);
			HideObjectFromTag ("MediumBall", true);
			HideObjectFromTag ("SmallBall", true);
			HideObjectFromTag ("MiniBall", true);
			yield return new WaitForSeconds(0.5f);
		}
		if(numClocksToke<2){
			HideObjectFromTag ("BigBall", false);
			HideObjectFromTag ("MediumBall", false);
			HideObjectFromTag ("SmallBall", false);
			HideObjectFromTag ("MiniBall", false);
			yield return new WaitForSeconds(0.5f);
			HideObjectFromTag ("BigBall", true);
			HideObjectFromTag ("MediumBall", true);
			HideObjectFromTag ("SmallBall", true);
			HideObjectFromTag ("MiniBall", true);
			yield return new WaitForSeconds(0.5f);
			//Debug.Log ("andar");
			startFromATag ("BigBall");
			startFromATag ("MediumBall");
			startFromATag ("SmallBall");
			startFromATag ("MiniBall");
		}
		numClocksToke-=1;
	}

	void HideObjectFromTag(string tag, bool y){
		GameObject[] gos= GameObject.FindGameObjectsWithTag(tag);
		//Debug.Log(gos.Length);
		for(int i= 0; i<gos.Length; i++){
			gos[i].GetComponent<EnemyBall>().Hide(y);
		}
	}

	void stopFromAtag(string tag){
		GameObject[] gos= GameObject.FindGameObjectsWithTag(tag);
		//Debug.Log(gos.Length);
		for(int i= 0; i<gos.Length; i++){
			gos[i].GetComponent<EnemyBall>().stop();

		}
	}

	void startFromATag(string tag){
		GameObject[] gos= GameObject.FindGameObjectsWithTag(tag);
		//Debug.Log(gos.Length);
		for(int i= 0; i<gos.Length; i++){
			gos[i].GetComponent<EnemyBall>().startMovingAgain();
		}
	}

	void OnApplicationPause(bool pause){
		if (pause) {
			stopFromAtag ("BigBall");
			stopFromAtag ("MediumBall");
			stopFromAtag ("SmallBall");
			stopFromAtag ("MiniBall");
			GameObject.Find("Player").GetComponent<MoveCharacter>().canMove=false;
			GameObject.Find("Gun").GetComponent<Shoot>().canShoot=false;
		}else{
			ready=false;
			firstTime=true;
			centerText.enabled=true;
			secondTime = time + 2.0f;
			thirdTime = secondTime;
		}

	}
}
