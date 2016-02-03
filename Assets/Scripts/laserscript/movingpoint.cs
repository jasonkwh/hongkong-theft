using UnityEngine;
using System.Collections;

public class movingpoint : MonoBehaviour {

	/*
	 * move laser up and down
	 * 
	 * 
	 */ 
	private int movetimer = 0;//counter to compare with movetimermax
	private float movement = 1f;//move time
	private int movetimerMax = 200;
	private bool moveup = false;//check is it up
	private bool movedown = false;//check is it down
	// Use this for initialization
	void Start () {
	
	}
	
	//move up or down
	void Update () {
		
		//move up or down
		/*if (movetimer < movetimerMax && movedown == false) {
			this.transform.Translate (Vector3.up * movement * Time.deltaTime);
			movetimer++;
			moveup = true;
		} else if (moveup = true && movetimer != 0) {
			this.transform.Translate (Vector3.down * movement * Time.deltaTime);
			movetimer --;
			movedown = true;
		} else if (movetimer == 0) {
			movedown = false;
			moveup = false;
		}*/
		//move left or right
		if (movetimer < movetimerMax && movedown == false) {
			this.transform.Translate (Vector3.forward * movement * Time.deltaTime);
			movetimer++;
			moveup = true;
		} else if (moveup = true && movetimer != 0) {
			this.transform.Translate (Vector3.back * movement * Time.deltaTime);
			movetimer --;
			movedown = true;
		} else if (movetimer == 0) {
			movedown = false;
			moveup = false;
		}
	}
}
