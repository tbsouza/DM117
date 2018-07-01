using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPauseComp : MonoBehaviour {

    // variavel de controle do pause
    public static bool pausado;

    [Tooltip("REferencia para o GO de pause")]
    [SerializeField]
    private GameObject menuPause;


    // Use this for initialization
    void Start()  {
        pausado = false;
        SetMenuPause(false);
    }

    /// <summary>
    /// Metodo para reiniciar a fase
    /// </summary>
    public void Resetar() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name );
    }

    /// <summary>
    /// Metodo para pausar o jogo
    /// </summary>
    /// <param name="isPausado">Indica se esta pausado</param>
    public void SetMenuPause(bool isPausado) {
        pausado = isPausado;

        // pausa o tempo do jogo
        if (isPausado){
            Time.timeScale = 0.0F; // tempo parado
        }
        else {
            Time.timeScale = 1.0F; // tempo real
        }
    }

    /// <summary>
    /// Metodo para carregar uma cena
    /// </summary>
    /// <param name="nomeCena">Nome dda cena a ser carregada</param>
    public void CarregaCena( string nomeCena ){
        SceneManager.LoadScene(nomeCena);
    }
   
}
