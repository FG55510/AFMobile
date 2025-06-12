using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text TMPfantasmas;

    public TMP_Text TMPResultadofase;

    public Button Retryfase;

    public Button Nextfase;

   // public Joystick joystick;

   // public Button exitcontrol;

    // Start is called before the first frame update
    void Start()
    {
        TMPResultadofase.gameObject.SetActive(false);
        TMPResultadofase.gameObject.SetActive(false);
        Retryfase.gameObject.SetActive(false);
        Nextfase.gameObject.SetActive(false);

       // joystick = FindAnyObjectByType<Joystick>();
     //   joystick.gameObject.SetActive(false);
     //   exitcontrol.gameObject.SetActive(false);
    }
 /*
    public void AtivarJoystick()
    {
        joystick.gameObject.SetActive(true);
        exitcontrol.gameObject.SetActive(true);
    }

    public void DesativarJoystick()
    {
        joystick.gameObject.SetActive(false);
        exitcontrol.gameObject.SetActive(false);
    }*/

    public void Gameover()
    {
        TMPResultadofase.gameObject.SetActive(true);
        TMPResultadofase.text = "Gameover";
        Retryfase.gameObject.SetActive(true);
    }

    public void YouWin()
    {
        TMPResultadofase.gameObject.SetActive(true);
        TMPResultadofase.text = "You Win";
        Nextfase.gameObject.SetActive(true);

    }

    public void Atualizarfantasmas(int atual, int necessario)
    {
        TMPfantasmas.text = atual.ToString() + "/" + necessario.ToString();
    }
}
