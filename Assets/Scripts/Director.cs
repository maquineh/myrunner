using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    public Transform runner;

    private int score;

    void Start() {
        score = 0;
    }

	void Update () {
        if (runner.position.y <= -8.0f) {
            Resetar();
        }
	}

    void FixedUpdate() {
        score += (int)runner.rigidbody.velocity.x;
        if (score < 0) score = 0;
    }

    void Resetar() {
        runner.position = new Vector3(runner.position.x + 10.0f, 15, runner.position.z);
        score = 0;
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 100), "Score: " + score);
    }
}
