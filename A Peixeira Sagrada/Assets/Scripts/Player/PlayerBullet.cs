using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

	//Velocidade da bala
	public float speed;

	//Posição e coordenada.
	public Transform enemyTarget;
	public Vector2 target;

	void Start () {

		//Seta a posição como sendo a do player e a coordenada como a posição atual do player em x e em y.
		enemyTarget = GameObject.FindGameObjectWithTag ("Enemy").transform;

		target = new Vector2 (enemyTarget.position.x, enemyTarget.position.y);
	}

	void Update () {

		//Percorre até a última coordenada do player no instante do tiro.
		transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);

		//Se ele chegou no local, destrói a bala.
		if (transform.position.x == target.x && transform.position.y == target.y) {

			DestroyBullet ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag ("Enemy")) {
			DestroyBullet ();
		}
	}

	void DestroyBullet(){

		Destroy (gameObject);
	}
}
