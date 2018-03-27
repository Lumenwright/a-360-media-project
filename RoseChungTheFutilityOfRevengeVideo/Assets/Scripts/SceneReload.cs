using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour {
	public string nameOfScene;

	public void SceneChanger(){
		SceneManager.LoadScene (nameOfScene);
	}
}
