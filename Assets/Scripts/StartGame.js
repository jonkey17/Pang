#pragma strict

var texto: GUIText; //el objeto texto que parpadeará
private var Fadetexttime : float = 0; //contador de tiempo
//Esta función nos permitirá setear varias variables al valor por defecto que deseemos cuando empiece la escena
function Start()
{
	Globals.Lives = 3;
	Globals.Score = 0;
	Globals.Bulletlimit = 0;
}
function Update () { //Esta función se repetirá cada frame
	if(Input.GetButtonDown("Jump"))
	{
		Application.LoadLevel(Globals.Levels + 1); //Si pulsamos el botón especificado como Jump el juego cargará el próximo nivel y seremos transportados a éste.
	} 
	if(Input.GetKeyDown(KeyCode.C))
	{
		Application.OpenURL("http://elcazadordeleyendas.blogspot.com/"); //Si pulsamos el botón especificado (aquí, la tecla “C” del teclado), se abrirá el explorador por defecto y nos llevará a la página web especificada)
	}
	if(Input.GetKeyDown(KeyCode.Escape))
	{
		Application.Quit(); //Si pulsamos la tecla indicada saldremos del juego
	}
	if(Fadetexttime < 1)
	{
		Fadetexttime = Fadetexttime + 1 * Time.deltaTime; //mientras que nuestro contador tenga un valor inferior a 1, su valor sera sumado por el tiempo que ha pasado después del último frame
	} else
	{
		texto.text = "";
		Fadetexttime = Fadetexttime + 1 * Time.deltaTime; //de lo contrario, no mostrará texto alguno
		if(Fadetexttime >= 2)
		{
			texto.text = "Pulsa espacio o el boton B para jugar";
			Fadetexttime = 0; //y si el tiempo es superior a 2, mostrará el texto otra vez y reiniciará el contador
		}
	}
}

