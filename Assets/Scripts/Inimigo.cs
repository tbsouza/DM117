using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Classe do comportamento do inimigo (abacaxi)
/// </summary>
public class Inimigo : MonoBehaviour {

    [SerializeField]
    [Tooltip("Particulas da explosao da Nave")]
    private GameObject explosaoNave;

    [SerializeField]
    [Tooltip("Particulas da explosao do Inimigo")]
    private GameObject explosaoInimigo;

    [SerializeField]
    [Tooltip("Tempo para carregar gameover")]
    [Range(0.1f, 0.9f)]
    private float gameoverTime;

    // audiosource da explosao
    private AudioSource audioSource;

    // instancia de LevelController
    private LevelControle levelControle;

    // referencia do jogador
    private GameObject jogador;

    // referencia para o menu com a opcao de continuar apos anuncio
    //private GameObject menuAnuncio;

    // Use this for initialization
    void Start () {
        levelControle = FindObjectOfType<LevelControle>();

        // pega o componente audiosource da nave
        audioSource = GetComponent<AudioSource>();
    }
	
    /// <summary>
    /// Metodo para tratar colisoes
    /// </summary>
    /// <param name="collision">Objeto que colidiu</param>
    private void OnCollisionEnter2D(Collision2D collision) {

        // verifica se houve colisao com a nave
        if (collision.gameObject.GetComponent<PlayerController>()){
/*
            menuAnuncio = GameObject.FindGameObjectWithTag("menuAnuncio");

            menuAnuncio.gameObject.SetActive(true);

            var botoao = menuAnuncio.transform.GetComponentInChildren<Button>();
            Button botaoContinue = null;
            
            if (botoao.gameObject.name.Equals("menuAnuncio")) {
                botaoContinue = botoao; // referencia do botao continue
            }

            if (botaoContinue) {
#if UNITY_ADS
                botaoContinue.onClick.AddListener(UnityAdControle.ShowRewardAd());
                UnityAdControle.obstaculo = this;
#else
                botaoContinue.gameObject.SetActive(false);
#endif
            }

            // esconde o player
            collision.gameObject.SetActive(false);

            jogador = collision.gameObject;
*/

            // Instancia a explosao na posicao da nave
            Instantiate(explosaoNave, collision.transform.position, Quaternion.identity);

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

    /// <summary>
    /// Metodo chamado quando o inimigo eh clickado
    /// </summary>
    public void ObjetoClickado() {

        if (explosaoInimigo != null) {
            // instancia a explosao do inimigo
            var particle = Instantiate(explosaoInimigo, transform.position, Quaternion.identity);

            // toca o audio de explosao do inimigo

            // destri a particula instanciada
            Destroy(particle, 1.0f);
        }

        // toca o som de explosao
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

        // destroi o inimigo
        Destroy(this.gameObject);
    }
    
}
