using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontuaP1 : MonoBehaviour
{
    bool colidindo = false, contando = false;
    public KeyCode Consertar;
    float timer = 0;
    public GerenciadorPlacares gerenciador;
    public GameObject Chave;
    public Player player;
    float timing = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (colidindo && Input.GetKey(Consertar))
        {
            player.IniciarConserto(timing);
            gerenciador.PlayerPontuou(1);
            Chave.SetActive(true);
            colidindo = false;
        }
        else
        {
            Chave.SetActive(false);
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        //COZINHA
        if (collision.gameObject.tag == "10")
        {
            timing = 10 ;
        }
        else if (collision.gameObject.tag == "8")
        {
            timing = 8 ;
        }
        else if (collision.gameObject.tag == "6")
        {
            timing = 6 ;
        }
        //SALA
        else if (collision.gameObject.tag == "4")
        {
            timing = 4;
        }
      
        if (collision.gameObject.tag == "Objeto")
        {
            colidindo = true;
        }


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        colidindo = false;
        timing = 0;
    }

    
}
