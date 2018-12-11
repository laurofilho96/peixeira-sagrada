using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMelee : MonoBehaviour {

	//Velocidade, distancia e player.
	public float speed;
	public float stopDistance;

	private Transform target;

	void Start () {

		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		
	}

	void Update () {

		if (Vector2.Distance (transform.position, target.position) > stopDistance) {
			transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
		}
	}
}
