using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkSpawn :NetworkBehaviour {

	public GameObject player;
	public Transform localSpawn;

	void Start(){

		RpcSpawnPlayer ();
	}
	[ClientRpc]
	void RpcSpawnPlayer(){

		if(!isLocalPlayer){

			return;
		}

		Instantiate (player, localSpawn.position, localSpawn.rotation);
	}
}
