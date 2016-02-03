using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class characterSelection : MonoBehaviour {
	/*
	 * select character and store their selection
	 * go to next level
	 */ 
	public Image right;// character  at the right side
	public Image middle;// character  at the middle 
	public Image left;//character  at the left side
	public Image selection;//selection square to show which character player selecting
	private float selectionPositionX;// position x of the  image selectopm
	private int pressed = 0;// key press status 0 is not press 1 is pressed
	private int character = 0;// store which character did player select

	// Use this for initialization
	void Start () {

		selectionPositionX	= selection.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		//right
		if (selectionPositionX == right.transform.position.x && pressed == 0) {

			if (Input.GetKey ("left")) {
			
				selectionPositionX = middle.transform.position.x;
				character  = 1;
				selection.transform.position = new Vector3 (middle.transform.position.x, middle.transform.position.y, 0);
				pressed = 1;
			}
			if (Input.GetKey ("right")) {
			
				selectionPositionX = left.transform.position.x;
				character  = 2;
				selection.transform.position = new Vector3 (left.transform.position.x, left.transform.position.y, 0);
				pressed = 1;
			}
		} else
		// middle
		if (selectionPositionX == middle.transform.position.x && pressed == 0) {
			if (Input.GetKey ("left")) {
				character  = 2;
				selectionPositionX = left.transform.position.x;
				selection.transform.position = new Vector3 (left.transform.position.x, left.transform.position.y, 0);
				pressed = 1;
			}
			if (Input.GetKey ("right")) {
				character  = 0;
				selectionPositionX = right.transform.position.x;
				selection.transform.position = new Vector3 (right.transform.position.x, right.transform.position.y, 0);
				pressed = 1;
			}
		} else
		//left
		if (selectionPositionX == left.transform.position.x && pressed == 0) {
			if (Input.GetKey ("right")) {
				character  = 1;
				selectionPositionX = middle.transform.position.x;
				selection.transform.position = new Vector3 (middle.transform.position.x, middle.transform.position.y, 0);
				pressed = 1;
			}
			if (Input.GetKey ("left")) {
				character  = 0;
				selectionPositionX = right.transform.position.x;
				selection.transform.position = new Vector3 (right.transform.position.x, right.transform.position.y, 0);
				pressed = 1;
			}
		} else if (Input.GetKeyUp ("left") || Input.GetKeyUp ("right")) {                                                            
			
			pressed = 0;
			
		} 
		// enter to select
		if (Input.GetKeyDown("space")) {
			PlayerPrefs.SetInt("Character",character );
			Application.LoadLevel("shot");

		}
	}
}
