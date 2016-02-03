using UnityEngine;
using System.Collections;

public class walk : MonoBehaviour {
	/*
	 * 
	 * auto chase player
	 * and detect player
	 */ 
	private NavMeshAgent agent;
//	public GameObject gethim;
	private bool PlayerIsInRange ;
	// Use this for initialization
	void Start () {
		//agent = GetComponent<NavMeshAgent> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		PlayerIsInRange  = GameObject.Find("dog").GetComponent<InRange>().PlayerInRange;

		if (PlayerIsInRange == true) {

		Debug.Log("stop ! guard find player");
			//agent.SetDestination (gethim.transform.position);
		}
	}
}
