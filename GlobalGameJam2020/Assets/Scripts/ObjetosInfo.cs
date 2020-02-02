using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosInfo : MonoBehaviour
{
    public GameObject Aviso, Painel;
    
    public float tempoConserto = 1;
    Animator animacao;
    bool colidindo = false;

    void Start()
    {
        animacao = GetComponent<Animator>();
        Aviso.SetActive(false);
        Painel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            colidindo = true;
            Aviso.SetActive(true);
            Painel.SetActive(true);
        }
        if (collision.gameObject.tag == "Chave")
        {
            this.transform.tag = "Usado";
            MudaAnimacao();
            
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        colidindo = false;
        Aviso.SetActive(false);
        Painel.SetActive(false);
    }

    

    public void MudaAnimacao()
    {
        animacao.SetBool("Quebrado", false);
    }

}
