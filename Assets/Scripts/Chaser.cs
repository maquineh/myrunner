using UnityEngine;
using System.Collections;

public class Chaser : Runner {

    private bool pular = false;
    private float distancia = 20;
    private RaycastHit hitInfo;

    public void Start() {
	
	}

    public override void Update() {
        if (!tocouPlataforma && rigidbody.position.x <= 0) {
            rigidbody.velocity = Vector3.zero;
        }
    }

	public override void FixedUpdate () {
        tocouPlataforma = Physics.Linecast(transform.position,
                                           groundCheck.position,
                                           1 << LayerMask.NameToLayer("Ground"));
        
        Vector3 right = transform.right;
        Vector3 diagonal = Quaternion.AngleAxis(-45, Vector3.forward) * right;
        Debug.DrawRay(transform.position, right * distancia);
        Debug.DrawRay(transform.position, diagonal * distancia, Color.cyan);

        pular = false;
        if (Physics.Raycast(transform.position, 
                            right, 
                            out hitInfo, 
                            distancia, 
                            1 << LayerMask.NameToLayer("Ground"))) {
            if (hitInfo.distance <= distancia / 2) {
                pular = true;
            }
        }

        if (tocouPlataforma) {
            rigidbody.AddForce(aceleracao, 0f, 0f, ForceMode.Acceleration);
            temPuloDuplo = false;
            if (pular) {
                rigidbody.AddForce(velocidadePulo, ForceMode.VelocityChange);
                temPuloDuplo = true;
                pular = false;
            }
        }
        else if (pular && temPuloDuplo) {
			rigidbody.AddForce(velocidadePulo, ForceMode.VelocityChange);
			temPuloDuplo = false;
		}
	}
}
