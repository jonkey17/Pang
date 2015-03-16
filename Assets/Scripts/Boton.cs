using UnityEngine;
using System.Collections;

public class Boton : MonoBehaviour {


	public Material[]mats;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter()
	{
		transform.guiText.material = mats [0];
	}

	void OnMouseExit()
	{
		transform.guiText.material = mats [1];
	}

	void OnMouseUpAsButton(){
		Application.LoadLevel("1");
	}
}
