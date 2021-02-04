using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadLevel : MonoBehaviour {

	[SerializeField]
	private GameObject normalModePanel;

	[SerializeField]
	private SetUpNormalMode setUpNormalMode;
    [SerializeField]
    private LayoutNormalButtons layoutNormalButtons;
    [SerializeField]
    private LayoutLearningButtons layoutLearningButtons;

	private List<Animator> animators;
   

	public void RefreshNormalLevel() {

		animators = setUpNormalMode.ResetGameplay ();
		StartCoroutine (RefreshNormal ());

	}

	IEnumerator RefreshNormal(){


		foreach (Animator animator in animators) {
			animator.Play ("Idle");
		}
		yield return new WaitForSeconds (.1f);

		normalModePanel.SetActive (false);
		RefreshLayout ();
	}
		

	public void RefreshLayout (){

		layoutNormalButtons.LayoutButtons ();

		StartCoroutine (ReplayGame());
	}

	IEnumerator ReplayGame (){

		normalModePanel.SetActive (true);
		yield return new WaitForSeconds (.1f);

	}

    public void RefreshLearningLevel() {
        layoutLearningButtons.LayoutButtons();
     
    }
		
}