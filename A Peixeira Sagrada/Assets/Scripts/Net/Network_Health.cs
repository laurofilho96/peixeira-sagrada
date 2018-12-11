using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Network_Health : NetworkBehaviour {

	public Image currentHp;
	public Text info;

	[SyncVar]
	public float hitPoint = 100;
	public float maxHitPoint = 100;
	public GameObject canvasDeath;

	private void Start() {

		UpdateHp ();
	}

	private void UpdateHp() {

		float ratio = hitPoint / maxHitPoint;
		currentHp.rectTransform.localScale = new Vector3 (ratio, 1, 1);
		info.text = (ratio * 100).ToString ("0") + "/"+ maxHitPoint;
	}

	private void TakeDamage(float damage) {

		if(!isServer){

			return;
		}

		hitPoint -= damage;
		if(hitPoint < 0) {
			hitPoint = 0;
			Debug.Log ("Dead!!!");
			DestroyObject (gameObject);
			canvasDeath.SetActive (true);
		}
		UpdateHp ();
	}

	private void HealDamage(float heal) {

		if (!isServer) {

			return;
		}

		hitPoint += heal;
		if(hitPoint > maxHitPoint) {
			hitPoint = maxHitPoint;
		} 
		UpdateHp ();
	}

}
