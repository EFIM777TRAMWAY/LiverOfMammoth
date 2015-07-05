using UnityEngine;
using System.Collections;

public class FBSF : MonoBehaviour {
	private int frame = -1;
	private GameObject MainCam = null;
	private float ylimiter = 0.8F;
	private float limiter = 1.5F;
	private float smooth = 1.1F;
	private Vector2 CamPos = new Vector2(0,3);
	private float leftborder = -50F;
	private float rightborder = 50F;

	void Update () {
		if(Input.touchCount == 1 && frame != Time.frameCount){
			var touch = Input.GetTouch (0);
			if(touch.position.y > Screen.height/5 && touch.position.y < (Screen.height - Screen.height/10) && touch.phase == TouchPhase.Moved && Mathf.Abs (touch.deltaPosition.y) < ylimiter){
				MainCam = GameObject.Find ("Main Camera");

				if(MainCam){
					float DeltaX = touch.deltaPosition.x * limiter;
					Vector2 CamPosCh = new Vector2(touch.deltaPosition.x,0);
					float lal = Mathf.Lerp (MainCam.transform.position.x,Mathf.Clamp ((MainCam.transform.position.x - CamPosCh.x),leftborder,rightborder),Time.deltaTime * smooth);
					CamPos = new Vector2(lal,3);
					MainCam.transform.position = CamPos;
				}
			}
		}
	}
}