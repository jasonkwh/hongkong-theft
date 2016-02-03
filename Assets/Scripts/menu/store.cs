using UnityEngine;
using System.Collections;

public class store : MonoBehaviour {
	public GameObject MainMenu;
	// Use this for initialization
	public void ReturnToMenu (){
		this.gameObject.SetActive (false);
		MainMenu.SetActive (true);
		Debug.Log ("Menu");
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
