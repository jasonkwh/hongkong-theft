using UnityEngine;
using System.Collections;

public class difficultySetting : MonoBehaviour {
	int Maxspawntime = 200;
	float CarMoveSpeed = 0.1f;
	int MaxCoinIngame = 1;
	int numberOfCar = 1;
	public int currentCoin;
	int scoreaddForKeypress = 1;
	int scoredecreaseforhit = 2;
	public int score = 0;
	bool lost = false;
	int [] pattenr1 = new int [20];
	int [] pattenr2 = new int [20];
	public GameObject scorecheck;
	public Menu menu;
	// Use this for initialization

	public int[] pattern1(){

		return pattenr1;
	}

	public int[] pattern2(){

		return pattenr2;
	}
	void Update (){


		if (GameObject.Find("MenuController").GetComponent<MenuController>().ReturnPlayerStatus() == true ) {
			lost = GameObject.Find ("thief").GetComponent<autojump2> ().getgothit (); // did u get hit by car or bus
			currentCoin = GameObject.Find ("generationtrack").GetComponent<generation> ().getcoins (); //total coin
			score = GameObject.Find ("thief").GetComponent<autojump2> ().getscores (); // total score
			if (score < 50) {
				pattenr1 = new int []{ 0, 1, 2, 3, 0, 2, 1, 0, 2, 1, 3, 0, 3, 1, 2, 0 };//pattern for road1
				pattenr2 = new int []{ 4, 5, 6, 7, 7, 6, 5, 4, 7, 5, 6, 4, 5, 4, 7, 6 };//pattern for road1
				GameObject.Find ("generationtrack").GetComponent<generation> ().difficulty (Maxspawntime - 10, CarMoveSpeed, MaxCoinIngame, numberOfCar);
				GameObject.Find ("generationtrack").GetComponent<generation> ().counterfornumberofCar = 0;
			} else if (score >= 50 && score < 100) {
		
				pattenr1 = new int []{ 1, 2, 3, 2, 3, 0, 3, 2, 3, 0, 2, 1, 3, 0, 2, 0 };//pattern for road1
				pattenr2 = new int []{ 5, 7, 6, 4, 6, 7, 7, 6, 4, 7, 5, 6, 5, 7, 4, 6 };//pattern for road1
				GameObject.Find ("generationtrack").GetComponent<generation> ().difficulty (Maxspawntime - 20, CarMoveSpeed + 0.05f, MaxCoinIngame, numberOfCar);

			} else if (score >= 100 && score < 400) {
		
				pattenr1 = new int []{ 3, 1, 0, 2, 0, 2, 3, 0, 1, 3, 2, 0, 3, 0, 2, 1 };//pattern for road1
				pattenr2 = new int []{ 7, 4, 6, 5, 6, 5, 4, 7, 6, 4, 5, 7, 6, 4, 5, 6 };//pattern for road1
				GameObject.Find ("generationtrack").GetComponent<generation> ().difficulty (Maxspawntime - 30, CarMoveSpeed + 0.05f, MaxCoinIngame, numberOfCar + 1);
		
				GameObject.Find ("generationtrack").GetComponent<generation> ().counterfornumberofCar = 0;
			}
			if (score >= 400 && score < 700) {

				//car2
				pattenr1 = new int []{ 2, 3, 0, 1, 0, 3, 1, 2, 3, 3, 2, 0, 2, 1, 2, 3, 2, 0 };//pattern for road1
				pattenr2 = new int []{ 4, 5, 6, 7, 4, 6, 5, 4, 7, 5, 6, 4, 5, 4, 7, 6, 4, 7 };//pattern for road1
				GameObject.Find ("generationtrack").GetComponent<generation> ().difficulty (Maxspawntime - 35, CarMoveSpeed + 0.05f, MaxCoinIngame, numberOfCar + 1);

				GameObject.Find ("generationtrack").GetComponent<generation> ().counterfornumberofCar = 0;
			}
			if (score >= 700) {

				//car3
				pattenr1 = new int []{ 0, 3, 1, 2, 0, 3, 1, 2, 0, 1, 3, 2, 0, 1, 3, 0, 3, 1, 2, 0, 1 };//pattern for road1
				pattenr2 = new int []{ 5, 7, 6, 6, 7, 5, 6, 4, 5, 5, 6, 4, 7, 4, 6, 6, 5, 7, 4, 6, 5 };//pattern for road1
				GameObject.Find ("generationtrack").GetComponent<generation> ().difficulty (Maxspawntime - 50, CarMoveSpeed + 0.1f, MaxCoinIngame, numberOfCar + 2);

				GameObject.Find ("generationtrack").GetComponent<generation> ().counterfornumberofCar = 0;
			}
			if (scorecheck.activeSelf == false) {
				GameObject.Find ("thief").GetComponent<autojump2> ().setScorepoints (scoreaddForKeypress, scoredecreaseforhit); //score setting 
			}
		} else {

			pattenr1 = new int []{ 0, 1, 2, 3, 0, 2, 1, 0, 2, 1, 3, 0, 3, 1, 2, 0 };//pattern for road1
			pattenr2 = new int []{ 4, 5, 6, 7, 7, 6, 5, 4, 7, 5, 6, 4, 5, 4, 7, 6 };//pattern for road1
			GameObject.Find ("generationtrack").GetComponent<generation> ().difficulty (Maxspawntime - 10, CarMoveSpeed, MaxCoinIngame, numberOfCar);

		}
	}

}
