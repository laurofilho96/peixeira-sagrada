using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour {

	public GameObject Enemy;
	public Transform localSpawn;

	public float repeatTime = 5.0f;

	void OnTriggerEnter2D(Collider2D other) {

		if(other.gameObject.tag == "Player"){
			InvokeRepeating ("Spawning",  1f, repeatTime);
			Destroy (gameObject, 11);
			gameObject.GetComponent<Collider2D> ().enabled = false;

		}
	}

	void Spawning(){

		Instantiate (Enemy, localSpawn.position, localSpawn.rotation);
	}
}
