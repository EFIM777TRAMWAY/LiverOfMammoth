using UnityEngine;
using System.Collections;

public class FBSH : MonoBehaviour {
	public float minSwipeDistY;
	private bool paused = false;
	private Vector2 startPos;
	private GameObject maincam = null;
	
	void Update()
	{
		if (Input.touchCount == 1 && Input.GetTouch (0).position.x < (Screen.width - 0.75F * Screen.width) && Input.GetTouch(0).position.y > Screen.height/5)
			
		{
			
			Touch touch = Input.touches[0];
			
			
			
			switch (touch.phase) 
				
			{
				
			case TouchPhase.Began:
				
				startPos = touch.position;
				
				break;
				
				
				
			case TouchPhase.Ended:
				
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
				
				if (swipeDistVertical > minSwipeDistY) 
					
				{
					
					float swipeValue = Mathf.Sign(touch.position.y - startPos.y); //Return value is 1 when f is positive or zero, -1 when f is negative
					
					if (swipeValue > 0){
						maincam = GameObject.FindGameObjectWithTag("MainCamera");
						Debug.Log ("pupu");
					}
						
						else if (swipeValue < 0){
				}
			}
				break;
		}
	}
}
}