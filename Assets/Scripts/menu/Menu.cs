using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Menu : MenuController {



	public void StartGame (){
		
		player.SetActive(true);
		Debug.Log ("Start Game");
		Menu.SetActive (false);

	}

	public void ShopMenu (){
		
		shop.SetActive (true);
		Menu.SetActive (false);
		Debug.Log (shop.activeSelf);
		Debug.Log ("Shop Open");

	}




}
