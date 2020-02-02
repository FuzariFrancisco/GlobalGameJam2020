using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GerenciadorPlacares : MonoBehaviour
{
    public Text PlacarP1, PlacarP2, Tempo;
    float timer, startTime = 5000;
    public int pontosP1, pontosP2;

    void Start()
    {//TEMPORÁRIO
        pontosP1 = 5;
        pontosP2 = 5;
        PlayerPrefs.SetInt("PontosPlayer1", pontosP1);
        PlayerPrefs.SetInt("PontosPlayer2", pontosP2);
        //DEFINE O TEMPO INICIAL 
        timer = startTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        //SE A CONTAGEM CHEGAR A ZERO PASSA PARA A CENA FINAL
        if (timer <= 0)
        {
            SceneManager.LoadScene("FimDeJogo");
        }
        //PEGA OS VALORES DE MINUTOS E SEGUNDOS
        float minutes = Mathf.Floor(timer / 60);
        float seconds = Mathf.RoundToInt(timer % 60);

        //FORMATA O TEMPORIZADOR NA TELA
        if (timer > 0)
        {
            if (minutes < 3)
            {
                minutes = Single.Parse("0" + minutes.ToString());
            }
            if (seconds < 10)
            {
                seconds = Single.Parse("0" + Mathf.RoundToInt(seconds).ToString());
            }
        }
        //EXIBE O TEMPORIZADOR NA TELA
        Tempo.text = minutes + ":" + seconds;
        //MOSTRA A PONTUAÇÃO ATUAL DOS PLAYERS
        PlacarP1.text = "PONTOS:" + pontosP1.ToString();
        PlacarP2.text = "PONTOS:" + pontosP2.ToString();

    }

    //FUNÇÃO DE PONTUAÇÃO DOS PLAYERS
    public void PlayerPontuou(int Player)
    {       
        if (Player == 1)
        {
            pontosP1++;
            SalvarPontos();
        }
        else if (Player == 2)
        {
            pontosP2++;
            SalvarPontos();
        }
    }

    //SALVA A PONTUAÇÃO FINAL PARA SER RESGATADA NA PROXIMA CENA
    public void SalvarPontos()
    {
        PlayerPrefs.SetInt("PontosPlayer1", pontosP1);
        PlayerPrefs.SetInt("PontosPlayer2", pontosP2);
    }
}
