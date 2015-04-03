using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    public Transform runner, chaser;

    private int score, tries;

    void Start() {
        score = 0;
		tries = 3;
		GameManagersEvent.runGameStart();
    }

	void Update () {
        if (runner.position.y <= -8.0f) {
			tries--;
            ResetarRunner();

			if(tries<1){
				GameManagersEvent.runGameOver();
			}

        }

        if (chaser.position.y <= -4.0f) {
            ResetarChaser();
        }
	}

    void FixedUpdate() {
        score += (int)runner.rigidbody.velocity.x;
        if (score < 0) score = 0;
    }

    void ResetarRunner() {
        runner.position = new Vector3(runner.position.x + 10.0f, 15, runner.position.z);
    }

    void ResetarChaser() {
        chaser.position = new Vector3(chaser.position.x + 10.0f, 15, chaser.position.z);
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 100), "Score: " + score);
		GUI.Label(new Rect(100, 10, 100, 100), "Tries: " + tries);
    }

	public void setScore(int resetScore){
		this.score = resetScore;
	}
}
