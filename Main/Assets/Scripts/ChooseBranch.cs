﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBranch : MonoBehaviour {

	public GameObject chooseSphereCry;
	public GameObject chooseSphereHowl;
	public GameObject branchtext;

	public ParticleSystem ash;
	public ParticleSystem snow;
	public ParticleSystem rain;

	public string whichBranch = "main";

	public bool paused = false;
	public bool waiting = true; // waiting for particle to appear at right time

	float mainWaitTime = 20f;
	float cryWaitTime = 5f;
	float howlWaitTime = 5f;

	// Use this for initialization
	// timing for main branch
	void Start () {
		StartCoroutine (SphereAppear (mainWaitTime + 4f));
		StartCoroutine (ParticleAppear (mainWaitTime, ash));
	}

	// after when seconds, branch choices appear
	IEnumerator SphereAppear (float when) {
		yield return new WaitForSecondsRealtime(when);
		chooseSphereCry.SetActive (true);
		chooseSphereHowl.SetActive (true);
		branchtext.SetActive (true);
	}

	// when sphere is clicked, will set true for cry branch and false for howl
	// and set timing for particles of the branch to appear
	public void MakeParticleAppear (string chooseBranch){
		if (chooseBranch == "cry") {
			Debug.Log ("Starting particle coroutine");
			StartCoroutine (ParticleAppear (cryWaitTime, rain));
		}

		if (chooseBranch == "howl") {
			Debug.Log ("Starting particle coroutine");
			StartCoroutine (ParticleAppear (howlWaitTime, snow));
		}

		whichBranch = chooseBranch; // for play function to work after pause
	}

	IEnumerator ParticleAppear (float when, ParticleSystem ps){
		waiting = true;

		// wait additional time if video was paused before particles appeared
		float timepassed = 0;
		while (paused) {
			timepassed = timepassed + 0.2f;
			yield return new WaitForSeconds(0.2f); // wait a short length of time and then check if unpaused
		}

		yield return new WaitForSecondsRealtime (when);

		Debug.Log ("Time while paused: "+timepassed);
		yield return new WaitForSeconds (timepassed);

		waiting = false;
		ps.Play ();
	}

	public void Paused(){
		paused = true;
	}
}
