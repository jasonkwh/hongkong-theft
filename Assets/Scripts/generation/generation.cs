using UnityEngine;
using System.Collections;

public class generation : MonoBehaviour {

	public GameObject beginnroad1;
	public GameObject beginnroad2;
	public GameObject midroad;
	public GameObject endroad1;
	public GameObject endroad2;
	public GameObject bus;//bus object
	public GameObject bus1;//bus object
	public GameObject bus2;//bus object
	public GameObject car;//car object
	public GameObject car1;//car object
	public GameObject car2;//car object
	public GameObject car3;//car object
	public GameObject car4;//car object
	public GameObject car5;//car object
	public GameObject car6;//car object
	public GameObject car7;//car object
	public GameObject player;// play object 
	public GameObject coin;
	public GameObject potionlife;//car object
	public GameObject potionSpeed;//car object
	public GameObject potionScore;// play object 
	public GameObject potionLarge;
	public GameObject potionlifer;//car object
	public GameObject potionSpeedr;//car object
	public GameObject potionScorer;// play object 
	public GameObject potionLarger;
	GameObject nameofobject ;// do we create car or bus
	Vector3 intpos = new Vector3(0,0,0);// road position
	Vector3 busintpos = new Vector3(0,0,0);// road position
	int timetrackforswitchpath = 0; // time count for changingpath;
	float [] busYvalue = new float [10]; // array to store 4 specific x positions to spawn objects
	int pickbusYvalue = 0; // value for array
	int pickbusYvalue2 = 0; // value for array
	int coinxvalue = -1; // value for array
	int spawncar = 150;//time gap counter for normal spawn
	int normalSpawngap =150;// the gap for spawn normal car  must bigger than 60 so that it does not overlap
	int pathchoosing = 0;// switching patching
	public int endroad = -1;//which part of spawn did we use? begin1? end1? begin2? end2? or midroad?
	bool spawndone = false;// make sure only spawn once per round..
	bool spawnend1done = false;//begin1 spawned
	bool spawnend2done = false;//begin2 spawned
	float speed = 0.1f ;// car spawn
	public int counterfornumberofCar = 0; // car counter
	int storeoldvaleforpickbusfirst = -1;// store value for first count;
	int storeoldvaleforpickbus2first = -1;// store value for sceond count;
	int storeoldvaleforpickbussecond = -1;
	int storeoldvaleforpickbus2second = -1;
	int pickobjectotspawn = 0;// do we create car or bus
	int spawncoin = 0;//time gap counter for normal spawn
	public int maxSpawncoincounter = 20 ;// the gap for spawn normal car  must bigger than 60 so that it does not overlap
	int coinsInGame = 0; // how many coins now;
	int totalCoins = 0;
	int maxcoinInGame = 1;
	int numberofcar = 1;
	int scores = 0;
	int [] pattenr1 ;
	int [] pattenr2;
	int counterForPatten = 0;
	bool change = false;
	int maxpotion = 1;
	int numberofpotion = 0;
	public int Maxtimerpotion  = 10;
	int scorecompare = 0 ;
	public GameObject rain ;
	public GameObject grates;


	public void changelevel ( bool changes){

		change = changes;

	}

	public void setMaxtimerforpotion ( int i){
		Maxtimerpotion  = i;

	}

	public void setMaxpotion ( int i){

		maxpotion = i;

	}


	public void setnumberofpotion ( int i){

		numberofpotion -= i;

	}
	public void addcoin ( int coins){

		totalCoins += coins;

	}

	public void changecoins ( int coins){
		
		coinsInGame -= coins;

	}

	public int getcoins (){

		return totalCoins ;

	}
	public float speedvalue {
		get {return speed; }

	}
		

