using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Ctrl_Dialog : MonoBehaviour {
    public Text campoMsg;
    public Text CampoNome;
    string[] txtfalas;
    public float espera;
    Global script;
    Mov_Player MovPlayer;
    Col_Player colPlayer;
    public GameObject WindowDialog;

    bool ultimo;
    bool TerminouEscrita = false;
    int  idAtual = 0;
    void Start()
    {
        script = FindObjectOfType(typeof(Global)) as Global;
        MovPlayer = FindObjectOfType(typeof(Mov_Player)) as Mov_Player;
        colPlayer = FindObjectOfType(typeof(Col_Player)) as Col_Player;
    }

    public void Iniciar(string QualNpc)
    {
        //Time.timeScale = 1f;
        switch (QualNpc)
        {
           
            case "Npc1":
                CampoNome.text = script.npc[0].nome.ToString();
                txtfalas = script.npc[0].falasPersonagem;          
            break;

            case "Npc2":
                CampoNome.text = script.npc[1].nome.ToString();
                txtfalas = script.npc[1].falasPersonagem;              
                break;


        }
        idAtual = 0;
        TerminouEscrita = false;
        WindowDialog.SetActive(true);
        StartCoroutine("soletrar", txtfalas[0]);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && colPlayer.colidiuNpc && TerminouEscrita)
        {
            if (idAtual >= txtfalas.Length)
            {
                MovPlayer.StopMoviment = false;
                WindowDialog.SetActive(false);
            }
            else
            {
                StartCoroutine("soletrar", txtfalas[idAtual]);

            }
        }
    }

   IEnumerator soletrar(string texto)
    {
        idAtual++;
        int letras = 0;
        campoMsg.text = "";
        while (letras <= texto.Length - 1)
        {
            campoMsg.text += texto[letras];
            letras += 1;
            MovPlayer.StopMoviment = true;
            TerminouEscrita = false;
            yield return new WaitForSeconds(espera);
            TerminouEscrita = true;
           
        }
        //WindowDialog.SetActive(false);
    }

}
