using UnityEngine;
using System.Collections;

public class policecarmove : MonoBehaviour {
	float speed= 0.01f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(policemovenow());
	}


	IEnumerator policemovenow() {

		this.gameObject.transform.position =  new Vector3 (this.transform.position.x, this.transform.position.y , transform.position.z +	speed);//move
	
		yield return new WaitForSeconds(120f);
	}
}
