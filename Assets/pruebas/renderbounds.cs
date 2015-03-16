using UnityEngine;
using System.Collections;

public class renderbounds : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnDrawGizmosSelected() {
		Debug.Log (renderer.bounds.min);
		renderer.bounds.SetMinMax (renderer.bounds.min - new Vector3(4,20,0), renderer.bounds.max - new Vector3(1,0,0));
		Debug.Log (renderer.bounds.min);
		//renderer.bounds.SetMinMax (new Vector3(4,2,0), new Vector3(2,2,0));
		Vector3 center = renderer.bounds.center;
		float radius = renderer.bounds.extents.magnitude;
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(center, radius);
	}

}
