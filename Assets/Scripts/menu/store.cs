using UnityEngine;
using System.Collections;

public class store : Menu {

	// Use this for initialization
	public void ReturnToMenu (){
		
		shop.SetActive (false);
		Menu.SetActive (true);
		Debug.Log ("Return To Menu");

	}


	public void buyItemSpeedPotion (){

		Debug.Log ("Speed");
	}

	public void buyItemInvulnerablePotion (){

		Debug.Log ("Red");
	}

	public void buyItemScorePotion (){

		Debug.Log ("Score");
	}
	public void buyItemSlowPotion (){

		Debug.Log ("Slow");
	}
}
