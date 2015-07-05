using UnityEngine;
using System.Collections;

public class FBSC : MonoBehaviour {
	public float smooth = 1.6F;
	private float limiter = 55F;
	private float mindelta = -20F;
	private float maxdelta = 100F;
	private float xlimiter = 3.4F;
	private int frame = -1;
	private GameObject RotationPointU = null;
	void Update() {
		if (Input.touchCount == 1 && frame != Time.frameCount && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			var touch = Input.GetTouch (0);
			if(touch.position.x > Screen.width/4 && touch.position.y > Screen.height/5 && touch.position.x < (Screen.width - Screen.width/10) && touch.position.y < (Screen.height - Screen.height/10) && Mathf.Abs (touch.deltaPosition.x) < xlimiter){
				float tiltAroundZ = touch.deltaPosition.y * limiter;
				RotationPointU = GameObject.FindGameObjectWithTag("PlayersHand");
				if(RotationPointU){
				RotationPointU.transform.rotation = Quaternion.Slerp(RotationPointU.transform.rotation, Quaternion.Euler (0,0,RotationPointU.transform.rotation.z + Mathf.Clamp (tiltAroundZ, mindelta,maxdelta)), Time.deltaTime * smooth);
				frame = Time.frameCount;
				}
			}
		}
	}
}