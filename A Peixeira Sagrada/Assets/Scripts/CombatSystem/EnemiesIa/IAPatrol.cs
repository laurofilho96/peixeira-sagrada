using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPatrol : MonoBehaviour {

	//Velocidade do Inimigo.
	public float speed;

	//Tempo de espera num spot.
	private float waitTime;
	public float startWaitTime;

	//Patrulha aleatória.
	public Transform moveSpot;

	//Limites de X e Y.
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	//Raycasting.
	public float rotationSpeed;
	public float distance;

	private IAMelee iam;

	void Start () {
	
		waitTime = startWaitTime;
		iam = GetComponent<IAMelee>();

		//Seleciona um local aleatório para o inimigo ir.
		moveSpot.position = new Vector2(Random.Range(minX, maxX),Random.Range(minY, maxY));
		Physics2D.queriesStartInColliders = false;
	}

	void Update () {

		//O Inimigo vai patrulhar de onde tá até um canto aleatório.
		transform.position = Vector2.MoveTowards (transform.position, moveSpot.position, speed * Time.deltaTime);

		//Inimigo parado
		if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f) {
			//Se ele já esperou o suficiente... Calcula uma nova trajetória e pega o beco.
			if (waitTime <= 0) {
				moveSpot.position = new Vector2(Random.Range(minX, maxX),Random.Range(minY, maxY));	
				waitTime = startWaitTime;
			//Senão, espera o tempo necessário.
			} else {
				//Rotaciona.
				transform.Rotate (Vector3.forward * rotationSpeed * Time.deltaTime);
				RaycastHit2D hitInfo = Physics2D.Raycast (transform.position, transform.right, distance);

				//Desenhando o raycast.
				if (hitInfo.collider != null) {

					Debug.DrawLine (transform.position, hitInfo.point, Color.red);
					//Se o HitInfo se colidir com o player, explode o player.
					if (hitInfo.collider.CompareTag ("Player")) {
						iam.enabled = true;				
					}

				} else {
					Debug.DrawLine (transform.position, transform.position + transform.right * distance, Color.green);
				}
			}
				waitTime -= Time.deltaTime;
			}
		}


	}

