using UnityEngine;
using System.Collections;

public class policemove : MonoBehaviour {
	Vector3 endPos; //store character position 
	float  jumpup = 0.1f; // jump up control variable
	float  jumpcount = 0.1f;// increment for jump up
	float  floor ;//the y for floor
	float walkforward  = 0.2f; //forward;
	float walkforwardcount  = 0.1f;// jump speed up by 0.2
	float  maxrange  = 0.6f; // the jump heigh
	float yposition;// the y for player
	Vector3 startScale = new Vector3(1.1f,0.95f,1); // jump bound size 
	bool jumpupnow = true;// is it jumping upward
	bool jumpdownnow = false;//is it jumping downward
	bool cycle = true;//time breaker
	int timer = 0;//counter for timer
	int maxtimer = 20;//next jump waitting timer
	// Use this for initialization
	void Start () {

		floor = transform.position.y; // store the orignal y

	}
	
	// Update is called once per frame
	void Update () {



		if (cycle) {
			/*jump up now
			 * if it is not up key or no key
			*  small jump up frame break;
			*increase jump up range by counter
			*change scale while jumping
			 */
	

				if (jumpup < maxrange &&  jumpupnow == true ) {
					jumpdownnow = false;
					StartCoroutine(slowjump());
					jumpup = jumpup + jumpcount;
					transform.localScale = startScale;
				} else 
					/*jump down now
					*  small jump down frame break;
					*decrease jump rate range by counter
					 */

					if (transform.position.y > floor ) {
						jumpdownnow = true;
						jumpupnow = false;
						StopCoroutine(slowjump());
						StartCoroutine(slowjumpdown());
						jumpup -= jumpcount;

						/*finish jumping cycle
					*  stop frame break
					*reset jumpup rate;
					 */
					} else if (jumpup <= floor){
						StopCoroutine(slowjumpdown());
						cycle = false;
						jumpup = 0.1f;

					}


		


			//do jump
			this.gameObject.transform.position = endPos;

		}
		/**
		 * finish jump cycle 
		 * jump break
		 * reset scale
		 * 
		 */
		if(cycle == false)
		if (timer < maxtimer) {
			if(timer == 2){
				transform.localScale = new Vector3(1,1,1);
			}
			timer ++;
		} else {
			timer = 0;
			cycle = true;
			jumpupnow = true;
		}
	}
	/*
	 * jump up 
	 * 
	 */ 
	IEnumerator slowjump()
	{
		
			endPos = new Vector3 (transform.position.x, transform.position.y + jumpup, transform.position.z + walkforward);

		yield return new WaitForSeconds(20);
	}
	/*
	 * jump down
	 * 
	 */
	IEnumerator slowjumpdown()
	{
		
			endPos = new Vector3 (transform.position.x, transform.position.y - jumpup, transform.position.z + walkforward);
		
		yield return new WaitForSeconds(20);
	}




	
	}



