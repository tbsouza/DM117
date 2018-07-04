using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Classe do anuncio com recompensa
/// </summary>
public class AdControle : MonoBehaviour {

    [SerializeField]
    [Tooltip("Botao Novamente")]
    private Button botaoNovamente;


    private void Start(){
        Novamente();
    }


    /// <summary>
    /// Trata o botao para exibir o anuncio com recompensa
    /// </summary>
    public void Novamente() {
        
        if (botaoNovamente) {

            // inicia uma nova corotina
            StartCoroutine(ShowContinue(botaoNovamente));

#if UNITY_ADS
            // add click no mouse para chamar metodo que exibe anuncio
            botaoNovamente.onClick.AddListener(UnityAdControle.ShowAdReward);
#else
            botaoNovamente.gameObject.SetActive(false);
#endif
        }
    }

    /// <summary>
    /// Metodo para habilitar o botao de jogar novamente apos tempo e
    /// mostrar tempo para proximo anuncio.
    /// </summary>
    /// <param name="botaoNovamente">Botao Jogar Novamente</param>
    /// <returns></returns>
    public IEnumerator ShowContinue(Button botaoNovamente){

        // pega o texto do botao
        var btnText = botaoNovamente.GetComponentInChildren<Text>();

        while (true) {
            // verifica o tempo
            if (UnityAdControle.proxTempoReward.HasValue &&
               (DateTime.Now < UnityAdControle.proxTempoReward.Value))
            {

                // desabilita o botao Novamente
                botaoNovamente.interactable = false;

                // calcula o tempo restante
                TimeSpan restante = (UnityAdControle.proxTempoReward.Value - DateTime.Now);

                // formata a contagem regressiva
                var contagemRegressiva = String.Format("{0:D2}:{1:D1}", restante.Minutes, restante.Seconds);

                // altera o texto do botao
                btnText.text = contagemRegressiva;

                yield return new WaitForSeconds(1f);
            } else {
                // habilita o botao Novamente
                botaoNovamente.interactable = true;

                botaoNovamente.onClick.AddListener(UnityAdControle.ShowAdReward);

                // altera o texto do botao
                btnText.text = "Novamente (Ver Ad)";
                break;
            }
        }

    }
}
