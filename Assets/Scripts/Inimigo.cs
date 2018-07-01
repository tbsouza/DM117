using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe do comportamento do inimigo (abacaxi)
/// </summary>
public class Inimigo : MonoBehaviour {

    [SerializeField]
    [Tooltip("Particulas da explosao da Nave")]
    private GameObject explosao;

    [SerializeField]
    [Tooltip("Tempo para carregar gameover")]
    [Range(0.1f, 0.9f)]
    private float gameoverTime;

    // instancia de LevelController
    private LevelControle levelControle;


    // Use this for initialization
    void Start () {
        levelControle = FindObjectOfType<LevelControle>();
    }
	
    /// <summary>
    /// Metodo para tratar colisoes
    /// </summary>
    /// <param name="collision">Objeto que colidiu</param>
    private void OnCollisionEnter2D(Collision2D collision) {

        // verifica se houve colisao com a nave
        if (collision.gameObject.GetComponent<PlayerController>()){

            // Instancia a explosao na posicao da nave
            Instantiate( explosao, collision.transform.position, Quaternion.identity);

            // Destroi a nave
            Destroy(collision.gameObject);

            // Chama LoadGameOver apos gameoverTime
            Invoke("LoadGameOver", gameoverTime);
        }
    }

    /// <summary>
    /// Metodo para carregar a cena de gameover
    /// </summary>
    void LoadGameOver() {
        // Carrega a cena de gameover
        levelControle.CarregaLevel("TelaGameOver");
    }

}
