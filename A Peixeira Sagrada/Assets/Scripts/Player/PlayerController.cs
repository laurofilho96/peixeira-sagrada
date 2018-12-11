using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//Velocidade e rigidbody do player
	public float moveSpeed;
	private Rigidbody2D rb;

	//Direções necessárias.
	private Vector3 moveInput;
	private Vector3 moveVelocity;

	public GameObject weapon;
	public bool meleeWeapon;
	public GameObject bulletPlayer;

	public bool olhandoDireita;
	public Transform calibre;

	void Start () {
		//Setando o rigidbody.
		rb = GetComponent <Rigidbody2D> ();

		olhandoDireita = true;
	}

	void Update () {
	//Movimentando
		moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0f );
		moveVelocity = moveInput * moveSpeed;
        //Se a arma for de curto alcance, ativa a arma apertando x...
		if (meleeWeapon== true) {
			
			if (Input.GetKeyDown ("x")) {
				weapon.SetActive (true);

			} else if (Input.GetKeyUp ("x")) {
				weapon.SetActive (false);
			}
            //...Senão, atira quando apertar x.
		} else if (meleeWeapon ==false){
			
			if(Input.GetKeyDown ("x")){
				Instantiate (bulletPlayer, calibre.position, Quaternion.identity);	
			}
		}
	}

	void FixedUpdate(){
		
		rb.velocity = moveVelocity;

		Flip (moveInput);
	}

	private void Flip(Vector3 moveInput){

		if(moveInput.x > 0  && !olhandoDireita || moveInput.x <0  && olhandoDireita){

			olhandoDireita = !olhandoDireita;
			Vector3 escala = transform.localScale;
			escala.x *= -1;

			transform.localScale = escala;
		}

	}
}
