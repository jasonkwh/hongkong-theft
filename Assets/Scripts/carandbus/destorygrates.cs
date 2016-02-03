using UnityEngine;
using System.Collections;

public class destorygrates : MonoBehaviour {

	void OnTriggerStay(Collider other) {
		if (other.gameObject.name	=="destorycar" || other.gameObject.name	=="light"||  other.gameObject.name	=="leftwall" || other.gameObject.name	=="rightwall") {
		//	GameObject.Find ("generationtrack").GetComponent<generation>().setnumberofGrate (1);
			Destroy (this.gameObject); // destory me

		}
	}
}
