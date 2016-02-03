using UnityEngine;
using System.Collections;

public class autojump : MonoBehaviour {
	
	
	Vector3 endPos; //store character position 

	float yposition;// the y for player 
	bool cycle = false;//time breaker

	bool up = false;//is it up?
	bool keypress = false;// is keypress ?	
	bool hit = false;// collusion with something ?
	int hitcounter = 0; // stop timmer after hit something
	bool down = false;	// is it down ?	
	bool left = false;// is it left ?
	bool right = false;// is it right ?


	private Vector2 fingerStartPos = Vector2.zero;
//	private float minSwipeDist  = 10.0f;
	private float gestureDist = 0.0f;
	bool touchpress = false;
	private float stationtimer = 0.0f;
	float [] busYvalue = new float [10]; // array to store 4 specific x positions to spawn objects
	//private bool done = false; // make sure bound only do once
	int busstartXvalue = 1;
	int numbercounter = 0; // slower counter for jump
	float jumpdistance = 3f;
	public float xounter = 0;
	public float xounter2 = 10;
	public float xounter3 = 0;
	 bool move = false;
	public generation changevalue;
	
	// Use this for initialization
	void Start () {

	}
	/*
	 * if character hit any object that is boundary object .eg wall, jaill 
	 * then pull character off
	 */
	void OnTriggerStay(Collider other) {
		//if (other.gameObject.tag == "topwall") {
		if(other.gameObject.name	=="treemid"){
			Debug.Log ("none");
			this.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - jumpdistance);

		}
		//if (other.gameObject.tag == "leftwall") {
		if(other.gameObject.name	=="leftwall"){	
			hit = true;
			xounter3 = 0;
			Debug.Log ("left");
			this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x + 2.4f, 0.58f,transform.position.z  );



		}
		//if (other.gameObject.tag == "rightwall") {

		if(other.gameObject.name	=="rightwall"){
			xounter3 = 0;
			Debug.Log ("right");
			hit = true;
			this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x - 2.4f, 0.58f, transform.position.z  );


		}

		if(other.gameObject.name	=="bus(Clone)"){
			Debug.Log ("bus hit u");
			this.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - jumpdistance);


		}
		//if (other.gameObject.tag == "car") {

		if(other.gameObject.name	=="newcar(Clone)"){

			Debug.Log ("Car hit you");
			this.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - jumpdistance);
		} 

		//	if (other.gameObject.tag == "police") {

		if(other.gameObject.name	=="policecar"){

			Debug.Log ("police catch you");

		}

		if(other.gameObject.name	=="dvisionpath(Clone)"){
			Debug.Log ("div");



		}

		if(other.gameObject.name	=="dvisionpath"){
			Debug.Log ("div");



		}

		if(other.gameObject.name	=="path"){
			Debug.Log ("path");



		}
		if(other.gameObject.name == "end1(Clone)"|| other.gameObject.name == "end2(Clone)"){
			Debug.Log ("end");



		}


	}
	
	// Update is called once per frame
	void Update () {
		/*
		 * key check and key cd 
		 * 
		 */
		if (this.transform.position.y < 0) {
			this.transform.position = new Vector3 (this.transform.position.x,0.58f,this.transform.position.z);
		}
		if (Input.touchCount > 0) {	
			if (touchpress == false) {
				foreach (Touch touch in Input.touches) {
					switch (touch.phase) {
					case TouchPhase.Began:
						/* this is a new touch */
						up = false;
						//down = false;
						left = false;
						right = false;
						fingerStartPos = touch.position;
						StartCoroutine ("stationCount");
						break;
					
					case TouchPhase.Moved:
						gestureDist = (touch.position - fingerStartPos).magnitude;
						
						//if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist) {
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;
						
						if (Mathf.Abs (direction.x) > Mathf.Abs (direction.y)) {
							// the swipe is horizontal:
							swipeType = Vector2.right * Mathf.Sign (direction.x);
						} else {
							// the swipe is vertical:
							swipeType = Vector2.up * Mathf.Sign (direction.y);
						}
						
						if (swipeType.x != 0.0f) {
							if (swipeType.x > 0.0f) {
								right = true;

								touchpress = true;
							} else {
								left = true;
		
								touchpress = true;
							}
						}
						
						if (swipeType.y != 0.0f) {
							if (swipeType.y > 0.0f) {
								//up = true;
								//touchpress = true;
							} else {
								//down = true;
							}
						}
						//}
						break;
					
					case TouchPhase.Stationary:
						if ((stationtimer >= 1.0f) && (stationtimer <= 2.0f)) {
							up = true;
						
							touchpress = true;
						}
						/*if(gestureDist > minSwipeDist)
							if(directionUp==true)
								moveUp();
							if(directionRight==true)
								moveRight();
							if(directionLeft==true)
								moveLeft();
							if(directionDown==true)
								moveDown();*/
						break;
					
					case TouchPhase.Canceled:
						up = false;
						//down = false;
						left = false;
						right = false;
						stationtimer = 0.0f;
						//touchpress = false;
						break;
					}
				}
			}
		} else if (Input.touchCount == 0) {
			if (keypress == false ) {
				xounter3 = 0;
				numbercounter = 0;
				this.transform.localScale = new Vector3 (0.9f, 1, 1);
				//if (Input.GetButtonDown ("right") ) {
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					up = false;					
					down = false;					
					left = false;
					right = true;
					keypress = true;// we have press a key

				

				}
				//if (Input.GetButtonDown ("left") ) {
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					up = false;					
					down = false;					
					left = true;
					right = false;
					keypress = true;


				}
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					up = false;					
					down = true;					
					left = false;
					right = true;
					keypress = true;// we have press a key


				}
				//if (Input.GetButtonDown ("left") ) {
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					up = true;					
					down = false;					
					left = false;
					right = false;
					keypress = true;				




				}
			}

			if(keypress == true ) {
				
			if(move == true){
					if(numbercounter == 0 ){	
						
					if (xounter2 == 2) {
						StartCoroutine (jumpingup ());

					} else {
						xounter2++;
					}
						
						}

				if (numbercounter == 1) {
					if (xounter2 == 2) {	
						StopCoroutine (jumpingup ());
						StartCoroutine (jumpingdown ());
					
						move = false;
					} else {
						xounter2++;
					}


					}

			
				}

		
			}
			if (xounter3 < 5) {

				xounter3++;




			} else {
				move = true; 
				hit = false;
				//xounter3 = 0;
			}


	
		}

	
	
	}



	IEnumerator jumpingup(){


		/*if (up == false && down == false && left == false && right == false && cycle == false) {



			endPos = new Vector3 (this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z + 1f);
			this.gameObject.transform.position = endPos;
			this.transform.localScale = new Vector3 (1.1f,0.8f,1);



		}*/
		
		if (up == true && cycle == false) {
			

				
				endPos = new Vector3 (this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z + 1f);
				this.gameObject.transform.position = endPos;
				this.transform.localScale = new Vector3 (0.9f,0.9f,1);

				

		}
		if (left == true && cycle == false && hit == false) {



			endPos = new Vector3 (this.transform.position.x-0.8f, this.transform.position.y + 1f, this.transform.position.z + 0.5f);
			this.gameObject.transform.position = endPos;
			this.transform.localScale = new Vector3 (0.9f,0.9f,1);



		}
		if (right == true && cycle == false&& hit == false) {



			endPos = new Vector3 (this.transform.position.x+0.8f, this.transform.position.y + 1f, this.transform.position.z + 0.5f);
			this.gameObject.transform.position = endPos;
			this.transform.localScale = new Vector3 (0.9f,0.9f,1);



		}
	
			
				numbercounter = 1;
				cycle = true;
				xounter2 = 0;
				
				
		yield return new WaitForSeconds(10f);



	}


	IEnumerator  jumpingdown(){

		/*if (cycle == true && up == false && down == false && left == false && right == false) {

			endPos = new Vector3 (this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z + 1f);
			this.transform.localScale = new Vector3 (1, 0.9f, 1);
			this.gameObject.transform.position = endPos;
		}*/

		if (cycle == true && up == true) {
							
			endPos = new Vector3 (this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z + 1f);
			this.transform.localScale = new Vector3 (1f, 0.9f, 1);
			this.gameObject.transform.position = endPos;
		}

		if (left == true && cycle == true&& hit == false) {



			endPos = new Vector3 (this.transform.position.x-0.8f, this.transform.position.y - 1f, this.transform.position.z + 0.5f);
			this.gameObject.transform.position = endPos;
			this.transform.localScale = new Vector3 (1f,0.9f,1);



		}
		if (right == true && cycle == true && hit == false) {



			endPos = new Vector3 (this.transform.position.x+0.8f, this.transform.position.y - 1f, this.transform.position.z + 0.5f);
			this.gameObject.transform.position = endPos;
			this.transform.localScale = new Vector3 (1f,0.9f,1);



		}

				xounter2 = 0;
				up = false;
				left = false;
				right = false;
				down = false;
				cycle = false;
				keypress = false;
				numbercounter = 0;
				yield return new WaitForSeconds(10f);



	}
		
	





	IEnumerator stationCount() {
		yield return new WaitForSeconds(0.1f);
		stationtimer = stationtimer + 0.1f;
	}
}
