using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    public Transform runner, chaser;

    private int score;

    void Start() {
        score = 0;
    }

	void Update () {
        if (runner.position.y <= -8.0f) {
            ResetarRunner();
        }

        if (chaser.position.y <= -8.0f) {
            ResetarChaser();
        }
	}

    void FixedUpdate() {
        score += (int)runner.rigidbody.velocity.x;
        if (score < 0) score = 0;
    }

    void ResetarRunner() {
        runner.position = new Vector3(runner.position.x + 10.0f, 15, runner.position.z);
        score = 0;
    }

    void ResetarChaser() {
        chaser.position = new Vector3(chaser.position.x + 10.0f, 15, chaser.position.z);
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 100), "Score: " + score);
    }
}
