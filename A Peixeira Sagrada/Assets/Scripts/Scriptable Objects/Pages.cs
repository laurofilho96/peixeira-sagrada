using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Um Objeto em script de uma página do bestiário. Com a linha abaixo, podemos criar um novo objeto do tipo página
  a partir do menu pela própria aba de assets. O objeto dos assets será associado a um objeto na cena.*/
[CreateAssetMenu(fileName ="New Page",menuName ="Page")]
public class Pages : ScriptableObject {

    public new string nome;
    public string descricao;
    public string anotacao;

    public Sprite arte;
	
}
