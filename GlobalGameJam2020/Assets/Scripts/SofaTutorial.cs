using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaTutorial : MonoBehaviour
{
    public bool checkSofa, sofaQuebrado;
    private Animator animacao;
    // Start is called before the first frame update
    void Start()
    {
        animacao = GetComponent<Animator>();
        sofaQuebrado = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (sofaQuebrado == true)
        {
            animacao.SetBool("SofaQuebrado", true);
        }
        else
        {
            animacao.SetBool("SofaQuebrado", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            checkSofa = true;
        }
    }


}
