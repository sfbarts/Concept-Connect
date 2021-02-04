using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLearningButtonsAndAnimations : MonoBehaviour {

	[SerializeField]
	private LayoutLearningButtons layoutLearningButtons;

	[SerializeField]
	private Button gameButton;

	private int gameDefault = 24;

	private List<Button> defaultButtons = new List<Button> ();

	private List<Animator> defaultAnimator = new List<Animator> ();

	void Awake () {

		createButtons ();
		getAnimators ();

	}

	void Start () {
		AssignButtonsAndAnimators ();
	}

	void AssignButtonsAndAnimators (){

		layoutLearningButtons.defaultButtons = defaultButtons;

		layoutLearningButtons.defaultAnimator = defaultAnimator;


	}

	void createButtons() {

		for (int i = 0; i < gameDefault; i++) {

			Button btn = Instantiate (gameButton); //Instantiates the button
			btn.gameObject.name = "" + i; //name game objects from 0 until reach
			defaultButtons.Add (btn); //adds a list of buttons declared for puzzle 1
		}

	}

	// 2. function to get animators
	void getAnimators() {

		for (int i = 0; i < defaultButtons.Count; i++) {

			defaultAnimator.Add (defaultButtons[i].gameObject.GetComponent<Animator>()); //add animators to the buttons
			defaultButtons [i].gameObject.SetActive (false); //set buttons to inactive
		}

	}
}

