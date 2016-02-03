using UnityEngine;
using System.Collections;

public class AIautoPathing : MonoBehaviour {
	/*
	 *	guards repeatly moving left and right 
	 * 
	 */
	public int pathingChoose;//chosing left or right path
	public float movespeed = 5.0f;
	public bool Turnleft ;//is it left
	public bool Turnright ;//is it right
	public InRange turnnow;//check status for left and right

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Turnleft = turnnow.left;
		Turnright =turnnow.right;
		if (Turnleft == true) {

			gameObject.transform.rotation =Quaternion.Euler(0,90,0);
			pathingChoose = 0;
			Turnleft = false;
		}else

		if(Turnright == true ) {
	
			gameObject.transform.rotation =Quaternion.Euler(0,270,0);
				
			pathingChoose = 0;
			Turnright = false;
		}

		if (pathingChoose == 0) {
			this.transform.Translate( Vector3.forward*movespeed*Time.deltaTime);
		}			
		if (pathingChoose == 1) {
			this.transform.Translate( Vector3.back*movespeed*Time.deltaTime);
		}
		
		if (pathingChoose == 2) {
			//this.transform.Rotate(Vector3.down*rot);
			this.transform.Translate(Vector3.left *movespeed* Time.deltaTime);
		}
		
		if (pathingChoose == 3) {
			//this.transform.Rotate(Vector3.up*rot);
			this.transform.Translate(Vector3.right *movespeed* Time.deltaTime);
		}	
	}
}
