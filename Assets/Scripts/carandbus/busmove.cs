using UnityEngine;
using System.Collections;

public class busmove : MonoBehaviour {

	// Use this for initialization

	float totaldistance ;
	// Update is called once per frame
	void Start(){
		
	

		//speed = Random.Range (0.1f, 0.5f);// assign different speed

	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.name == "destoryMenu" || other.gameObject.name	=="destorycar" || other.gameObject.name	=="light"||  other.gameObject.name	=="leftwall" || other.gameObject.name	=="rightwall") {

			Destroy (this.gameObject); // destory me

		}
	}

	void Update () {
		StartCoroutine( busmovenow());

	}

	IEnumerator busmovenow() {

		this.gameObject.transform.position =  new Vector3 (this.transform.position.x, this.transform.position.y , transform.position.z -	GameObject.Find ("generationtrack").GetComponent<generation>().speedvalue);//move
	
		yield return new WaitForSeconds(120f);
	}
}
