using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class HpBar : MonoBehaviour {

	public Image currentHp;
	public Text info;

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

		hitPoint -= damage;
		if(hitPoint < 0) {
			hitPoint = 0;
			Debug.Log ("Dead!!!");
			Destroy(gameObject);
			canvasDeath.SetActive (true);
		}
		UpdateHp ();
	}

	private void HealDamage(float heal) {

		hitPoint += heal;
		if(hitPoint > maxHitPoint) {
			hitPoint = maxHitPoint;
		} 
		UpdateHp ();
	}

}
