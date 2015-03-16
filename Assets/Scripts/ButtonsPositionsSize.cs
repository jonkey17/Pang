using UnityEngine;
using System.Collections;

public class ButtonsPositionsSize : MonoBehaviour {

	private GUITexture button;
	void Awake(){
		button= (GUITexture)GetComponent(typeof(GUITexture));
		button.pixelInset = 
			new Rect(Mathf.Round(button.pixelInset.x* (GeneralProperties.w)), Mathf.Round(button.pixelInset.y*GeneralProperties.h),Mathf.Round(button.pixelInset.width*GeneralProperties.w), Mathf.Round(button.pixelInset.height *GeneralProperties.w));
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
