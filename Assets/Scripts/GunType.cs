using UnityEngine;
using System.Collections;

public class GunType : MonoBehaviour {

	public Sprite[] toolSprites;
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
	}

	public void changeTool(int tool){
		spriteRenderer.enabled = true;
		spriteRenderer.sprite = toolSprites[ tool ];
	}
}