	void Start (){
		
		speed = 0.1f;									
		/// nomralspecfic x value ;//0.5
		busYvalue [0] = -9.5f;
		busYvalue [1] = -7f	;
		busYvalue [2] = -4.5f;
		busYvalue [3] = -2;
		busYvalue [4] = 11.2f;
		busYvalue [5] = 8.71f;
		busYvalue [6] = 6.24f;
		busYvalue [7] = 3.54f;
	

	
	

	} 
		
	void OnTriggerExit(Collider other) {
		
		/**
		 * if trackgeneration exit an island then create another island for player
		 * 
		 **/
		if (other.gameObject.name == "environ_multiple"  || other.gameObject.name == "environ_multiple(Clone)"|| other.gameObject.name == "environ_single_01(Clone)"|| other.gameObject.name == "environ_single_01"|| other.gameObject.name == "environ_end_02(Clone)"||other.gameObject.name == "environ_end_01(Clone)"|| other.gameObject.name == "environ_single_01(Clone)"|| other.gameObject.name == "environ_single_02(Clone)") {
			spawndone = false;
			if (timetrackforswitchpath == 3) {

				if (endroad == -1) {
					endroad = 0;
					pathchoosing = 1;
				}
				if (endroad == 1) {
					endroad = -1;
					spawnend1done = false;
					spawnend2done = false;
				}
	
				timetrackforswitchpath = 0;
			}	
		
				//intpos = new Vector3 (0, -1, this.gameObject.transform.position.z);//set position for road marterial
			intpos = new Vector3 (0, 0, this.gameObject.transform.position.z);//set position for road marterial

			if(pathchoosing == 0 && spawndone == false && endroad == -1) {

			GameObject  roadIns = Instantiate (midroad)as GameObject;// create road
			roadIns.transform.position = intpos;// set it position
			spawndone = true;
			timetrackforswitchpath += 1;
			
			}

			if(pathchoosing == 0 && spawndone == false && endroad == 1) {


				if( spawnend1done == true ) {
					GameObject roaddvisionIns = Instantiate (beginnroad1)as GameObject;// create road
					roaddvisionIns.transform.position = intpos;// set it position
					spawndone = true;
					//spawnend1done = false;
					//spawnend2done = false;
				} else {
					GameObject roaddvisionIns2 = Instantiate (beginnroad2)as GameObject;// create road
					roaddvisionIns2.transform.position = intpos;// set it position
					spawndone = true;
					//spawnend1done = false;
					//spawnend2done = false;
				}
				timetrackforswitchpath += 1;
				//endroad = -1;

			}

		

			if(pathchoosing == 1 && spawndone == false && endroad == 0) {
				int i = Random.Range (0, 2);
				timetrackforswitchpath = 0;
				if (i == 0) {
					GameObject roaddvisionIns = Instantiate (endroad1)as GameObject;// create road
					roaddvisionIns.transform.position = intpos;// set it position
					spawndone = true;
					spawnend1done = true;
					spawnend2done = false;
				} else {
					GameObject roaddvisionIns2 = Instantiate (endroad2)as GameObject;// create road
					roaddvisionIns2.transform.position = intpos;// set it position
					spawndone = true;
					spawnend1done = false;
					spawnend2done = true;
				}
				pathchoosing = 0;
				endroad = 1;
				timetrackforswitchpath = 0;

			}
	
		}
	}

