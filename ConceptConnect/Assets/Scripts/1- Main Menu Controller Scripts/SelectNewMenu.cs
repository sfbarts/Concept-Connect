using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNewMenu : MonoBehaviour {

	[SerializeField]
	private GameObject selectNewMenuPanel, startMenuPanel, scoresMenuPanel, aboutPanel, exitPanel;

	[SerializeField]
	private Animator selectNewMenuPanelAnimator, startMenuPanelAnimator, scoresMenuPanelAnimator, aboutPanelAnimator, exitPanelAnimator;

	private string selectedNewMenu;

	//----------------------Margo 1---------------------
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
	//--------------------Finish Margo 1-----------------------

	public void SelectedScoresMenu() {

		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		StartCoroutine (ShowScoresMenuPanel ());
	}

	IEnumerator ShowScoresMenuPanel() {

		scoresMenuPanel.SetActive (true);
		selectNewMenuPanelAnimator.Play ("SlideOut");
		scoresMenuPanelAnimator.Play ("SlideIn");
		yield return new WaitForSeconds (.5f);
		selectNewMenuPanel.SetActive (false);

	}

	public void SelectedAboutMenu(){

		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		StartCoroutine (ShowAboutMenuPanel());
	}

	IEnumerator ShowAboutMenuPanel() {

		aboutPanel.SetActive (true);
		selectNewMenuPanelAnimator.Play ("SlideOut");
		aboutPanelAnimator.Play ("SlideIn");
		yield return new WaitForSeconds (.5f);
		selectNewMenuPanel.SetActive (false);

	}

	public void SelectedExit() {

		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		StartCoroutine (ShowExitPanel ());
	}

	IEnumerator ShowExitPanel() {

		exitPanel.SetActive (true);
		exitPanelAnimator.Play ("SlideIn");
		yield return new WaitForSeconds (.5f);

	}

	public void SelectedNo() {

		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		StartCoroutine (HideExitPanel ());
	}

	IEnumerator HideExitPanel() {

		exitPanel.SetActive (false);
		exitPanelAnimator.Play ("SlideOut");
		yield return new WaitForSeconds (.5f);

	}

	public void ExitYes() {

		Application.Quit ();
	}

}
