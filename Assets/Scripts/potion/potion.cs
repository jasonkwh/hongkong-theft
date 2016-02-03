using UnityEngine;
using System.Collections;

public class potion : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name	== "thief") {
			Debug.Log ("PlayerGetpotion");
			GameObject.Find ("generationtrack").GetComponent<generation> ().setnumberofpotion (1);
			Destroy (this.gameObject);

		}
		if (other.gameObject.name	== "leftwall" || other.gameObject.name	== "rightwall" || other.gameObject.name	== "light"|| other.gameObject.name	== "destorycar") {			
			Debug.Log ("CpotionDestory");
			GameObject.Find ("generationtrack").GetComponent<generation> ().setnumberofpotion (1);
			Destroy (this.gameObject);

		}
	}
}
