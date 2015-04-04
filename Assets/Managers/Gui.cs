using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

	public GUIText GameOverText;
	public Canvas dialog;

	// Use this for initialization
	void Start () {
		GameOverText.enabled = false;
		GameManagersEvent.StartGame += StartGame;
		GameManagersEvent.GameOver += GameOver;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) {
			GameManagersEvent.runGameStart();
		}
	}

	private void StartGame () {
		GameOverText.enabled = false;
		enabled = false;
		dialog.enabled = false;
	}

	private void GameOver () {
		GameOverText.enabled = true;
		dialog.enabled = true;
		enabled = true;
	}
}
