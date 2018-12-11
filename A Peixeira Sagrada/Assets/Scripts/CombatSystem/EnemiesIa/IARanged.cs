using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IARanged: MonoBehaviour {
	//Velocidade
	public float speed;

	//Distancias para serem calculadas
	public float stopDistance;
	public float retreatDistance;

	//Posição
	public Transform player;

	//Ataque - tempo de tiro(cooldown) e começo do tiro.
	private float timeShoot;
	public float startTimeShoot;

	//prefab da bala.
	public GameObject bullet;

	void Start () {

		//Setou a posição como a posição do player
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		//Iguala os dois tempos de tiro
		timeShoot = startTimeShoot;
	}

	void Update () {
		/*MOVIMENTO
		 * --------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
		//Se a distância do inimigo entre o player for maior que a distância de parada, segue o player.
		if (Vector2.Distance (transform.position, player.position) > stopDistance) {

			transform.position = Vector2.MoveTowards (transform.position, player.position, speed * Time.deltaTime);

			//Se for menor mas for menor que a distância de parada, mas maior que a de recuo, fique aí.
		} else if (Vector2.Distance(transform.position, player.position) < stopDistance &&
			Vector2.Distance(transform.position, player.position) > retreatDistance){

			transform.position = this.transform.position;

			//Se for menor que a distância de recuo, recue.
		}else if(Vector2.Distance(transform.position, player.position) < retreatDistance){

			transform.position = Vector2.MoveTowards (transform.position, player.position, -speed * Time.deltaTime);
		}
		//----------------------------------------------------------------------------------------------------------------------------------------------------------------------

		/*ATAQUE
		 *  --------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
		//Se o tempo de tiro for menor que zero, atire a partir da posição do inimigo.
		if (timeShoot <= 0) {

			Instantiate (bullet, transform.position, Quaternion.identity);
			timeShoot = startTimeShoot;

			//Senão, vai diminuindo o tempo até chegar a hora.
		} else {

			timeShoot -= Time.deltaTime;
		}
	}
}