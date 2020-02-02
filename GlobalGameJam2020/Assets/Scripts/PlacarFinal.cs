using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlacarFinal : MonoBehaviour
{   //VARIAVEIS DE TEXTO DA CENA
    public Text PlacarP1, PlacarP2, StatusP1, StatusP2;
    //INTEIROS PARA RECEBER OS PONTOS DA CENA ANTERIOR
    int P1pontos, P2pontos;

    void Start()
    {//RECUPERA OS VALORES DE PONTUAÇÃO DA CENA ANTERIOR
        P1pontos = PlayerPrefs.GetInt("PontosPlayer1");
        P2pontos = PlayerPrefs.GetInt("PontosPlayer2");
    }

    void Update()
    {//PASSA PARA A CENA ATUAL AS PONTUAÇÕES
        PlacarP1.text = P1pontos.ToString();
        PlacarP2.text = P2pontos.ToString();
        //CHECA QUAL PLAYER FEZ MAIS PONTOS E ESCREVE NA TELA
        if (P1pontos>P2pontos)
        {
            StatusP1.text = "GANHOU";
            StatusP2.text = "PERDEU";
        }
        else if (P1pontos < P2pontos)
        {
            StatusP1.text = "PERDEU";
            StatusP2.text = "GANHOU";
        }
        else
        {
            StatusP1.text = "EMPATE";
            StatusP2.text = "EMPATE";
        }
    }
}
