using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorCount : MonoBehaviour {

	public static FloorCount hud_Instance = null;
	public Text andar;
	public int contagem;

	void Awake(){

		if(hud_Instance == null) {
			
				hud_Instance = this;
		} else if (hud_Instance != this) {
			
			Destroy (this.gameObject);
		}


		DontDestroyOnLoad(GameObject.Find ("Hud_canvas"));
	}

	public void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag ("Finish")){

			contagem += 1;
			andar.text = contagem.ToString ();
		}
	}
}
