using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //QUE TIRO FOI ESSE???
public class Bullet : MonoBehaviour {

	//Velocidade da bala
	public float speed;

	//Posição e coordenada.
	public Transform player;
	public Vector2 target;

	void Start () {

		//Seta a posição como sendo a do player e a coordenada como a posição atual do player em x e em y.
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		target = new Vector2 (player.position.x, player.position.y);
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

		if (other.CompareTag ("Player")) {
			DestroyBullet ();
		}
	}

	void DestroyBullet(){

		Destroy (gameObject);
	}
}
