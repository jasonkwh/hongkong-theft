using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	/*
	 * player movement controller
	 * 
	 */ 
	public float movespeed = 5.0f;
	public float rot = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey ("up")) {
			this.transform.Translate( Vector3.forward*movespeed*Time.deltaTime);
		}			
		if (Input.GetKey ("down")) {
			this.transform.Translate( Vector3.back*movespeed*Time.deltaTime);
		}
				
		if (Input.GetKey ("left")) {
			//this.transform.Rotate(Vector3.down*rot);
			this.transform.Translate(Vector3.left *movespeed* Time.deltaTime);
		}
					
		if (Input.GetKey ("right")) {
			//this.transform.Rotate(Vector3.up*rot);
			this.transform.Translate(Vector3.right *movespeed* Time.deltaTime);
		}
	
	}
}
