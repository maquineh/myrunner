using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	public static float distanciaPercorrida;
	// Use this for initialization

	public float aceleracao;
	
	private bool tocouPlataforma;

	public Vector3 velocidadePulo;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(tocouPlataforma && Input.GetButtonDown("Jump")){
			rigidbody.AddForce(velocidadePulo, ForceMode.VelocityChange);
			tocouPlataforma = false;
		}
		transform.Translate (10f * Time.deltaTime, 0f, 0f);
		distanciaPercorrida = transform.localPosition.x;
	}

	void FixedUpdate () {
		if(tocouPlataforma){
			rigidbody.AddForce(aceleracao, 0f, 0f, ForceMode.Acceleration);
		}
	}
	
	void OnCollisionEnter () {
		tocouPlataforma = true;
	}
	
	void OnCollisionExit () {
		tocouPlataforma = false;
	}
}
