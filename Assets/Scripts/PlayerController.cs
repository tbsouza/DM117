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

    [SerializeField]
    [Tooltip("Velocidade de movimento da nave")]
    [Range(5,20)]
    private int velocidadeMovimento;

    [SerializeField]
    [Tooltip("Movimento por teclado ou mouse")]
    private TipoMovimento movimentoHorizontal;

    private Rigidbody2D rb2d;


    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	

	// Update is called once per frame
	void Update () {
        movimentoNave();
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
        }
        else {

            // velocidade de movimento da nave
            var velocidadeLateral = Input.GetAxis("Horizontal") * velocidadeMovimento;

            // adiciona forca na nava
            rb2d.AddForce( new Vector2(velocidadeLateral, 0) );
        }

 
    }



}
