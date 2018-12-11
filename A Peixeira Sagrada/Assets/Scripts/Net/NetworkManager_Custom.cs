using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkManager_Custom : NetworkManager {
	
	//Hospedar a partida.
	public void StartUpHost() {

		SetPort();
		NetworkManager.singleton.StartHost();
	}

	//Participar da partida.
	public void JoinGame() {

		SetIpAddress();
		SetPort();
		NetworkManager.singleton.StartClient();
	}

	//Buscar partida por Ip.
	void SetIpAddress() {

		string ipAddress = GameObject.Find ("InputIP").transform.Find ("Text").GetComponent<Text> ().text;
		NetworkManager.singleton.networkAddress = ipAddress;
	}

	//Definir a porta.
	void SetPort(){

		NetworkManager.singleton.networkPort = 7777;
	}

	/*Quando o nível for carregado - se voltar pro menu(ou não houver cena), utiliza os botões do menu.
	  Caso contrário, utiliza o botão de desconectar.*/
	void OnlvlWasLoaded(int lvl){

		if (lvl == 0) {
			
			SetupMenuSceneButtons();
		} else {
			
			SetupOtherSceneButtons();
		}
	}

	//Botões de iniciar e participar de hospedagem.
	void SetupMenuSceneButtons(){

		GameObject.Find ("ButtonHost").GetComponent<Button> ().onClick.RemoveAllListeners();
		GameObject.Find ("ButtonHost").GetComponent<Button> ().onClick.AddListener(StartUpHost);

		GameObject.Find ("ButtonJoin").GetComponent<Button> ().onClick.RemoveAllListeners();
		GameObject.Find ("ButtonJoin").GetComponent<Button> ().onClick.AddListener(JoinGame);
	}

	//Desconectar.
	void SetupOtherSceneButtons(){

		GameObject.Find ("ButtonDc").GetComponent<Button> ().onClick.RemoveAllListeners();
		GameObject.Find ("ButtonDc").GetComponent<Button> ().onClick.AddListener(NetworkManager.singleton.StopHost);
	}
}
