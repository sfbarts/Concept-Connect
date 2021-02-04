using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ViewScores : MonoBehaviour {

	[SerializeField]
	private GameObject selectNewMenuPanel, scoresMenuPanel;

	[SerializeField]
	private Animator selectNewMenuPanelAnimator, scoresMenuPanelAnimator;

	private string selectedNewMenu;

    public Text[] Scores;
    public float[] Times;
    bool sort = false;

	public void SelectedScoresMenu() {

		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		StartCoroutine (HideScoresMenuPanel ());
	}

	IEnumerator HideScoresMenuPanel() {

		selectNewMenuPanel.SetActive (true);
		selectNewMenuPanelAnimator.Play ("SlideIn");
		scoresMenuPanelAnimator.Play ("SlideOut");
		yield return new WaitForSeconds (.5f);
		scoresMenuPanel.SetActive (false);

	}

    public void NewScore(string newScore, float time) {
        
		for (int i =0;i< Times.Length; i++) {
			
            if (time < Times[i] && !sort) {
				
                Times[Times.Length-1] = time;

                for (int j = 0; j < Scores.Length - i-1; j++) {
					
                    Scores[Scores.Length -j-1].text = Scores[Scores.Length - j-2].text;
                   
                }

                Scores[i].text = newScore;
                sort = true;
            }
        }
        Array.Sort(Times);
        sort = false;
   }
}
