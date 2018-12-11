using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

    private int idPlayer;

    private AudioSource aS;

	void Start () {

        idPlayer = 1;
        aS = GetComponent<AudioSource>();
	}
	
	/*void Update () {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            idPlayer = 1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            idPlayer = 2;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {

            FindObjectOfType<GameManager>().idPlayer = idPlayer;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
		
	}*/

    public void PrimeiroBuneco ()
    {
        idPlayer = 1;
        TocaSom();
        Debug.Log("1");
    }

    public void SegundoBuneco()
    {
        idPlayer = 2;
        TocaSom();
        Debug.Log("2");
    }

    public void SelecionarBuneco()
    {
        FindObjectOfType<GameManager>().idPlayer = idPlayer;
        SceneManager.LoadScene("SinglePlayer");
    }

    void TocaSom()
    {

        if (!aS.isPlaying)
        {
            aS.Play();
        }
    }
}
