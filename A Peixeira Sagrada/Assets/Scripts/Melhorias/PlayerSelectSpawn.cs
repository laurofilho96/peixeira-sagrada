using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectSpawn : MonoBehaviour {


    public GameObject[] player;

    private void Awake()
    {
        int index = FindObjectOfType<GameManager>().idPlayer - 1;
        Instantiate(player[index], transform.position, transform.rotation);
    }
}
