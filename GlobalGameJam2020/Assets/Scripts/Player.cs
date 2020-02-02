using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode Esquerda, Direita, Pular, consertar;
    SpriteRenderer render;
    Rigidbody2D rb2D;
    Animator animacao;
    float horizontal, velocidadeD = 5f, velocidadeE = -5f, tempo = 0;
    public bool noChao = false, naPorta=false, consertando = false;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
        render.flipX = true;
    }

    void FixedUpdate()
    {
        if (!consertando)
        {
            animacao.SetBool("Construindo", false);
            GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            GetComponent<BoxCollider2D>().isTrigger = false;
            Movimentar();
            Pulo();
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            tempo -= Time.deltaTime;
            animacao.SetBool("Construindo", true);
            GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            GetComponent<BoxCollider2D>().isTrigger = true;
            if (tempo <= 0)
            {
                consertando = false;
            }
        }
        //CHAMA AS FUNÇÕES 
        
        
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
    }

    void Pulo()
    {//PULA
        if (Input.GetKeyDown(Pular) && noChao && !naPorta)
        {
            rb2D.AddForce(new Vector2(0f, 9f), ForceMode2D.Impulse);
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

    public void IniciarConserto(float timing)
    {
        tempo = timing;
        consertando = true;
    }

}
