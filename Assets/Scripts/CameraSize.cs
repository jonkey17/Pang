using UnityEngine;
using System.Collections;

public class CameraSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		/*float xFactor = Screen.width / 800f;
		float yFactor = Screen.height  / 1280f;
		
		
		Camera.main.rect=new Rect(0,0,1,xFactor/yFactor);
		*/
		Camera.main.aspect = 5.3f/3f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
