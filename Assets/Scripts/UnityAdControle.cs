using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ADS
using UnityEngine.Advertisements;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
#endif

public class UnityAdControle : MonoBehaviour {

    [Tooltip("Habilita anuncios no jogo")]
    [SerializeField]
    public static bool showAds = true;

    //Tempo de espera do anuncio de recompensa
    public static int tempoEsperaAd = 20;

    // var oara controlar o tempo do anuncio
    public static DateTime? proxTempoReward = null;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    /// <summary>
    /// Metodo para mostrar o anuncio simples
    /// </summary>
    public static void ShowAds() {

#if UNITY_ADS
        if (Advertisement.IsReady()){
            Advertisement.Show();
        }
#endif
    }


    /// <summary>
    /// Metodo que mostra o anuncio de recompensa.
    /// </summary>
    public static void ShowAdReward() {
#if UNITY_ADS

        // adiciona um tempo para o proximo anuncio
        proxTempoReward = DateTime.Now.AddSeconds(tempoEsperaAd);

        // verifica se o anuncio esta pronto para exibir
        if (Advertisement.IsReady()) {

            var opt = new ShowOptions{
                resultCallback = TratarResultado
            };

            Advertisement.Show(opt);
        }
#endif
    }


    /// <summary>
    /// Metodo para tratar o resultado do anuncio
    /// </summary>
    /// <param name="result">Resultado do anuncio</param>
 #if UNITY_ADS
    public static void TratarResultado( ShowResult result ) {

        switch (result){
            case ShowResult.Finished:
                SceneManager.LoadScene("Fase");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad skipped");
                break;
            case ShowResult.Failed:
                Debug.Log("Ad failed");
                break;
        }
      
    }
#endif

}
