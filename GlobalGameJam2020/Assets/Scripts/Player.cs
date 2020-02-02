using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode Esquerda, Direita, Pular, consertar;
    SpriteRenderer render;
    private Rigidbody2D rb2D;
    private Animator animacao;
    float horizontal, velocidadeD = 5f, velocidadeE = -5f;
    public bool noChao = false, naPorta=false;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        //CHAMA AS FUNÇÕES 
        Movimentar();
        Pulo();
    }

    void Movimentar()
    {//MOVE ESQUERDA
        if (Input.GetKey(Esquerda))
        {
            rb2D.velocity = new Vector2(velocidadeE, rb2D.velocity.y);
            render.flipX = true;
        }
        
        //MOVE DIREITA
        if (Input.GetKey(Direita))
        {
            rb2D.velocity = new Vector2(velocidadeD, rb2D.velocity.y);
            render.flipX = false;            
        }

        if (Input.GetKey(Direita) || Input.GetKey(Esquerda))
        {
            animacao.SetBool("Andando", true);
        }
        else
        {
            animacao.SetBool("Andando", false);
        }

        if (Input.GetKey(consertar))
        {
            animacao.SetBool("Construindo", true);
        }
        else
        {
            animacao.SetBool("Construindo", false);
        }

        if (!noChao || Input.GetKey(Pular))
        {
            animacao.SetBool("Pulando", true);
        }
        else
        {
            animacao.SetBool("Pulando", false);
        }
    }

    void Pulo()
    {//PULA
        if (Input.GetKeyDown(Pular) && noChao && !naPorta)
        {
            rb2D.AddForce(new Vector2(0f, 9f), ForceMode2D.Impulse);
            animacao.SetBool("Pulando", true);
        }
        else
        {
            animacao.SetBool("Pulando", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Porta")
        {
            naPorta = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Porta")
        {
            naPorta = false;
        }
    }
}
