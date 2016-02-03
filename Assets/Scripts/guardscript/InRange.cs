using UnityEngine;
using System.Collections;

public class InRange : MonoBehaviour {

	/*
	 * check what guard hitting
	 * and return status
	 */ 
	public bool PlayerInRange = false;
	public bool left = false;
	public bool right = false;
	public bool up = false;
	public bool down = false;

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			PlayerInRange = true;
		}
		if (other.gameObject.tag == "leftwall") {
			left = true;
			right = false;
			up = false;
			down = false;
		}
		if (other.gameObject.tag == "rightwall") {
			left =	false;
			right = true;
			up = false;
			down = false;
		}
		if (other.gameObject.tag == "upwall") {
			left = false;
			right = false;
			up = true;
			down = false;
		}
		if (other.gameObject.tag == "downwall") {
			left =	false;
			right = false;
			up = false;
			down = true;
		}
	
	}	
}
