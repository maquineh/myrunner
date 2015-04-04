using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlataformaManager : MonoBehaviour {

	public Transform prefab;
	public int numeroDeParedes;
    public Vector3 minSize, maxSize, minGap, maxGap;
	public float minY, maxY;
	public float repetidorOffset;

    public Vector3 posicaoInicial;
    public Vector3 proximaPosicao;
	private Queue<Transform> plataformas;
	
	void Start () {
        ResetarFase();
	}

    public void ResetarFase() {
        posicaoInicial = Vector3.zero;
        proximaPosicao = Vector3.zero;
        Runner.distanciaPercorrida = 0;
        if (plataformas != null) {
            while (plataformas.Count > 0) {
                Transform t = plataformas.Dequeue();
                Destroy(t.gameObject);
            }
        }
        plataformas = new Queue<Transform>(numeroDeParedes);
        for (int i = 0; i < numeroDeParedes; i++) {
            plataformas.Enqueue((Transform)Instantiate(prefab));
        }
        proximaPosicao = posicaoInicial;
        for (int i = 0; i < numeroDeParedes; i++) {
            Renovar();
        }
    }
	
	void Update () {
		if (plataformas.Peek().localPosition.x + repetidorOffset < Runner.distanciaPercorrida) {
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
		
		Transform o = plataformas.Dequeue();
		o.localScale = scale;
		o.localPosition = position;
		plataformas.Enqueue(o);
		
		proximaPosicao += new Vector3(
			Random.Range(minGap.x, maxGap.x) + scale.x,
			Random.Range(minGap.y, maxGap.y),
			Random.Range(minGap.z, maxGap.z));
		
		if(proximaPosicao.y < minY){
			proximaPosicao.y = minY + maxGap.y;
		}
		else if(proximaPosicao.y > maxY){
			proximaPosicao.y = maxY - maxGap.y;
		}
	}

	public void setPlataformas(int qtdePlataformas){

	}
}
