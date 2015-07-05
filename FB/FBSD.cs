using UnityEngine;
using System.Collections;

public class FBSD : MonoBehaviour {
	private int frame = -1;
	public GameObject ShootButton;
	GameObject InstantiatedButton = null;
	private GameObject Canvas;
	private GameObject Copyofbutton = null;
	void Start () {
	
	}
	void Update () {
		if (Input.touchCount > 0 && frame != Time.frameCount){
			var touch = Input.GetTouch (0);
			if(touch.position.x > Screen.width/4 && touch.position.y > Screen.height/5 && touch.position.x < (Screen.width - Screen.width/10) && touch.position.y < (Screen.height - Screen.height/10)){

				if(touch.phase == TouchPhase.Ended){
					Canvas = GameObject.Find ("Canvas");
					Vector2 bplace = Camera.main.ScreenToWorldPoint(touch.position);
					if(Canvas.gameObject.transform.parent == null){
						InstantiatedButton = Instantiate(ShootButton, bplace, Quaternion.identity) as GameObject;
						InstantiatedButton.transform.SetParent(Canvas.transform, false);
						InstantiatedButton.transform.position = new Vector2(bplace.x,bplace.y);
				}
					else if(Canvas.gameObject.transform.parent != null){
						Copyofbutton = GameObject.FindGameObjectWithTag("Crosshair");
						Destroy(Copyofbutton);
	}
}
}
}
}
}