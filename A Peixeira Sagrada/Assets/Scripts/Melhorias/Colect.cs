using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colect: MonoBehaviour {

    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.espacos.Length; i++)
            {
                if (inventory.cheio[i] == false)
                {
                    inventory.cheio[i] = true;
                    Instantiate(itemButton, inventory.espacos[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
