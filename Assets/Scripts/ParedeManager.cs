using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParedeManager : MonoBehaviour {

	public Transform prefab;
	public int numeroDeParedes;
	public Vector3 posicaoInicial;
	public Vector3 minSize, maxSize;
	public float repetidorOffset;

	private Queue<Transform> filaDeParedes;

	public Vector3 proximaPosicao;

	// Use this for initialization
	void Start () {
		filaDeParedes = new Queue<Transform>(numeroDeParedes);
		for (int i = 0; i < numeroDeParedes; i++) {
			filaDeParedes.Enqueue((Transform)Instantiate(prefab));
		}
		proximaPosicao = posicaoInicial;
		for (int i = 0; i<numeroDeParedes; i++) {
			Renovar ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (filaDeParedes.Peek().localPosition.x + repetidorOffset < Runner.distanciaPercorrida) {
			Renovar();
		}
	}

	private void Renovar () {
		Vector3 scale = new Vector3(
			Random.Range(minSize.x, maxSize.x),
			Random.Range(minSize.y, maxSize.y),
			Random.Range(minSize.z, maxSize.z));
		
		Vector3 position = proximaPosicao;
		position.x += scale.x * 0.5f;
		position.y += scale.y * 0.5f;
		Transform o = filaDeParedes.Dequeue();
		o.localScale = scale;
		o.localPosition = position;
		proximaPosicao.x += scale.x;
		filaDeParedes.Enqueue(o);
	}
}
