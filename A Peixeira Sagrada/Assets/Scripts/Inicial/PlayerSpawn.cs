using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	public GameObject player;
	public Transform localSpawn;

	void Start(){

		SpawnPlayer ();
	}

	void SpawnPlayer(){

		Instantiate (player, localSpawn.position, localSpawn.rotation);
	}
}
