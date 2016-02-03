using UnityEngine;
using System.Collections;

public class camfollow : MonoBehaviour {
	public GameObject chickenPlayer;
	public Menu menu;
	Vector3 shouldPos = new Vector3 (0,0,0);
	GameObject OldPositionForPlayer;
	int timer = 0;
	int timer2 = 0;
	int Maxtimer = 50;
	bool keyPress = true;

	void Update () {
		//chickenPlayer = GameObject.Find ("Player2");
		if (menu.Getstart () == true) {
			OldPositionForPlayer = chickenPlayer;

			if (Input.anyKey) {
				if (keyPress == false) {
					this.gameObject.transform.position = new Vector3 (chickenPlayer.transform.position.x, 1, chickenPlayer.transform.position.z + 8);
					timer = 0;


				}
				keyPress = true;
				timer2 = 0;
			} else if (timer2 > Maxtimer) {
				if (timer > Maxtimer && OldPositionForPlayer.transform.position == chickenPlayer.transform.position) {

					keyPress = false;
					this.gameObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.01f);

				} else {
					timer++;
				}
			} else {

				timer2++;
			}
		
			if (keyPress == true) {
				Vector3 Carm = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
				Vector3 Player = new Vector3 (chickenPlayer.transform.position.x, chickenPlayer.transform.position.y, chickenPlayer.transform.position.z + 8);
				shouldPos = Vector3.Lerp (Carm, Player, Time.deltaTime);	
				this.gameObject.transform.position = new Vector3 (shouldPos.x, 1, shouldPos.z);
				OldPositionForPlayer = chickenPlayer;
			}
		 
		
		
			
		}
	}

	}

		
