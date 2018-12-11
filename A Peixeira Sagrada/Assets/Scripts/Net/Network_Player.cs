using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Network_Player : NetworkBehaviour {

	//Velocidade e rigidbody do player
	public float moveSpeed;
	private Rigidbody2D rb;

	//Direções necessárias.
	private Vector3 moveInput;
	private Vector3 moveVelocity;

	public GameObject weapon;
	public bool meleeWeapon;
	public GameObject bulletPlayer;
	public Transform bulletPosition;

    public bool olhandoDireita;

    void Start () {
		//Setando o rigidbody.
		rb = GetComponent <Rigidbody2D> ();

        olhandoDireita = true;
    }

	void Update () {

		if (!isLocalPlayer) {
			return;
		}

		//Movimentando
		moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"), 0f );
		moveVelocity = moveInput * moveSpeed;

			CmdAtacar ();


	}

	void FixedUpdate(){

		rb.velocity = moveVelocity;
	}

	public override void OnStartLocalPlayer() {

		GetComponent<SpriteRenderer>().material.color = Color.blue;
	}

	[Command]
	public void CmdAtacar(){

		if (meleeWeapon== true) {

			if (Input.GetKeyDown ("x")) {
				weapon.SetActive (true);

			} else if (Input.GetKeyUp ("x")) {
				weapon.SetActive (false);
			}

		} else if (meleeWeapon ==false){

			if(Input.GetKeyDown ("x")){
				
				Instantiate (bulletPlayer, bulletPosition.transform.position, bulletPosition.rotation);	
				NetworkServer.Spawn (bulletPlayer);
			}
		}
	}

    private void Flip(Vector3 moveInput)
    {

        if (moveInput.x > 0 && !olhandoDireita || moveInput.x < 0 && olhandoDireita)
        {

            olhandoDireita = !olhandoDireita;
            Vector3 escala = transform.localScale;
            escala.x *= -1;

            transform.localScale = escala;
        }

    }
}
