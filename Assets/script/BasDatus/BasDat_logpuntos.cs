using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


public class BasDat_logpuntos : MonoBehaviour {

    public Text inputNOMOlog;
    public Text inputPASVlog;

    

    public GameObject pantalla_log;
    public GameObject pantalla_reg;
    public GameObject pantalla_inicial;

    //conector
    public GameObject conex;
    public GameObject inputslog;

    //Variables para comparacion de los datos en tabla sql
    string nomox;
    string pasvortox;
    int idx;
    string fechax;

    public static int idlog;
    public static string fechanac;

    //agarra inputs de los puntos
    public Text EsKorekto;
    public Text NoEsKorekto;

    string url = "http://localhost/colorludophp/conector.php";
    string url2 = "http://localhost/colorludophp/login.php";
    string url3 = "http://localhost/colorludophp/puntaje.php";

    string edad = BasDat_reg.idadex;



    // Use this for initialization
    void Start () {
        //StartCoroutine(Conector());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Conector()
    {
        UnityWebRequest net = UnityWebRequest.Get(url);
        yield return net.SendWebRequest();

        if (net.isNetworkError || net.isHttpError)
        {
            Debug.Log(net.error);
            print("erro");


        }
        else
        {
            Debug.Log("Conectou");
            print(net.downloadHandler.text); // retorno valor no php
        }
    }


    public void AgarrarReg()
    {
        
        StartCoroutine(Logar());

    }

    public void AgarrarPuntos()// metodo para insertar puntos
    {
        
        StartCoroutine(Puntajex());

    }

    //**************************

    IEnumerator Logar()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombree", inputNOMOlog.text);
        form.AddField("contrasenaa", inputPASVlog.text);

        UnityWebRequest net3 = UnityWebRequest.Post(url2, form);
        yield return net3.SendWebRequest();

        if (net3.isNetworkError || net3.isHttpError)
        {
            Debug.Log(net3.error);


        }
        else
        {
            
            Debug.Log("Logou");
            print(net3.downloadHandler.text); // retorno valor no php
            if (net3.downloadHandler.text == "logax")
            {
                print("bololodo");
                pantalla_log.SetActive(false);
                pantalla_reg.SetActive(false);
                pantalla_inicial.SetActive(true);
                DontDestroyOnLoad(conex);
                DontDestroyOnLoad(inputslog);
                //SceneManager.LoadScene("SampleScene");
            }

        }
    }

    //*****************************

    IEnumerator Puntajex() // novo modo de conex
    {
        WWWForm form = new WWWForm();
        form.AddField("corectoo", EsKorekto.text);
        form.AddField("incorectoo", NoEsKorekto.text);

        //form.AddField("edadd", edad);
        form.AddField("nombree", inputNOMOlog.text);
        form.AddField("contrasenaa", inputPASVlog.text);

        UnityWebRequest net = UnityWebRequest.Post(url3, form);
        yield return net.SendWebRequest();

        if (net.isNetworkError || net.isHttpError)
        {
            Debug.Log(net.error);
        }
        else
        {
            Debug.Log("Foi !");
        }
    }





}
