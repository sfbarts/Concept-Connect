using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutLearningButtons : MonoBehaviour {

	[SerializeField]
	private SetUpLearningMode setUpLearningMode;

	[SerializeField]
	private Transform learningModeButtonsHolder;

	public List <Button> defaultButtons;
	public List <Animator> defaultAnimator;

    [SerializeField]
    private Sprite cardBacksideImages;


    private string selectedMode;

	public void LayoutButtons () { //call to level and puzzle variables in select level script

        setUpLearningMode.SetLevel ();
		LayoutGame(); // call Layout Game Function

	}
    public void TurnOverCards()
    {
        setUpLearningMode.TurnCardsOver();
    }
	void LayoutGame(){

		selectedMode = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

		//for each button in the buttons included in that level...
		foreach (Button btn in defaultButtons) {

			if (!btn.gameObject.activeInHierarchy) {// if the button is not active...

				btn.gameObject.SetActive (true);//activate it
				btn.gameObject.transform.SetParent (learningModeButtonsHolder, false);//set button holder as parent
                btn.image.sprite = cardBacksideImages;
            }

        }

        setUpLearningMode.SetPuzzleButtonsAndAnimators (defaultButtons, defaultAnimator);
	}
	//--------------------------------------------------------

}
