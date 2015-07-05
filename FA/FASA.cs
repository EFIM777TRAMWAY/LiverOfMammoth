using UnityEngine;
using System.Collections;

public class FASA : MonoBehaviour {
		void Start() {
			Vector3 position = new Vector3(Random.Range(-45.0F, -5.0F), 0.9F, 0);
			GameObject player = Instantiate(Resources.Load ("Player", typeof(GameObject)), position, Quaternion.identity) as GameObject;
	}
}