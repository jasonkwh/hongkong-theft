using UnityEngine;
using System.Collections;

public class autojump2 : MonoBehaviour {
	
	
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
	int score = 0;

	private Vector2 fingerStartPos = Vector2.zero;
//	private float minSwipeDist  = 10.0f;
	private float gestureDist = 0.0f;
	bool touchpress = false;
	private float stationtimer = 0.0f;
	//private bool done = false; // make sure bound only do once
	int busstartXvalue = 1;
	float jumpdistance = 4f;
	int scoreaddForKeypress = 1;
	int scoredecreaseforhit = 1;
	bool gothit = false;
	int deathtimer = 0;
	float MaxJumpCd = 0.1f;
	public GameObject life;
	public GameObject speed;
	public GameObject scoredouble;
	public GameObject normalspeed;
	public GameObject rain;
	int counterforpotion = 0;
	int Maxtimerpotion  = 300;
	float jumpupvalue = 0.1f;
	float jumpxvalue = 0.07f;
	float jumpdownvalue = 0.1f;
	float MaxjumpLength = 1;
	float TotaljumpLength = 0;
	Vector3 fix_position;
	Vector3 velocity ;
	bool rotation = false;
	int keyPressStorage = -1;
	int oldkeyPressStorage = -1;


	public bool getgothit (){

		return gothit;

	}





	public void setScorepoints (int addscore , int deductscore){

		this.scoreaddForKeypress = addscore;
		this.scoredecreaseforhit = deductscore;

	}
	public void scores (int i){
		score += i;
	}
	public int getscores (){
		return score;
	}


