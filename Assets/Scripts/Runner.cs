﻿using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {

    public static float distanciaPercorrida;
    public float aceleracao;
	public Vector3 velocidadePulo;
	public bool temPuloDuplo = false;

	protected GameObject runner;
    protected Transform groundCheck;
    protected bool tocouPlataforma;
    protected bool pular;
    protected Vector3 posicaoInicial;

	public void Start(){
        posicaoInicial = transform.position;
	}

    void Awake() {
        groundCheck = transform.FindChild("GroundCheck");
    }

	public virtual void Update () {
		distanciaPercorrida = transform.localPosition.x;

        if (!tocouPlataforma && rigidbody.position.x <= 0) {
            rigidbody.velocity = Vector3.zero;
        }

        if (Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) {
            pular = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
	}

	public void FixedUpdate () {
        tocouPlataforma = Physics.Linecast(transform.position,
                                           groundCheck.position,
                                           1 << LayerMask.NameToLayer("Ground"));

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
            pular = false;
		}
	}

    public void reset() {
        transform.position = posicaoInicial;
    }
}
