using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Classe para controlar o Player (nave)
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    // enum do tipo de movimento da nave
    private enum TipoMovimento { Mouse, Teclado }

    // audiosource da explosao
    private AudioSource audioSource;

    // RigidBody da nave ???
    private Rigidbody2D rb2d;

    [Header("Movimento")]
    [SerializeField]
    [Tooltip("Velocidade de movimento da nave")]
    [Range(5,20)]
    private int velocidadeMovimento;

    [SerializeField]
    [Tooltip("Movimento por teclado ou mouse")]
    private TipoMovimento movimentoHorizontal;


    // Use this for initialization
    void Start () {
        // pega o componente rigidbody da nave
        rb2d = GetComponent<Rigidbody2D>();

        // pega o componente audiosource da nave
        audioSource = GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () {

        // Verifica se o jogo está pausado
        if ( MenuPauseComp.pausado ) {
            return;
        }

        // verifica click do mouse
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Click");

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 0;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosition);
            ClickarObejeto(mousePos);
        }

        // movimento da nave
        movimentoNave();
    }

    /// <summary>
    /// Metodo para para gerar Raycast na direcao do click do mouse
    /// e destruir o inimigo clickado.
    /// </summary>
    /// <param name="mousePosition">Posicao do mouse apos click</param>
    private static void ClickarObejeto(Vector3 mousePos){


        // Converte a posicao do mouse em Ray
        Ray clickRay = Camera.main.ScreenPointToRay(mousePos);

        // Informacoes do objeto clikcado
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero); ;

        if ( hit.collider != null ) {
            // se objeto clickado, chama metodo ObjetoClickado por mensagem
            hit.transform.SendMessage("ObjetoClickado", SendMessageOptions.DontRequireReceiver);

            Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
        }
    }

    /// <summary>
    /// Metodo para controlar o movimento lateral da nave
    /// </summary>
    private void movimentoNave() {

        // Verifica se esta utilizando teclado ou mouse
        if (movimentoHorizontal == TipoMovimento.Mouse) {

            // Pega a posicao do mouse em unidades do mundo
            float posicaoMovimento = (Input.mousePosition.x/Screen.width) * 16;

            // Nova posicao da nave
            Vector2 navePosition = new Vector2(0, transform.position.y);

            // limite da nave dentro do cenario
            navePosition.x = Mathf.Clamp(posicaoMovimento, 1.0f, 15.0f);

            // Atualiza a posicao da nave
            transform.position = navePosition;

        } else {
            // velocidadeLateral * Time.deltaTime * 60

            // velocidade de movimento da nave
            var velocidadeLateral = Input.GetAxis("Horizontal") * 16;

            // adiciona forca na nava
            //rb2d.AddForce( new Vector2(0, velocidadeLateral) );
            var navePosition = new Vector2(0, transform.position.y);

            navePosition.x = Mathf.Clamp(velocidadeLateral, 1.0f, 15.0f);

            if (velocidadeLateral != 0){
                //transform.position = (navePosition);
                rb2d.AddForce(navePosition);
            }
        }
    }


    /// <summary>
    /// Metodo chamado quando ha colisao com a nave.
    /// </summary>
    /// <param name="collision">Objeto que colidiu.</param>
    private void OnCollisionEnter2D(Collision2D collision){

        // verifica se colidiu com inimigo
        if (collision.transform.CompareTag("Inimigo")) {

            // toca o som de explosao
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
        }
    }

}
