using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	public bool destroyOnAwake;			// Whether or not this gameobject should destroyed after a delay, on Awake.
	public float awakeDestroyDelay;		// The delay for destroying it on Awake.

	void Awake ()
	{
		// If the gameobject should be destroyed on awake,
		if(destroyOnAwake)
		{
			// ... destroy the gameobject after the delay.
			Destroy(gameObject, awakeDestroyDelay);
		}
		
	}
	void DestroyGameObject ()
	{
		// Destroy this gameobject, this can be called from an Animation Event.
		Destroy (gameObject);
	}
}