	// Use this for initialization
	void Start () {

		PlayerPrefs.SetInt ("rain",Maxtimerpotion);
		PlayerPrefs.SetInt ("life",Maxtimerpotion);
		PlayerPrefs.SetInt ("score",Maxtimerpotion);
		PlayerPrefs.SetInt ("speed",Maxtimerpotion);
	

	}
	/*
	 * if character hit any object that is boundary object .eg wall, jaill 
	 * then pull character off
	 */
	void OnTriggerStay(Collider other) {
		//if (other.gameObject.tag == "topwall") {

		if (gothit == false) {
			
			if (other.gameObject.name	== "potionLarge"||other.gameObject.name	== "potionLarge(Clone)" ) {
				rain.SetActive(true);
				life.SetActive(false);
				scoredouble.SetActive(false);
				speed.SetActive (false);
				normalspeed.SetActive(true);
				counterforpotion =  0;
			}
			if (other.gameObject.name	== "potionLife"||other.gameObject.name	== "potionLife(Clone)") {
				life.SetActive(true);
				rain.SetActive(false);
				scoredouble.SetActive(false);
				speed.SetActive (false);
				normalspeed.SetActive (true);
				counterforpotion =  0;
			
			}
			if (other.gameObject.name	== "potionScore"||other.gameObject.name	== "potionScore(Clone)") {
				scoredouble.SetActive(true);
				life.SetActive(false);
				rain.SetActive(false);
				speed.SetActive (false);
				normalspeed.SetActive (true);
				counterforpotion =  0;
				scoreaddForKeypress = 3;
			}
			if (other.gameObject.name	== "potionSpeed"||other.gameObject.name	== "potionSpeed(Clone)") {
				speed.SetActive (true);
				normalspeed.SetActive(false);
				scoredouble.SetActive(false);
				life.SetActive(false);
				rain.SetActive(false);
				counterforpotion =  0;
			

			}
			if (other.gameObject.name	== "FloorDrain(Clone)") {
				Debug.Log ("Drain");
				this.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z-jumpdistance );


			}
			if (other.gameObject.name	== "light") {
				Debug.Log ("none");
				this.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - jumpdistance);
				gothit = true;

			}
			//if (other.gameObject.tag == "leftwall") {
			if (other.gameObject.name	== "leftwall") {	
				
				Debug.Log ("left");
				this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x + 2.4f, 0.58f, transform.position.z);


			
			}
			//if (other.gameObject.tag == "rightwall") {

			if (other.gameObject.name	== "rightwall") {

				Debug.Log ("right");

				this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x - 2.4f, 0.58f, transform.position.z);

			
			}


			//	this.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - jumpdistance);



			//if (other.gameObject.tag == "car") {
			if (other.gameObject.name	== "sideright") {

				Debug.Log ("Car hit you");

				this.gameObject.transform.position = new Vector3 (transform.position.x + 1, transform.position.y, transform.position.z);
			} else
			if (other.gameObject.name	== "sideleft") {

				Debug.Log ("Car hit you");

				this.gameObject.transform.position = new Vector3 (transform.position.x - 1, transform.position.y, transform.position.z);
			} else
	
				if (other.gameObject.tag == "car") {

				Debug.Log ("Car hit you");
				if (life.activeSelf == false) {
					gothit = true;
				}
				//this.gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - jumpdistance);
			} 

		

		}
	//	if (other.gameObject.tag == "police") {

	}


	void FixedUpdate (){

		fix_position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		fix_position += velocity * Time.fixedDeltaTime;


		if(keypress == true ) {

		
			if (cycle == false) {
				jumpingup ();

			} 
			if (cycle == true) {

				
				jumpingdown ();
				oldkeyPressStorage =  keyPressStorage ;

			}


		}


	}


	void jumpingup(){


		/*if (up == false && down == false && left == false && right == false && cycle == false) {



			endPos = new Vector3 (this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z + 1f);
			this.gameObject.transform.position = endPos;
			this.transform.localScale = new Vector3 (1.1f,0.8f,1);



		}*/

		if (up == true && cycle == false) {

			velocity = new Vector3 (0.0f,0.0f,4.9f);

			//endPos = new Vector3 (this.transform.position.x, this.transform.position.y + jumpupvalue , this.transform.position.z + jumpupvalue);
			//this.transform.Translate (endPos * Time.deltaTime);
			this.gameObject.transform.position = fix_position + velocity*(Time.time - Time.fixedTime);
		
			//this.gameObject.transform.position = endPos;
			this.transform.localScale = new Vector3 (0.9f,1.1f,1);



		}
		if (left == true && cycle == false && hit == false) {

			//0.75
			velocity = new Vector3 (-4.9f,0.0f,4.9f);

			//endPos = new Vector3 (this.transform.position.x-jumpxvalue, this.transform.position.y + jumpupvalue , this.transform.position.z + jumpupvalue);
			//this.gameObject.transform.position = endPos;
			this.gameObject.transform.position = fix_position + velocity*(Time.time - Time.fixedTime);
			this.transform.localScale = new Vector3 (0.9f,1.1f,1);



		}
		if (right == true && cycle == false&& hit == false) {

			this.transform.Rotate(Vector3.right * Time.deltaTime);
			velocity = new Vector3 (4.9f,0.0f,4.9f);
			this.gameObject.transform.position = fix_position + velocity*(Time.time - Time.fixedTime);
			//endPos = new Vector3 (this.transform.position.x+jumpxvalue , this.transform.position.y + jumpupvalue , this.transform.position.z + jumpupvalue);
			//this.gameObject.transform.position = endPos;
			this.transform.localScale = new Vector3 (0.9f,1.1f,1);



		}
		if (TotaljumpLength < MaxjumpLength) {
			TotaljumpLength+= MaxJumpCd ;


		} else {
			TotaljumpLength = 0;
			cycle = true;


		}







	}


	void jumpingdown(){


		/*if (cycle == true && up == false && down == false && left == false && right == false) {

			endPos = new Vector3 (this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z + 1f);
			this.transform.localScale = new Vector3 (1, 0.9f, 1);
			this.gameObject.transform.position = endPos;
		}*/

		if (cycle == true && up == true) {
			velocity = new Vector3 (0.0f,0.0f,4.9f);
			//endPos = new Vector3 (this.transform.position.x, this.transform.position.y - jumpdownvalue, this.transform.position.z + jumpupvalue);
			this.transform.localScale = new Vector3 (1.1f, 0.9f, 1);

			this.gameObject.transform.position = fix_position + velocity*(Time.time - Time.fixedTime);
			//this.transform.Translate (endPos * Time.deltaTime);
			//	this.gameObject.transform.position = endPos;
		}

		if (left == true && cycle == true && hit == false) {
			
			velocity = new Vector3 (-4.9f,0.0f,4.9f);
			this.gameObject.transform.position = fix_position + velocity*(Time.time - Time.fixedTime);
			//endPos = new Vector3 (this.transform.position.x-jumpxvalue, this.transform.position.y - jumpdownvalue, this.transform.position.z + jumpupvalue);
			//this.gameObject.transform.position = endPos;
			this.transform.localScale = new Vector3 (1.1f,0.9f,1);



		}
		if (right == true && cycle == true && hit == false) {

			this.transform.Rotate(Vector3.right * Time.deltaTime);
			velocity = new Vector3 (4.9f,0.0f,4.9f);
			this.gameObject.transform.position = fix_position + velocity*(Time.time - Time.fixedTime);
			//endPos = new Vector3 (this.transform.position.x+jumpxvalue, this.transform.position.y - jumpdownvalue, this.transform.position.z + jumpupvalue);
			//this.gameObject.transform.position = endPos;
			this.transform.localScale = new Vector3 (1.1f,0.9f,1);



		}
		if (TotaljumpLength < MaxjumpLength) {
			TotaljumpLength += MaxJumpCd ;



		} 
		else {

			TotaljumpLength = 0;
			cycle = false;
			up = false;
			left = false;
			right = false;
			down = false;
			keypress = false;


		}





	}

	void rotations (){
		
		if (oldkeyPressStorage != keyPressStorage) {
			rotation = false;

		}
		if (rotation == false && keyPressStorage == 0) {
			this.transform.rotation = Quaternion.Euler(0,90,0);
			rotation = true;
		} else
			if (rotation == false && keyPressStorage == 1) {
			this.transform.rotation = Quaternion.Euler(0,-90,0);	

			rotation = true;
			} else	if (rotation == false && keyPressStorage == 2 ) {
				this.transform.rotation = Quaternion.Euler(0,0,0);

			}

	}


	// Update is called once per frame
	void Update () {
		/*
		 * key check and key cd 
		 * 
		 */


		if (rain.activeSelf == true) {
			Maxtimerpotion = PlayerPrefs.GetInt ("rain");
		}else
		if (life.activeSelf ==true) {
			Maxtimerpotion = PlayerPrefs.GetInt ("life");
		}else
		if (scoredouble.activeSelf == true) {
			Maxtimerpotion = PlayerPrefs.GetInt ("score");
		}else
		if (speed.activeSelf == true) {
			Maxtimerpotion = PlayerPrefs.GetInt ("speed");
		}

	
		if (rain.activeSelf ==true || life.activeSelf ==true || scoredouble.activeSelf ==true || speed.activeSelf ==true) {
			
			if (counterforpotion < Maxtimerpotion) {
				counterforpotion++;
			} else {
				counterforpotion =  0;
				rain.SetActive(false);
				life.SetActive(false);
				scoredouble.SetActive(false);
				speed.SetActive (false);
				normalspeed.SetActive(true);
			}

		}
		if (this.transform.position.y < 0) {
			this.transform.position = new Vector3 (this.transform.position.x,0.58f,this.transform.position.z);
		}

		if (Input.touchCount > 0 && gothit == false) {	
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
								keyPressStorage = 0;
								keypress = true;
								rotations ();
							} else {
								left = true;
								keyPressStorage = 1;
								keypress = true;
								rotations ();
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

						up = true;
						keyPressStorage = 2;
						keypress = true;
						rotations ();

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

						//touchpress = false;
						break;
					}
				}
			}
		} else
		if (Input.touchCount == 0) {
			if (keypress == false && gothit == false) {

				this.transform.localScale = new Vector3 (0.9f, 1, 1);
				//if (Input.GetButtonDown ("right") ) {
				if (Input.GetKeyDown (KeyCode.RightArrow)) {

					up = false;					
					down = false;					
					left = false;
					right = true;
					keyPressStorage = 0;
					score += scoreaddForKeypress;
					keypress = true;// we have press a key
						rotations ();
				
				

				}
				//if (Input.GetButtonDown ("left") ) {
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					Debug.Log ("left");up = false;					
					down = false;					
					left = true;
					right = false;
					keypress = true;
					keyPressStorage = 1;
					score += scoreaddForKeypress;
					rotations ();
				
				
			

				}
				//if (Input.GetButtonDown ("left") ) {
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					
					up = true;					
					down = false;					
					left = false;
					right = false;
					keypress = true;
					score += scoreaddForKeypress;
					keyPressStorage = 2;

					rotations ();
				




				}
			}
			if (gothit == true) {
				if (deathtimer >= 20 && deathtimer <= 40) {
			 
					this.transform.localScale = new Vector3 (1.1f, 0.1f, 1.1f);
					deathtimer++;
				} else if (deathtimer < 20) {
					deathtimer++;
					this.transform.localScale = new Vector3 (0.9f, 0.1f, 0.9f);
				} else if (deathtimer > 40 && deathtimer <= 60) {

					this.transform.localScale = new Vector3 (1f, 0.1f, 1f);
					deathtimer++;
				} else {
					deathtimer = 0;
				}

			}

			if (speed.activeSelf == true) {
				
				MaxJumpCd = 0.2f;
				jumpupvalue = 0.2f;
				jumpdownvalue = 0.2f;
			} else {
				MaxJumpCd = 0.1f;
				jumpupvalue = 0.1f;
				jumpdownvalue = 0.1f;
			}
	


	
		}



	
	
	
	}




		
	




}
