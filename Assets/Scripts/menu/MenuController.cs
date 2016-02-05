using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	public GameObject Menu;
	public GameObject shop;
	public GameObject player;

	public void Awake (){
		Menu = GameObject.Find ("menu");
		shop = GameObject.Find ("shop");
		player = GameObject.Find ("thief");

	}
	public void Start (){
		
		player.SetActive (false);
		shop.SetActive (false);

	}

	// Use this for initialization

	

	public bool ReturnPlayerStatus(){

		return player.activeSelf;

	}

}
