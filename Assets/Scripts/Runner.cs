using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

    public static float distanciaPercorrida;
    public float aceleracao;
	public Vector3 velocidadePulo;
	public bool temPuloDuplo = false;

    private bool tocouPlataforma;

	void Update () {
		if(!tocouPlataforma && 
            (Input.GetButtonDown("Jump") || Input.touchCount > 0) && temPuloDuplo){
			rigidbody.AddForce(velocidadePulo, ForceMode.VelocityChange);
			temPuloDuplo = false;
		}
		transform.Translate (10f * Time.deltaTime, 0f, 0f);
		distanciaPercorrida = transform.localPosition.x;

		if (tocouPlataforma) {

			if(Input.GetButtonDown("Jump") || Input.touchCount > 0){
				rigidbody.AddForce(velocidadePulo, ForceMode.VelocityChange);
				temPuloDuplo = true;
				tocouPlataforma = false;
			}
		
		}


        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
	}

	void FixedUpdate () {
		if(tocouPlataforma){
			rigidbody.AddForce(aceleracao, 0f, 0f, ForceMode.Acceleration);
			tocouPlataforma=true;
		}
	}
	
	void OnCollisionEnter () {
		tocouPlataforma = true;
	}
	
	void OnCollisionExit () {
		tocouPlataforma = false;
	}
}
