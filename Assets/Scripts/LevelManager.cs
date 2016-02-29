using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Load game scene
	public void LoadLevel(string name) {
		Brick.breakableCount = 0;
		Application.LoadLevel(name);
	}
	
	public void QuitRequest() {
		Debug.Log("Quit requested Requested");
		Application.Quit();
	}
	
	public void LoadNextLevel() {
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
}
