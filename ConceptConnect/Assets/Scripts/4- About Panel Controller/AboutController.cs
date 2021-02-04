using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutController : MonoBehaviour {

	[SerializeField]
	private GameObject selectNewMenuPanel, aboutPanel;

	[SerializeField]
	private Animator selectNewMenuPanelAnimator, aboutPanelAnimator;

	private string selectedNewMenu;

	public void SelectedAboutMenu() {

		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;


		StartCoroutine (HideAboutMenuPanel());
	}

	IEnumerator HideAboutMenuPanel() {

		selectNewMenuPanel.SetActive (true);
		selectNewMenuPanelAnimator.Play ("SlideIn");
		aboutPanelAnimator.Play ("SlideOut");
		yield return new WaitForSeconds (.5f);
		aboutPanel.SetActive (false);

	}

}
