using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesController : MonoBehaviour
{
    public GameObject painelIdiomas, painelCreditos;

    public void FecharAplicativo()
    {
        Application.Quit();
    }

    public void CarregaJogo()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void CarregaFimDeJogo()
    {
        SceneManager.LoadScene("FimDeJogo");
    }

    public void CarregaMenuInicial()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    public void AbrePainelCreditos()
    {

        painelCreditos.SetActive(true);
    }

    public void AbrePainelIdiomas()
    {

        painelIdiomas.SetActive(true);
    }

    public void FechaPainelCreditos()
    {
        GameObject painel = GameObject.Find("PainelCreditos");
        painel.SetActive(false);
    }

    public void FechaPainelIdiomas()
    {
        GameObject painel = GameObject.Find("PainelIdiomas");
        painel.SetActive(false);
    }
}
