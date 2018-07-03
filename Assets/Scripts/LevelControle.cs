using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Classe para controle do jogo.
/// </summary>
public class LevelControle : MonoBehaviour {

    /// <summary>
    /// Função para carregar um Level a partir de seu nome
    /// </summary>
    /// <param name="sceneNome">Nome da cena a ser carregada</param>
	public void CarregaLevel(string sceneNome) {
        //TODO - zera pontuação
        SceneManager.LoadScene(sceneNome);

#if UNITY_ADS
        // verifica se está indo para a tela de gameover ou de inicio
        if (sceneNome.Equals("TelaInicial") || sceneNome.Equals("TelaGameOver")){
            if (UnityAdControle.showAds){
                // exibe anuncio simples
                UnityAdControle.ShowAds();
            }
        }
#endif

    }

    /// <summary>
    /// Carrega o próximo Level a partir do atual.
    /// </summary>
    public void CarregaProxLevel() {
        
        // Número da cena atual
        int numCena = SceneManager.GetActiveScene().buildIndex;

        // Carrega próxima cena
        SceneManager.LoadScene(numCena + 1);
    }

}
