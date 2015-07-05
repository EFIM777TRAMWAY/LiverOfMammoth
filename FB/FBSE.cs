using UnityEngine;
using System.Collections;

public class FBSE : MonoBehaviour {
	private float maxsize = 5F;
	private float minsize = 10F;
	public Camera MainCam;
	private float smooth = 0.75F;
	private Vector2 curDist = new Vector2(0,0);
	private Vector2 prevDist = new Vector2(0,0);

	void Update () {
		if (Input.touchCount == 2 && Input.GetTouch (0).phase == TouchPhase.Moved && Input.GetTouch (1).phase == TouchPhase.Moved) {
			curDist = Input.GetTouch(0).position - Input.GetTouch(1).position; 
			prevDist = ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition) - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition)); 
			float touchDelta = curDist.magnitude - prevDist.magnitude;
			MainCam.orthographicSize = Mathf.Clamp (Mathf.Lerp (MainCam.orthographicSize, MainCam.orthographicSize - touchDelta,Time.deltaTime * smooth),maxsize,minsize);
		}
	
	}
}
