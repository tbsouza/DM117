using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Classe para controlar o Player (nave)
/// </summary>
public class PlayerController : MonoBehaviour {

    [SerializeField]
    [Tooltip("Velocidade de movimento da nave")]
    [Range(1,10)]
    private float velocidadeMovimento = 1;

    // Referencia para o componente rigidbody do Player
    private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {

        // Pega o rb do Player
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

        // Pega a direcao do movimento (Esq ou Dir) 
        var velocidade = Input.GetAxis("Horizontal") * velocidadeMovimento;

        // Adiciona forca na direcao do movimento desejado
        rb2d.AddForce(new Vector2(velocidade, 0));





    }


}
