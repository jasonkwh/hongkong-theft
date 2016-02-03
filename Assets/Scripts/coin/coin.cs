using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {


	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name	== "thief") {
			Debug.Log ("PlayerGetCoins");
			GameObject.Find ("generationtrack").GetComponent<generation>().changecoins(1);
			GameObject.Find ("generationtrack").GetComponent<generation>().addcoin(1);
			Destroy (this.gameObject);

		}
		if (other.gameObject.name	== "leftwall" || other.gameObject.name	== "rightwall" || other.gameObject.name	== "light"|| other.gameObject.name	== "destorycar") {
			GameObject.Find ("generationtrack").GetComponent<generation>().changecoins(1);
			Debug.Log ("CoinDestory");
			Destroy (this.gameObject);

		}
	}
}
