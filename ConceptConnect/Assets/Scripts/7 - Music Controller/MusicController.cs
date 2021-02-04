using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour {

	[SerializeField]
	private Sprite musicOff, musicOn;

	[SerializeField]
	private Button musicButtonMain, musicButtonScores, musicButtonAbout, musicButtonStart, musicButtonLearn, musicButtonNormal;

	private AudioSource bgMusicClip;
	 

	// Use this for initialization
	void Awake () {

		GetAudioSource ();

	}
	
	// Update is called once per frame
	void Start () {
		
	}

	void GetAudioSource(){
		bgMusicClip = GetComponent<AudioSource> ();
	}

	//When I click here
	public void PlayOrTurnOffMusic(){

		//then if music volume is 0.1
		if (bgMusicClip.volume == 0.1f) {
			bgMusicClip.volume = 0;
			musicButtonMain.image.sprite = musicOff;
			musicButtonScores.image.sprite = musicOff;
			musicButtonAbout.image.sprite = musicOff;
			musicButtonStart.image.sprite = musicOff;
			musicButtonLearn.image.sprite = musicOff;
			musicButtonNormal.image.sprite = musicOff;// set button image to off
		} else if (bgMusicClip.volume == 0) {
			bgMusicClip.volume = 0.1f;
			musicButtonMain.image.sprite = musicOn;
			musicButtonScores.image.sprite = musicOn;
			musicButtonAbout.image.sprite = musicOn;
			musicButtonStart.image.sprite = musicOn;
			musicButtonLearn.image.sprite = musicOn;
			musicButtonNormal.image.sprite = musicOn;
		}
	}

	//------------Margo 2--------
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

   //--------------Finish Margo 2-------
}
