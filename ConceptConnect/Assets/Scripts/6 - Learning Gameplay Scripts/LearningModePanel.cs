using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LearningModePanel : MonoBehaviour {

	[SerializeField]
	private GameObject selectNewMenuPanel, startMenuPanel, learningModePanel;

	[SerializeField]
	private Animator selectNewMenuPanelAnimator, startMenuPanelAnimator, learningModePanelAnimator;

	private string selectedNewMenu;

	public void SelectedHomePanel () {

		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

		StartCoroutine (HideNormalModePanel());
	}

	IEnumerator HideNormalModePanel () {

		selectNewMenuPanel.SetActive (true);
		selectNewMenuPanelAnimator.Play ("SlideIn");
		learningModePanelAnimator.Play ("SlideOut");
		yield return new WaitForSeconds (.5f);
		learningModePanel.SetActive (false);

	}

	public void SelectedBackButton () {

		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

		StartCoroutine (backToStartMenuPanel());
	}

	IEnumerator backToStartMenuPanel () {

		startMenuPanel.SetActive (true);
		startMenuPanelAnimator.Play ("SlideIn");
		learningModePanelAnimator.Play ("SlideOut");
		yield return new WaitForSeconds (.5f);
		learningModePanel.SetActive (false);

	}
}
