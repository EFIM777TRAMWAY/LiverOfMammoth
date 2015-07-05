#pragma strict

var swipeThresh : float = 1.2; var swipeStart : Vector2 = Vector2.zero; var swipeEnd : Vector2 = Vector2.zero; var swipeWasActive : boolean = false;

function Update () { if ( Input.touchCount == 1 ) { processSwipe(); } }

function OnGUI () { processSwipe(); drawStartBox(); drawEndBox(); }

function processSwipe () { if ( Input.touchCount != 1 ) { return; }

 var theTouch : Touch = Input.touches[0];
 
 /* skip the frame if deltaPosition is zero */
 
 if ( theTouch.deltaPosition == Vector2.zero ) {
     return;
 }
 
 var speedVec : Vector2 = theTouch.deltaPosition * theTouch.deltaTime;
 var theSpeed :   float = speedVec.magnitude;
 
 var swipeIsActive : boolean = ( theSpeed > swipeThresh );
 
 if ( swipeIsActive ) {
 
     if ( ! swipeWasActive ) {
         swipeStart = theTouch.position;
     }
 }
 
 else {
 
     if ( swipeWasActive ) {
         swipeEnd = theTouch.position;
         Debug.Log("Swipe Complete");
     }
 }
 
 swipeWasActive = swipeIsActive;
}

function drawStartBox () { if ( swipeStart == Vector2.zero ) { return; }

 /* don't forget to invert the y-coordinate */
 
 var theY = Screen.height - swipeStart.y;
 var theX = swipeStart.x;
 
 var theW = 140;
 var theH =  40;
 
 var theRect : Rect = Rect(theX, theY, theW, theH);
 
 GUI.Label(theRect, "Start");
}

function drawEndBox () { if ( swipeEnd == Vector2.zero ) { return; }

 /* don't forget to invert the y-coordinate */
 
 var theY = Screen.height - swipeEnd.y;
 var theX = swipeEnd.x;
 
 var theW = 140;
 var theH =  40;
 
 var theRect : Rect = Rect(theX, theY, theW, theH);
 
 GUI.Label(theRect, "End");
}