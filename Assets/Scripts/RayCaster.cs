using UnityEngine;
using System.Collections;

public class RayCaster : MonoBehaviour {

	public GameObject runner;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		runner = GameObject.FindGameObjectWithTag("Runner");
		Vector3 forward = runner.transform.TransformDirection (Vector3.forward);

		Debug.DrawRay (runner.transform.position, forward * 10, Color.red);

		if (Physics.Raycast (runner.transform.position, forward, 15)) {
			Debug.Log("Acertou Algo....");
		}

	}
}
