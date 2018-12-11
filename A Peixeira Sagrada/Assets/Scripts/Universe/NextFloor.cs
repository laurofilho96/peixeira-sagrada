using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextFloor : MonoBehaviour {

	public GameObject gM;
	public GameObject dungeon;

	void OnTriggerEnter2D(Collider2D other){

		if (other.CompareTag ("Player")) {
			Destroy (transform.parent.gameObject);
			Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);;
		}
	}
}
