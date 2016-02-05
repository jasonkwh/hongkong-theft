using UnityEngine;
using System.Collections;

public class trackmove : MonoBehaviour {
	float speed= 0.2f;
	GameObject player;
	public Menu menu;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (GameObject.Find("MenuController").GetComponent<MenuController>().ReturnPlayerStatus() == true) {
			player = GameObject.Find ("thief");
			//Debug.Log (this.gameObject.transform.position.z - player.transform.position.z);
			if (this.gameObject.transform.position.z - player.transform.position.z < 30) {
				this.gameObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, transform.position.z +	speed);//move
			}
		}
	}
		
}
