﻿using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    public Transform runner, chaser, plataformas;
	public GUIText gameOverText;
	public Canvas dialog;

	private Runner runnerScript;
    private Chaser chaserScript;
    private int score, tries;

    void Start() {
        score = 0;
		tries = 1;
		GameManagersEvent.runGameStart();

		gameOverText.enabled = false;
		dialog.enabled = false;

        runnerScript = runner.GetComponent<Runner>();
        chaserScript = chaser.GetComponent<Chaser>();
    }

	void Update() {
        if (runner.transform.position.y <= -8.0f) {
			tries--;
            ResetarRunner();
			if(tries<1){
				gameOver();
			}

        }
		if (chaser.transform.position.y <= -8.0f) {
            ResetarChaser();
        }
	}

    void FixedUpdate() {
        score += (int)runner.rigidbody.velocity.x;
        if (score < 0) score = 0;
    }

    void ResetarRunner() {
		runner.transform.position = new Vector3(runner.transform.position.x + 10.0f, 15, runner.transform.position.z);
    }

    void ResetarChaser() {
		chaser.transform.position = new Vector3(chaser.transform.position.x + 10.0f, 15, chaser.transform.position.z);
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 100), "Score: " + score);
		GUI.Label(new Rect(100, 10, 100, 100), "Tries: " + tries);
    }

	public void setScore(int resetScore){
		this.score = resetScore;
	}

	public void gameOver(){
		gameOverText.enabled = true;
		dialog.enabled = true;

        runner.gameObject.SetActive(false);
        chaser.gameObject.SetActive(false);
        runner.rigidbody.velocity = Vector3.zero;
        chaser.rigidbody.velocity = Vector3.zero;
	}

    public void ResetGame() {
        if (tries > 0) return;
        gameOverText.enabled = false;
        dialog.enabled = false;
        score = 0;
        tries = 3;
        runner.gameObject.SetActive(true);
        chaser.gameObject.SetActive(true);

        plataformas.GetComponent<PlataformaManager>().ResetarFase();
        runnerScript.reset();
        chaserScript.reset();
    }
}