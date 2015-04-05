using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadGame(){
		Application.LoadLevel("mainScene");
	}
	
	public void loadHowTo(){
		Application.LoadLevel("howToScene");
	}

	public void loadTitle(){
		Application.LoadLevel("titleScene");
	}

	public void quit(){
		Application.Quit();
	}

}
