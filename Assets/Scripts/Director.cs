using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    public Transform runner;

    private int score;

    void Start() {
        score = 0;
    }

	void Update () {
        if (runner.position.y <= -5.0f) {
            Resetar();
        }
	}

    void FixedUpdate() {
        if (runner.position.y >= 0) score += (int)runner.rigidbody.velocity.x;
    }

    void Resetar() {
        runner.position = new Vector3(runner.position.x + 10.0f, 15, runner.position.z);
        runner.GetComponent<Runner>().caindo = false;
        score = 0;
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 100), "Score: " + score);
    }
}
