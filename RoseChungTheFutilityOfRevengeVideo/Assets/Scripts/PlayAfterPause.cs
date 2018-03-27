using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAfterPause : MonoBehaviour {

	public ChooseBranch cb;
	public GameObject mainAudio;
	public GameObject cryAudio;
	public GameObject howlAudio;
	public GvrAudioSource[] audio;

	// the first three audio sources are Main
	// the second three are Cry
	// the third two are Howl

	public void PlayWhichAudio (){
		cb.paused = false;

		Debug.Log (cb.whichBranch);

		if (cb.whichBranch == "main") {
			
			mainAudio.SetActive (true);
			audio [0].Play ();
			audio [1].Play ();
			audio [2].Play ();

			if (cb.waiting == false) {
				cb.ash.Play ();
			}
		}

		if (cb.whichBranch == "cry") {
			
			cryAudio.SetActive (true);
			audio [3].Play ();
			audio [4].Play ();
			audio [5].Play ();

			if (cb.waiting == false) {
				cb.rain.Play ();
			}
		}

		if (cb.whichBranch == "howl") {

			howlAudio.SetActive (true);
			audio [6].Play ();
			audio [7].Play ();

			if (cb.waiting == false) {
				cb.snow.Play ();
			}
		}
	}
}
