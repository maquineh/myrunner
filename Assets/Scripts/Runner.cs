using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

    public static float distanciaPercorrida;
    public float aceleracao;
	public Vector3 velocidadePulo;
	public bool temPuloDuplo = false;

	private GameObject runner;
    
    private Transform groundCheck;
    private bool tocouPlataforma;

	private RaycastHit hitInfo;

    void Awake() {
        groundCheck = transform.FindChild("GroundCheck");
    }

	void Update () {
		distanciaPercorrida = transform.localPosition.x;

        if (!tocouPlataforma && rigidbody.position.x <= 0) {
            rigidbody.velocity = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
	}

	void FixedUpdate () {
        tocouPlataforma = Physics.Linecast(transform.position,
                                           groundCheck.position,
                                           1 << LayerMask.NameToLayer("Ground"));
        if (tocouPlataforma) {
            rigidbody.AddForce(aceleracao, 0f, 0f, ForceMode.Acceleration);
            temPuloDuplo = false;
            if (Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) {
                rigidbody.AddForce(velocidadePulo, ForceMode.VelocityChange);
                temPuloDuplo = true;
            }
        }
        else if ((Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && temPuloDuplo) {
			rigidbody.AddForce(velocidadePulo, ForceMode.VelocityChange);
			temPuloDuplo = false;
		}
		Debug.DrawRay (transform.position, transform.right);
		Vector3 right = transform.right;
		float distancia =100;
		if (Physics.Raycast (transform.position, right, out hitInfo, distancia) == true) {
			Debug.Log ("Colidiu.....");
			if(hitInfo.distance == distancia/2){
				rigidbody.AddForce(velocidadePulo, ForceMode.VelocityChange);
			}
			
			//Debug.Log("Acertou Algo....");

		} else {
			Debug.Log ("Nao Colidiu.....");
		}
	}
}
