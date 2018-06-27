using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe para controlar a musica de fundo do jogo
/// </summary>
public class MusicaController : MonoBehaviour {

    public static MusicaController musicaController = null;

    /// <summary>
    /// Metodo chamado quando a instancia do script é carregada.
    /// Usado para iniciar a musica de fundo.
    /// </summary>
    private void Awake() {

        if(musicaController != null) {
            Destroy(gameObject);
        } else {
            musicaController = this;

            // nao destroi o objeto que toca a musica
            DontDestroyOnLoad(gameObject);
        }

    }
}
