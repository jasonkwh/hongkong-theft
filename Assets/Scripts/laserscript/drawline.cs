using UnityEngine;
using System.Collections;

public class drawline : MonoBehaviour {


	/*
	 * draw line
	 * 
	 */ 
	public LineRenderer lineRender;
	public Transform orign;
	public Transform distination;
	public Vector3 distinationchange;
	private int oncounter = 0;
	private int offcounter = 0;
	private int lasertimer = 50;
	int counter = 0;
	public GameObject boom ;
	GameObject carsIns;
	//public GameObject detector;


	// Use this for initialization
	void Start () {
	
		//detector= GameObject.Find("laser/point1/laserdetector");



	
	}
	
	// Update is called once per frame
	void Update () {

		if (counter == 100) {
			lineRender.SetWidth (0.1f, 0.1f);

			int pick = Random.Range (1,8);

			lineRender.SetPosition (0, orign.position);

			distinationchange = new Vector3(distination.position.x,distination.position.y,distination.position.z+pick);

			lineRender.SetPosition (1, distinationchange);



			carsIns = Instantiate (boom )as GameObject;// create car
			carsIns.transform.position = new Vector3 (orign.position.x,orign.position.y,orign.position.z);

			counter = 0;
		} else {
			counter++;
		}
	





	
	}


}
