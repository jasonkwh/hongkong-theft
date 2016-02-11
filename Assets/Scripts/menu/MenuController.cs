using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	public GameObject Menu;
	public GameObject shop;
	public GameObject player;
	static bool  startSetActive = false;

	public void Awake (){
		Menu = GameObject.Find ("menu");
		shop = GameObject.Find ("shop");
		player = GameObject.Find ("thief");

	}

	private void Start () {

		Debug.Log (startSetActive);
		if (startSetActive == false) {

			shop.SetActive (false);

			player.SetActive (false);

			startSetActive = true;
		}


			
	}




	// Use this for initialization

	

	public bool ReturnPlayerStatus(){

	

			return player.activeSelf;
		}



}
