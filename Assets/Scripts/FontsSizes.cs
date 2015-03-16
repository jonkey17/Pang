using UnityEngine;
using System.Collections;

public class FontsSizes : MonoBehaviour {

	public GUIText guiText;
	// Use this for initialization
	void Awake () {
		guiText.fontSize = (int)(guiText.fontSize * GeneralProperties.w);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
