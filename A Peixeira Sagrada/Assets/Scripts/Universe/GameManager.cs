using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*		O que esse script vai fazer:

			game manager - O game manager precisa conter uma lista das dungeons e a referência dos players. Ele também precisa
            de um contador para saber quantas dungeons foram descidas.
            
        O que o game manager irá fazer?

            ele irá instanciar a dungeon primeiro. A dungeon tem que ser instanciada aleatoriamente.  ele irá pegar a
            referência dos jogadores e instanciar nos spawnpoints logo em seguida.

            toda vez que UM player, seja na multiplayer ou solo, encostar na descida da dungeon, aumenta um número do
            contador e a dungeon é resselecionada.

        Como a dungeon é resselecionada?

    	    -Não tem a lista? Então, será instanciado um objeto dessa lista, certo?
            Quando o player encontar, ele irá fazer um fade in e fade out, dentro 	desse efeito, a dungeon atual será 
            destruída, uma nova será selecionada,
	        O player será recolocado no spawnPoint e subirá um ponto no contador 	de dungeons.

	        Quando o contador chegar nos números [x,y,z], serão chefes. 
	        [(x+1), (y+1)] - Próximo cenário.
	        [z+1] - zera o jogo.*/

public class GameManager : MonoBehaviour {

    private GameManager gameManager;

    public string SelectScene, GameScene;
    Scene m_Scene;

	//Lista de mapas, numero a sortear, referencia do mapa sorteado.
	public GameObject[] dungeons;
	private int intRandom;
    private GameObject selected;

    //Necessários para posicionar o jogador na posicao correta.
    public GameObject[] players;
    public int idPlayer;

    //Contagem dos andares, lembrar de torna-lo uma string.
    public int floorCount;
    public Text contagem;

	//Randomiza a Dungeon; Instanciar um player no inicio da dungeon; Definir a contagem em 1.
	void Awake(){

        if(gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
	}

   
    // Aqui vai checar em qual cena está.
    private void Update()
    {
        //Define a cena como a atual.
        m_Scene = SceneManager.GetActiveScene();
    }
    //Instanciar o Player no início da fase. Se o player chegar no fim, irá randomizar a dungeon de novo e acrescentar +1 andar a lista.

    /*irá instanciar a dungeon aleatória.
     * Sorteia o número da dungeon;
       Define o game object "selected" como a dungeon sorteada;
       Instancia selected em sua posição e com a rotação padrão;*/
    public void RandomizeDungeon()
    {

            intRandom = Random.Range(0, dungeons.Length);
            selected = dungeons[intRandom];
            Instantiate(selected, transform.position, Quaternion.identity);
	}

    /*Instanciar o player na posição inicial:
      Criar uma nova referência para a posicao "spawn";
      Definir a referência de "spawn" como a posicao de selected;
      Resgatar o Id do player selecionado na tela de selecao de personagem; - Fazendo em outro código.
      instanciar o player referente a id na posicao de spawn;*/
    public void SpawnPlayer()
    {
        Transform spawn;
        spawn = selected.transform.Find("Inicio").transform;

    }

    /*Referenciar final:
      Referenciar o que é a escada;
      define a escada como a posicao de um objeto final;
      */
      public void FinalRoom()
    {
        Transform final;
        final = selected.transform.Find("End").transform;
        
    }

    /*compara o objeto final com o player(TAG):
      Quando o player encostar;
      Adiciona +1 ao contador;
      chama novamente o método de randomizar a dungeon;*/
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            floorCount += 1;
            RandomizeDungeon();
        }
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);

        if(scene.name == GameScene)
        {
            RandomizeDungeon();
        }
        
    }
}
