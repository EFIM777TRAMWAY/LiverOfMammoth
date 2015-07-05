using UnityEngine;
using System.Collections;

public class FCSB : MonoBehaviour {
	private float leftborder = -15F;
	private float rightborder = 15F;
	private int frame = -1;
	private Vector2 BGPose = new Vector2 (0, 0);
	private GameObject maincam = null;
	private GameObject bg = null;

	void Start(){
		maincam = GameObject.FindGameObjectWithTag ("MainCamera");
		bg = GameObject.FindGameObjectWithTag ("Background");
	}

	void Update () {
			BGPose = new Vector2 (maincam.transform.position.x / 7, 0);
			bg.transform.position = BGPose;
	}
}
