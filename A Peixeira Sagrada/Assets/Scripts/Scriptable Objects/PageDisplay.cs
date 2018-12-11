using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*Script do objeto na cena. Ele irá pegar o objeto criado pelo script 'Pages'. Então ele associa ao objeto na
  hierarquia, substituindo as informações da página nos lugares que serão pré-estabelecidos.*/
public class PageDisplay : MonoBehaviour {

    public Pages page;

    public Text nameText;
    public Text descricaoText;
    public Text anotacaoText;

    public Image artImage;

	void Start () {

        nameText.text = page.name;
        descricaoText.text = page.descricao;
        anotacaoText.text = page.anotacao;

        artImage.sprite = page.arte;
		
	}
	
	
}
