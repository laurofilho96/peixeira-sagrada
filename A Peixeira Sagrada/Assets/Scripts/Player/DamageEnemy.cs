using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour {

	public bool isDamage;
	public float damage = 10f;

	private void OnTriggerEnter2D (Collider2D other){

		if(other.tag == "Enemy"){
			Debug.Log ("Enscostando inimigo!");
			other.SendMessage ((isDamage)?"TakeDamage" : "HealDamage", Time.deltaTime * damage);
		}
	}
}
