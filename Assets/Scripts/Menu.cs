using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GUIContent buttonTexture;
	void OnGUI()
	{
		const int anchoBoton = 84;
		const int altoBoton = 60;
		//GUI.backgroundColor=Color.clear;
		// Dibujamos un boton  de inicio del juego
		if (
			GUI.Button(
			new Rect(
			Screen.width / 2 - (anchoBoton / 2),
			(2 * Screen.height / 3) - (altoBoton / 2),
			anchoBoton,
			altoBoton
			),
			buttonTexture
			)
			)
		{
			// Al hacer Clic iniciamos el nivel 1

			Debug.Log("Presionado");
		}
	}
}
