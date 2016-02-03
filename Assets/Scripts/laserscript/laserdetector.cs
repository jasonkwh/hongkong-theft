using UnityEngine;
using System.Collections;

public class laserdetector : MonoBehaviour {
	//laser decter player

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player") {//hit ammo
			Debug.Log("laserhitplayer");
		}
	}
}
