using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe para gerenciar e carregar o GameOver
/// </summary>
public class GameOver : MonoBehaviour {

    // Instancia do GO LevelControle
    private LevelControle levelControle;

    private void Start() {
        // pega o objeto LevelControle
        levelControle = FindObjectOfType<LevelControle>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        // Chama o metodo CarregaLevel de LevelControle
        levelControle.CarregaLevel("TelaGameOver");

        // Tentei fazer de uma forma diferente, para deixar
        // o metodo de carregar level encapsulado no LevelControle
        // Tambem funciona, mas não sei qual a melhor opcao
    }

}
