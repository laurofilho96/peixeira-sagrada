using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Comentários no final.
public class Menu : MonoBehaviour {

	public void StartGame(){
		
		SceneManager.LoadScene ("CharacterSelect");
	}

	public void CoopGame(){
		SceneManager.LoadScene ("Multiplayer");
	}

    public void Bestiary()
    {
        SceneManager.LoadScene("Bestiario");
    }

    public void Inicial()
    {
        SceneManager.LoadScene("Menu");
    }

    public void IniciaMultiplayer()
    {
        SceneManager.LoadScene("MenuLogado");
    }

    public void Quit(){
		
		Debug.Log ("Saiu do Jogo");
		Application.Quit ();
	}

    
}
/*Esse script serve só para controlar as cenas...
 * 
	Pode ser usado em qualquer tela fora do jogo em si, ou seja
	Utilizar para menus, telas de créditos, pauses, telas de game over e de vitória e outras do tipo.

	Falta Script de Config, melhor colocar em outro script.*/
