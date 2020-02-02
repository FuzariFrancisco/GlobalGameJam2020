using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTutorial2 : MonoBehaviour
{
    public KeyCode Esquerda, Direita, Pular, consertar;
    SpriteRenderer render;
    private Rigidbody2D rb2D;
    private Animator animacao;
    float horizontal, velocidadeD = 5f, velocidadeE = -5f, tempoAnim;
    public bool noChao = false, naPortaTuto=false,jogador1=false, jogador2=false, andarR, andarL, checkpular, checkConcerto, player2Pronto, checkSofa, checkPortaTutorial, checkAnimConcerto;
    public bool[] tutorial;
    public GameObject[] objTutorial;
    public GameObject objSofa, colisaoFim, painelFim;
    public SofaTutorial sofaTutorial;
    public PortaTutorial portaTutorial;
    public controladorCenaTutorial controladorCenaTutorial;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
        tutorial[0] = true;
        checkSofa = false;
    }

    void FixedUpdate()
    {
        //CHAMA AS FUNÇÕES
        if (checkAnimConcerto == false)
        {
            Movimentar();
            Pulo();
        }
      
        TutorialControle();

        if (player2Pronto == true)
        {
            painelFim.SetActive(true);
            controladorCenaTutorial.prontoP2 = true;
        }

        if (checkAnimConcerto == true)
        {
            tempoAnim -= Time.deltaTime;

            if (tempoAnim <= 0)
            {
                animacao.SetBool("Construindo", false);
                checkAnimConcerto = false;
            }
        }
    }

    void Movimentar()
    {//MOVE ESQUERDA
        if (Input.GetKey(Esquerda))
        {
            rb2D.velocity = new Vector2(velocidadeE, rb2D.velocity.y);
            render.flipX = true;
            andarL = true;
        }
        
        //MOVE DIREITA
        if (Input.GetKey(Direita))
        {
            rb2D.velocity = new Vector2(velocidadeD, rb2D.velocity.y);
            render.flipX = false;
            andarR = true;
        }

        if (Input.GetKey(Direita) || Input.GetKey(Esquerda))
        {
            animacao.SetBool("Andando", true);
        }
        else
        {
            animacao.SetBool("Andando", false);
        }

        if (Input.GetKey(consertar) && tempoAnim <= 0)
        {
            animacao.SetBool("Construindo", true);
            checkConcerto = true;
            checkAnimConcerto = true;
            tempoAnim = 2;
        }
        

        if (!noChao || Input.GetKey(Pular))
        {
            animacao.SetBool("Pulando", true);
        }
        else
        {
            animacao.SetBool("Pulando", false);
        }

        if (Input.GetKeyDown(Pular) && naPortaTuto == true)
        {
            player2Pronto = true;
        }
    }

    void Pulo()
    {//PULA
        if (Input.GetKeyDown(Pular) && noChao == true && !naPortaTuto)
        {
            rb2D.AddForce(new Vector2(0f, 9f), ForceMode2D.Impulse);
            animacao.SetBool("Pulando", true);
            checkpular = true;
        }
        else
        {
            animacao.SetBool("Pulando", false);
        }
    }

    //FUNCAO QUE CONTROLA O TUTORIAL;
    public void TutorialControle()
    {
        if (tutorial[0] == true)
        {
            objTutorial[0].SetActive(true);

            if (andarR == true && andarL == true) 
            {
                tutorial[1] = true;
                tutorial[0] = false;
            }
        }

        else if (tutorial[1] == true)
        {
            objTutorial[1].SetActive(true);
            objTutorial[0].SetActive(false);


            if (checkpular == true)
            {
                tutorial[1] = false;
                tutorial[2] = true;
            }
        }

        else if (tutorial[2] == true)
        {
            objTutorial[2].SetActive(true);
            objTutorial[1].SetActive(false);
            objSofa.SetActive(true);
            if (checkSofa == true)
            {
                tutorial[3] = true;
                tutorial[2] = false;
            }
        }
        else if (tutorial[3] == true)
        {
            objTutorial[3].SetActive(true);
            objTutorial[2].SetActive(false);

            if (checkConcerto == true)
            {
                tutorial[4] = true;
                tutorial[3] = false;
            }
        }

        else if (tutorial[4] == true)
        {

            objTutorial[4].SetActive(true);
            objTutorial[3].SetActive(false);
            sofaTutorial.sofaQuebrado = false;
            colisaoFim.SetActive(false);

            if (checkPortaTutorial == true)
            {
                tutorial[5] = true;
                tutorial[4] = false;
            }
        }

        else if (tutorial[5] == true)
        {
            objTutorial[4].SetActive(false);
            objTutorial[5].SetActive(true);
        }


    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            noChao = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            noChao = false;
        }

        if (collision.gameObject.CompareTag("Porta"))
        {
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Porta")
        {
            naPortaTuto = true;
            checkPortaTutorial = true;
        }

        if (collision.gameObject.tag == "SofaQuebrado")
        {
            checkSofa = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Porta")
        {
            naPortaTuto = false;
        }
    }
}
