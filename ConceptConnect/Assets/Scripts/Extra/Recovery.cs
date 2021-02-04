using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recovery : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
/*		
	}

	public void PickACard(){
		if (!firstGuess) {

			firstGuess = true;

			firstGuessIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			CardA.SetCard(gameButtonsAnimator[firstGuessIndex],
				gameButtons[firstGuessIndex],
				gameSprites[firstGuessIndex], BackImage);


		} else if (!secondGuess)
		{
			secondGuessIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			if (secondGuessIndex == firstGuessIndex)
				return;

			secondGuess = true;

			CardB.SetCard(gameButtonsAnimator[secondGuessIndex],
				gameButtons[secondGuessIndex],
				gameSprites[secondGuessIndex], BackImage
			);            
			CardB.TurnUp();
		}
	}

	public void SelectedStartMenu() {

		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		StartCoroutine (ShowStartMenuPanel ());
	}

	IEnumerator ShowStartMenuPanel() {

		startMenuPanel.SetActive (true);
		selectNewMenuPanelAnimator.Play ("SlideOut");
		startMenuPanelAnimator.Play ("SlideIn");
		yield return new WaitForSeconds (.5f);
		selectNewMenuPanel.SetActive (false);

	}

	public void LowNormalMode(){

		StartCoroutine (LowNormal ());
	}

	IEnumerator LowNormal(){

		if (bgMusicClip.volume == 0.1f) {
			bgMusicClip.volume = 0f;
			yield return new WaitForSeconds (7f);
			bgMusicClip.volume = 0.1f;
		}
	}

	public void LowLearningMode(){

		StartCoroutine (LowLearning ());
	}

	IEnumerator LowLearning(){

		if (bgMusicClip.volume == 0.1f) {
			bgMusicClip.volume = 0f;
			yield return new WaitForSeconds (9.5f);
			bgMusicClip.volume = 0.1f;
		}
	}
	*/
	}
}
