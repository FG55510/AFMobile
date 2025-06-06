using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum ModosdeJogo
{
    ControlandoCamera,
    ControlandoItens
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
   // private UIManager ui;


    [SerializeField] private ModosdeJogo modo;

    [SerializeField] private MoveCamera cameramove;

    [SerializeField] private PinchZoom2D zoom;

    [SerializeField] private CirculodeInfluenciadoPlayer circulo;

    public UnityEvent Desassociarbixinhos;

    public string nextscene;
    private Scene faseatual;


    public int fantamasparaconcluir;
    public int fantamasnafase;
    public int fantamasatual;

    void Start()
    {
        circulo = GetComponent<CirculodeInfluenciadoPlayer>();
       // ui = FindAnyObjectByType<UIManager>();
        cameramove = FindAnyObjectByType<MoveCamera>();
        zoom = FindAnyObjectByType<PinchZoom2D>();

        ModoCamera();

        faseatual = SceneManager.GetActiveScene();

        fantamasatual = fantamasnafase;
       // ui.Atualizarfantasmas(fantamasatual, fantamasparaconcluir);
    }

    public void Fantasmamorreu()
    {
        fantamasatual--;
      //  ui.Atualizarfantasmas(fantamasatual, fantamasparaconcluir);

        if(fantamasatual < fantamasparaconcluir)
        {
        //    ui.Gameover();
        }
    }




    public void NextScene()
    {
        SceneManager.LoadScene(nextscene);
    }

    public void Retryscene()
    {
        SceneManager.LoadScene(faseatual.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Fantasmamorreu();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Entregoufantasma();
        }
    }

    public void Entregoufantasma()
    {
        fantamasparaconcluir--;
        fantamasatual--;
    //    ui.Atualizarfantasmas(fantamasatual, fantamasparaconcluir);
        if (fantamasparaconcluir <= 0)
        {
       //     ui.YouWin();
        }

    }


    public void ModoCamera()
    {
        MudarMododeJogo(ModosdeJogo.ControlandoCamera);
    }


    public void MudarMododeJogo(ModosdeJogo novomodo)
    {

        switch (novomodo){
            case ModosdeJogo.ControlandoCamera:
                Desassociarbixinhos.Invoke();
                cameramove.enabled= true;
                zoom.enabled = true;
                // circulo.enabled = true;
               // ui.DesativarJoystick();
                break;

            case ModosdeJogo.ControlandoItens:
                cameramove.enabled = false;
                zoom.enabled = false;
                //  circulo.enabled = false;
              //  ui.AtivarJoystick();
                break;
        }
        modo = novomodo;
            
    }

    

}
