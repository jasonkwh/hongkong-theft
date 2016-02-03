using UnityEngine;
using System.Collections;

public class destoryland : MonoBehaviour {
	bool destorytimerstart = false;
	float timetodestory=0;
	// Use this for initialization
	void OnTriggerStay(Collider other) {
		if (other.gameObject.name	=="policecar") {

			destorytimerstart = true;
		

		}
	}
	// Update is called once per frame
	void Update () {
		if (destorytimerstart == true) {
			timetodestory += 0.5f;
		}
		if (timetodestory >= 10) {

			Destroy(this.gameObject);

		}
	
	}
}
