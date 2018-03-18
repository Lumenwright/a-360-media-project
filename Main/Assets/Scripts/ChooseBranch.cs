using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBranch : MonoBehaviour {

	public GameObject chooseSphereCry;
	public GameObject chooseSphereHowl;
	public GameObject branchtext;

	public ParticleSystem ash;
	public ParticleSystem snow;
	public ParticleSystem rain;

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
	public void MakeParticleAppear (bool chooseBranch){
		if (chooseBranch) {
			StartCoroutine (ParticleAppear (cryWaitTime, rain));
		}

		if (chooseBranch == false) {
			StartCoroutine (ParticleAppear (howlWaitTime, snow));
		}
	}

	IEnumerator ParticleAppear (float when, ParticleSystem ps){
		yield return new WaitForSecondsRealtime(when);
		ps.Play ();
	}
}
