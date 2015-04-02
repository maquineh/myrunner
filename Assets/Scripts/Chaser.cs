using UnityEngine;
using System.Collections;

public class Chaser : Runner {

    private float distanciaHoriz = 20;
    private float distanciaDiag = 5;
    private RaycastHit hitInfo;
    private Transform raycastOrigin;

    public void Awake() {
        groundCheck = transform.FindChild("GroundCheck");
        raycastOrigin = transform.FindChild("RaycastOrigin");
    }
    
    public void Start() {
	
	}

    public override void Update() {
        if (!tocouPlataforma && rigidbody.position.x <= 0) {
            rigidbody.velocity = Vector3.zero;
        }
        Vector3 right = transform.right;
        Vector3 diagonal = Quaternion.AngleAxis(-45, Vector3.forward) * raycastOrigin.transform.right;
        Debug.DrawRay(transform.position, right * distanciaHoriz);
        Debug.DrawRay(raycastOrigin.transform.position, diagonal * distanciaDiag, Color.cyan);

        if (Physics.Raycast(transform.position,
                            right,
                            out hitInfo,
                            distanciaHoriz,
                            1 << LayerMask.NameToLayer("Ground"))) {
            if (hitInfo.distance <= distanciaHoriz / 2) {
                pular = true;
            }
        }

        if (!Physics.Raycast(transform.position,
                           diagonal,
                           out hitInfo,
                           distanciaDiag,
                           1 << LayerMask.NameToLayer("Ground"))) {
            if (hitInfo.distance <= distanciaDiag) {
                pular = true;
            }
        }

    }
}
