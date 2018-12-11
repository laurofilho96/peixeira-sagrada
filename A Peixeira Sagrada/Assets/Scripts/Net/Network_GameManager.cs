using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Network_GameManager : NetworkBehaviour{

    private Network_GameManager gameManager;

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
    void Awake()
    {

        if (gameManager == null)
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

        if (scene.name == GameScene)
        {
            RandomizeDungeon();
        }

    }
}

