using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour {

    public Text texto;
    public string[] instrucoes;
    public GameObject player;

    void Start()
    {
        texto.text = instrucoes[0];
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag != player.tag)
        {

            Destroy(player);
        }
    }

}
