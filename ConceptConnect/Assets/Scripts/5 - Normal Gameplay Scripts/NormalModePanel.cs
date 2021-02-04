using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalModePanel : MonoBehaviour {

	[SerializeField]
	private GameObject selectNewMenuPanel, startMenuPanel, normalModePanel, gameFinishedPanel, scoreMenuPanel;

	[SerializeField]
	private Animator selectNewMenuPanelAnimator, startMenuPanelAnimator, normalModePanelAnimator, gameFinishedAnimator, scoreMenuAnimator;

    [SerializeField]
    ViewScores viewScores;

    [SerializeField]
    SetUpNormalMode setUpNormalMode;

	[SerializeField]
	private CreateNormalButtonsAndAnimations create;

	[SerializeField]
	private LayoutNormalButtons layoutNormalButtons;
    
    private string selectedNewMenu;

	private List<Animator> animators;

	public Text timerText;
    public Text scoreText;
    public Text Name;
    string minutes;
    string seconds;
    public bool counting = false;
    
    public float t = 0;
  
    //Resets Time
    void OnEnable () {
        t = 0;
      
    }
   

	void Update() {
		 
        if (counting) {
			
			t += Time.deltaTime;

            minutes = ((int)t / 59).ToString();

            seconds = (t % 59).ToString("00");

            timerText.text = minutes + " : " + seconds;
        }

	}


	public void SelectedHomePanel () {
		
        counting = false;
        
        selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
       
		StartCoroutine (HideNormalModePanel());
	}

	IEnumerator HideNormalModePanel () {

		selectNewMenuPanel.SetActive (true);
		selectNewMenuPanelAnimator.Play ("SlideIn");
		normalModePanelAnimator.Play ("SlideOut");
		yield return new WaitForSeconds (.5f);
		normalModePanel.SetActive (false);

	}

	public void SelectedBackButton () {
        counting = false;
		animators = setUpNormalMode.ResetGameplay ();
        selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		StartCoroutine (backToStartMenuPanel());
	}

	IEnumerator backToStartMenuPanel () {


		startMenuPanel.SetActive (true);
		startMenuPanelAnimator.Play ("SlideIn");
		normalModePanelAnimator.Play ("SlideOut");
		yield return new WaitForSeconds (1f);
		foreach (Animator animator in animators) {
			animator.Play ("Idle");
		}
		yield return new WaitForSeconds (.5f);
		normalModePanel.SetActive (false);

	}

	//When all the pairs are found
	public void GameFinished() {
		
		counting = false;
		animators = setUpNormalMode.ResetGameplay ();
		scoreText.text = minutes + " : " + seconds;
		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		StartCoroutine(GameFinishedPanel());
	}

    IEnumerator GameFinishedPanel() {
        
        gameFinishedPanel.SetActive(true);
        gameFinishedAnimator.Play("SlideIn");
        normalModePanelAnimator.Play("SlideOut");
		foreach (Animator animator in animators) {
			animator.Play ("Idle");
		}
        yield return new WaitForSeconds(.1f);
		normalModePanel.SetActive(false);

    }

  
    public void SelectedScoresMenu() {

        selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        StartCoroutine(ShowScoresMenuPanel());
    }

    IEnumerator ShowScoresMenuPanel() {
		
        //For some reason the home and exit buttons were having their alphas set to 0 and unclickable
        scoreMenuPanel.GetComponent<CanvasGroup>().alpha = 1;
        scoreMenuPanel.GetComponent<CanvasGroup>().interactable = true;

        scoreMenuPanel.SetActive(true);
        scoreMenuAnimator.Play("SlideIn");
        viewScores.NewScore(Name.text + "      " + scoreText.text, t);
        yield return new WaitForSeconds(.5f);
        gameFinishedPanel.SetActive(false);
    }

	public void Replay() {
	
		selectedNewMenu = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		layoutNormalButtons.LayoutButtons ();
		StartCoroutine (ReplayGame());

	}

	IEnumerator ReplayGame() {
		
		normalModePanel.SetActive (true);
		normalModePanelAnimator.Play ("SlideIn");
		gameFinishedAnimator.Play ("SlideOut");
		yield return new WaitForSeconds (.5f);
		gameFinishedPanel.SetActive (false);
		viewScores.NewScore(Name.text + "      " + scoreText.text, t);

	}
}
