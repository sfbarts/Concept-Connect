using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNormalButtonsAndAnimations : MonoBehaviour {

	[SerializeField]
	private LayoutNormalButtons layoutNormalButtons;

	[SerializeField]
	private Button gameButton;

	private int gameDefault = 24;

	private List<Button> defaultButtons = new List<Button> ();

	private List<Animator> defaultAnimator = new List<Animator> ();

	public void Awake() {
		
	createButtons ();
	getAnimators ();

	}
 
	public void Start() {

        AssignButtonsAndAnimators ();

    }

    public void AssignButtonsAndAnimators() {

		layoutNormalButtons.defaultButtons = defaultButtons;
		layoutNormalButtons.defaultAnimator = defaultAnimator;

	}

	void createButtons() {

		for (int i = 0; i < gameDefault; i++) {

			Button btn = Instantiate (gameButton);
			btn.gameObject.name = "" + i; 
			defaultButtons.Add (btn);
		}
			
	}
		
	 void getAnimators() {

		for (int i = 0; i < defaultButtons.Count; i++) {

			defaultAnimator.Add (defaultButtons[i].gameObject.GetComponent<Animator>()); //add animators to the buttons
			defaultButtons [i].gameObject.SetActive (false); //set buttons to inactive
		}
			
	}
}
