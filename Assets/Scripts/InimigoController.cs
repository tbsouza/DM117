using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Classe para controlar o sapwn dos abacaxis no jogo
/// </summary>
public class InimigoController : MonoBehaviour {

    [Tooltip("Referencia para o obstaculo (abacaxi)")]
    [SerializeField]
    private Transform obstaculo;

    [Header("Spawn")]
    [Tooltip("Velocidade de spawn dos obstaculos")]
    [Range(0.8f, 3.0f)]
    [SerializeField]
    private float spawnSpeed = 3.0f;

    [Tooltip("Tempo de espera para o primeiro spawn")]
    [Range(0.5f, 1.5f)]
    [SerializeField]
    private float spawnDelay = 1.0f;

    // Lista de spawn points
    private List<GameObject> listSpawn;

    // GO com os sapwn points
    private GameObject spawns;


    // Use this for initialization
    void Start () {
        
        listSpawn = new List<GameObject>();

        // Pega o GO spawns
        spawns = GameObject.FindGameObjectWithTag("spawns");

        // percorre seus filhos procurando por posnto de spawn
        foreach ( Transform filho in spawns.transform ) {

            // adiciona o ponto de spawn na lista
            if (filho.CompareTag("ObstaculoSpawn")) {
                listSpawn.Add(filho.gameObject);
            }
        }

        invocaObstaculos();
    }


    /// <summary>
    /// Metodo para chamar a criação de obstaculos
    /// </summary>
    private void invocaObstaculos(){

        // Após spawnDelay segundos, chama repetidamente 
        // o metodo a cada spawnSpeed segundos
        InvokeRepeating("instantiateObstaculo", spawnDelay, spawnSpeed);
    }

    /// <summary>
    /// Metodo para instanciar obstaculos nos spawn points
    /// </summary>
    private void instantiateObstaculo(){

        // pega um spawn point aleatorio
        var pontoSpawn = listSpawn[ UnityEngine.Random.Range(0, listSpawn.Count) ];

        // posicao do ponto
        var spawnPos = pontoSpawn.transform.position;

        // instancia o novo obstaculo
        var novoObstaculo = Instantiate(obstaculo, spawnPos, Quaternion.identity);

        // torna o obstaculo filho do spawn point
        novoObstaculo.SetParent(pontoSpawn.transform);
    }
}


