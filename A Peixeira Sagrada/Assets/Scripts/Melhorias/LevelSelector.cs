using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public Button[] levelButtons;

    private void Start()
    {
        int lvlReached = PlayerPrefs.GetInt("lvlReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > lvlReached) {

                levelButtons[i].interactable = false;
            }
        }
    }
}


/*Em outro código, o de game manager:

    public GameManager
    public int lvlqueAbre = 2;
    public void PassouDeFase(){
        PlayerPrefs.SetInt("lvlReached", 2);
        sceneFader.FadeTo(nextlevel);
    }

    Isso daqui praticamente é o que vai fazer os lvls serem habilitados. Você precisa chamar esse Método
    (PassouDeFase) em outro script, o que controla a condição de passar de fase, para assim que você
    matar os inimigos ou chegar em tal lugar, ele passar de fase. Outra coisa, tem que dizer manualmente
    através do inspector qual fase você irá desbloquear, ele não faz isso só.
     */
