using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Menu : MonoBehaviour {
	bool startPressed = false;
	bool finish = false;
	bool shopItem = false;
	public GameObject player;
	public GameObject Shop;
	public Text disable;


	public bool shopKeyStatus (){

		return shopItem;
	}

	public bool shopKeyStatus ( bool i){

		return shopItem;
	}
	// Use this for initialization

	public bool Getstart(){
		return startPressed;
	}

	public void begin (){
		startPressed = true;
		player.SetActive(true);
		Debug.Log ("start");	
	}

	public void shopKey (){
		shopItem = true;
		Shop.SetActive (true);
		gameObject.SetActive (false);
		Debug.Log ("Store");
	}



	void Update (){
		if (shopItem == false && finish == false) {
			Shop.SetActive (false);
			finish = true;
		}

		if (startPressed == true) {
			this.gameObject.SetActive (false);

		}


	}


}
