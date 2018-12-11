using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAObserver : MonoBehaviour {

	//Velocidade de Rotação e distância percorrida pelo raycast.
	public float rotationSpeed;
	public float distance;

	void Start () {

		// O collider do objeto não será reconhecido pelo raycast.
		Physics2D.queriesStartInColliders = false;
	}

	void Update () {

		//rotaciona de acordo com a velocidade. Cria um raycast a partir do objeto que será acionado ao detectar colisão.
		transform.Rotate (Vector3.forward * rotationSpeed * Time.deltaTime);

		RaycastHit2D hitInfo = Physics2D.Raycast (transform.position, transform.right, distance);

		//O Raycast será desenhado a partir do instante em que o jogo inicia. Se ele detectar alguma colisão, sua linha se tornará vermelha, senão, verde.
		if (hitInfo.collider != null) {
			Debug.DrawLine (transform.position, hitInfo.point, Color.red);

			//Se o HitInfo se colidir com o player, explode o player.
			if (hitInfo.collider.CompareTag ("Player")) {
				Destroy (hitInfo.collider.gameObject);
			}

		} else {
			Debug.DrawLine (transform.position, transform.position + transform.right * distance, Color.green);
		}
	}
}
