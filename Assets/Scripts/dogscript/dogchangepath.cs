using UnityEngine;
using System.Collections;

public class dogchangepath : MonoBehaviour {
	/*
	 * detect whether dog hitting with something
	 * if the thing is not player select an other random path
	 * if the thing is player ,player lost
	 */
	public dogpath change;//change path status from dog path

	void OnTriggerStay(Collider other) {
		
		if (other.gameObject.tag != "Player") {


			change.cyclechange = Random.Range (0, 3);
			
		}
		if (other.gameObject.tag == "Player") {
			
			
			
			Debug.Log("dogfindplayer");
			
		}
	}


}
