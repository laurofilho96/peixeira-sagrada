using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using UnityEngine.SceneManagement;

public class FirebaseLoginScript : MonoBehaviour {

	public InputField email;
	public InputField password;

	public void loginButton(){
		
		FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync (email.text, password.text).
		ContinueWith ((obj) => {

			SceneManager.LoadSceneAsync ("MenuLogado");
		});
	}

	public void AnonymButton(){

		FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync ().
		ContinueWith ((obj) => {
			
			SceneManager.LoadSceneAsync ("Menu");
		});
	}

	public void Cradastrar(){

		FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync (email.text, password.text).
		ContinueWith ((obj) =>
			{
			SceneManager.LoadSceneAsync ("MenuLogado");
			});
	}

	public void Sair(){

		Application.Quit ();
	}
}
