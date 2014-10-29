var style:GUIStyle;
style.fontSize=24;
function OnGUI(){
	GUI.Label(Rect(600,100,100,100),"GAME NAME",style);
	GUI.Button(Rect(600,300,200,100),"Start Game");
}

