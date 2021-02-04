using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMode : MonoBehaviour {

	[SerializeField]
	private LayoutNormalButtons layoutNormalButtons;

    [SerializeField]
    private LayoutLearningButtons layoutLearningButtons;
    
    [SerializeField]
	private GameObject selectNewMenuPanel, startMenuPanel, normalModePanel, learningModePanel;

	[SerializeField]
	private Animator selectNewMenuPanelAnimator, startMenuPanelAnimator, normalModePanelAnimator, learningModePanelAnimator;
    
    private string selectedNewMenu;
 

	public void SelectedStartMenu() {

		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		StartCoroutine (HideStartMenuPanel ());
	}

	IEnumerator HideStartMenuPanel() {

		selectNewMenuPanel.SetActive (true);
		selectNewMenuPanelAnimator.Play ("SlideIn");
		startMenuPanelAnimator.Play ("SlideOut");
		yield return new WaitForSeconds (.5f);
		startMenuPanel.SetActive (false);

	}
		
	public void SelectedNormalMode() {

		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        
		layoutNormalButtons.LayoutButtons();
      
        StartCoroutine (ShowNormalModePanel());
    }

	IEnumerator ShowNormalModePanel() {

		normalModePanel.SetActive (true);
		normalModePanelAnimator.Play ("SlideIn");
		startMenuPanelAnimator.Play ("SlideOut");
		yield return new WaitForSeconds (.5f);
		startMenuPanel.SetActive (false);

	}

	public void SelectedLearningMode() {

		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        layoutLearningButtons.LayoutButtons();
        StartCoroutine (ShowLearningModePanel());
        layoutLearningButtons.TurnOverCards();

    }

	IEnumerator ShowLearningModePanel() {

		learningModePanel.SetActive (true);
		learningModePanelAnimator.Play ("SlideIn");
		startMenuPanelAnimator.Play ("SlideOut");
		yield return new WaitForSeconds (.5f);
		startMenuPanel.SetActive (false);

	}


}
