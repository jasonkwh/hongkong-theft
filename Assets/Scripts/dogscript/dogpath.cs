using UnityEngine;
using System.Collections;

public class dogpath : MonoBehaviour {
	/*
	 * dog random walking path 
	 * dog will change their walking path after they walk for certain sec 
	 * 
	 */
	private int movetimer = 0;//counter to keep track and compare with movetimerMax
	private float movement = 1f;//movement speed for the dog
	private int movetimerMax = 200;// timer for changes
	private bool moveup = false;//check moving status
	private bool movedown = false;//check moving status
	public int cyclechange = 0;//pathing selection


	// Use this for initialization
	void Start () {

		cyclechange = Random.Range (0, 3);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (cyclechange == 0) {
			moveupback ();
		} else if (cyclechange == 1){
			moveleft();
		} else if (cyclechange == 2){
			moveright();
		}
	}

	//move up and down
	void moveupback(){
		
		if (movetimer < movetimerMax && movedown == false) {
			this.transform.Translate (Vector3.left * movement * Time.deltaTime);
			movetimer++;
			moveup = true;
		} else if (moveup = true && movetimer != 0) {
			this.transform.Translate (Vector3.right * movement * Time.deltaTime);
			movetimer --;
			movedown = true;
		} else if (movetimer == 0) {
			movedown = false;
			moveup = false;
			cyclechange = Random.Range (0, 3);
		}
	}
	//move left and right
	void moveleft(){
		
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
			cyclechange = Random.Range (0, 3);
		}
	}

	//move right and left
	void moveright(){
		
		if (movetimer < movetimerMax && movedown == false) {
			this.transform.Translate (Vector3.back * movement * Time.deltaTime);
			movetimer++;
			moveup = true;
		} else if (moveup = true && movetimer != 0) {
			this.transform.Translate (Vector3.forward * movement * Time.deltaTime);
			movetimer --;
			movedown = true;
		} else if (movetimer == 0) {
			movedown = false;
			moveup = false;
			cyclechange = Random.Range (0, 3);
		}
	}

}