	void Update () {
		if(player.activeSelf == true){
		scorecompare = GameObject.Find ("thief").GetComponent<autojump2> ().getscores(); // total score
		}
		if (scorecompare > Maxtimerpotion && numberofpotion < maxpotion && player.activeSelf == true) {
			int picktypes = Random.Range (0, 4);
			switch (picktypes) {
			case 0:
				nameofobject = potionlifer;//car object
				break;
			case 1:
				nameofobject = potionSpeedr;
			
				break;
			case 2:
				nameofobject = potionScorer;
				break;
			case 3:
				nameofobject = potionLarger;
				break;

			}

			coinxvalue = Random.Range (0, 8);
			busintpos = new Vector3 (player.transform.position.x, 0.8f, player.transform.position.z +30);// spawn in front of player
			GameObject carsIns = Instantiate (nameofobject )as GameObject;// create car
			carsIns.transform.position = busintpos;	
			numberofpotion++;
			Maxtimerpotion += 40;
			
		}


		if (scorecompare > maxSpawncoincounter && coinsInGame < maxcoinInGame && player.activeSelf == true ) {


				coinxvalue = Random.Range (0, 8);
				busintpos = new Vector3 (busYvalue [coinxvalue], 0.8f, this.gameObject.transform.position.z);// spawn in front of player
				GameObject carsIns = Instantiate (coin)as GameObject;// create car
				carsIns.transform.position = busintpos;	
				spawncoin = 0;
				coinsInGame += 1; 
				maxSpawncoincounter += 60;
				Debug.Log(maxSpawncoincounter);
			if (GameObject.Find ("FloorDrain(Clone)")== null) {
				busintpos = new Vector3 (player.transform.position.x, 1f, this.gameObject.transform.position.z + 7);// spawn in front of player
				GameObject gratesins = Instantiate (grates)as GameObject;// create car
				gratesins.transform.position = busintpos;

			}

		}

	
		/**
		 * create car and bus
		 * 
		 **/

			if (spawncar == normalSpawngap) {			
				int positionofcarz;
				pattenr1 = GameObject.Find ("generationtrack").GetComponent<difficultySetting > ().pattern1 ();
				pattenr2 = GameObject.Find ("generationtrack").GetComponent<difficultySetting > ().pattern2 ();
		


				for (counterfornumberofCar = 0; counterfornumberofCar < numberofcar; counterfornumberofCar++) {
					pickobjectotspawn = Random.Range (0, 2);
					if (pickobjectotspawn == 0) {
						int picktype = Random.Range (0, 8);
						switch (picktype) {
						case 0:
							nameofobject = car;
							break;
						case 1:
							nameofobject = car1;
							break;
						case 2:
							nameofobject = car2;
							break;
						case 3:
							nameofobject = car3;
							break;
						case 4:
							nameofobject = car4;
							break;
						case 5:
							nameofobject = car5;
							break;
						case 6:
							nameofobject = car6;
							break;
						case 7:
							nameofobject = car7;
							break;
						}
					} else {
						int picktype = Random.Range (0, 3);
						switch (picktype) {
						case 0:
							nameofobject = bus;
							break;
						case 1:
							nameofobject = bus1;
							break;
						case 2:
							nameofobject = bus2;
							break;
						}
					
					}

			
					positionofcarz = Random.Range (5, 8);// random postion
					busintpos = new Vector3 (busYvalue [pattenr1 [counterForPatten]], 0, this.gameObject.transform.position.z - positionofcarz);// spawn in front of player
					GameObject carsIns = Instantiate (nameofobject)as GameObject;// create car
					carsIns.transform.position = busintpos;	
					busintpos = new Vector3 (busYvalue [pattenr2 [counterForPatten]], 0, this.gameObject.transform.position.z - positionofcarz);// spawn in front of player
					GameObject carsIns2 = Instantiate (nameofobject)as GameObject;// create car
					carsIns2.transform.position = busintpos;

					if (counterForPatten < pattenr1.Length - 1) {
						counterForPatten++;
					} else {
						counterForPatten = 0;
					}

				}

				spawncar = 0;

			} else {

				spawncar++;
			}

	
	}


		
	public void difficulty (int tnormalSpawngap , float tspeed , int tmaxcoinInGame ,int tnumberofcar ){

			this.numberofcar = tnumberofcar;

			this.normalSpawngap =  tnormalSpawngap; // car spawn gap
	
			this.speed = tspeed; // car speed 

			this.maxcoinInGame = tmaxcoinInGame;// max coin in game


		if (rain.activeSelf == true) {
			this.speed = 0.05f;
		}


	}

}

