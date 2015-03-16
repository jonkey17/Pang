#pragma strict
var normalText : Color;
 var hoverText : Color;
 var pressedText : Color;
 var messagee : GameObject;
 var message = "ButtonPressed";
 
 private var state = 0;
 private var myGUIText : GUIText;
 
 myGUIText = GetComponent(GUIText);
 
 function OnMouseEnter()
 {
    state++;
    if (state == 1)
        myGUIText.color = hoverText;
 }
 
 function OnMouseDown()
 {
    state++;
    if (state == 2)
        myGUIText.color = pressedText;
 }
 
 function OnMouseUp()
 {
    if (state == 2)
    {
        state--;
        if (messagee)
        Debug.Log("ho");
            //messagee.SendMessage(message, gameObject);
    }
    else
    {
        state --;
        if (state < 0)
            state = 0;
    }
    myGUIText.color = normalText;
 }
 
 function OnMouseExit()
 {
    if (state > 0)
        state--;
    if (state == 0)
        myGUIText.color = normalText;
 }