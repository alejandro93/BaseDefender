#pragma strict

var pointB : Vector2;

function Start () {
	var pointA = transform.position;
	while (true) 
	{
		yield MoveObject(transform, pointA, pointB, 3.0);
		yield MoveObject(transform, pointB, pointA, 3.0); 
	}
}
function MoveObject (thisTransform : Transform, startPos : Vector2, endPos : Vector2, time : float) {
	var i = 0.0;
	var rate = 1.0/time;
	while (i < 1.0) {
		i += Time.deltaTime * rate;
		thisTransform.position = Vector2.Lerp(startPos, endPos, i);
		yield;
	}
}

function Update () {

}