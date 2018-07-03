using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ADS
using UnityEngine.Advertisements;
using UnityEngine.Events;
#endif

public class UnityAdControle : MonoBehaviour {

    [Tooltip("Habilita anuncios no jogo")]
    [SerializeField]
    public static bool showAds = true;


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

    
}
