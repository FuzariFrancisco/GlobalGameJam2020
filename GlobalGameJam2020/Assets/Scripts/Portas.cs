using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas : MonoBehaviour
{
    public GameObject[] porta;

    bool check = false, contar = false;
    public KeyCode cima, baixo;
    int andar;
    float timer=0;

    void Start()
    {
        andar = 0;
    }

    void Update()
    {
        if (andar>=4)
        {
            andar = 3;
        }
        if (andar < 0)
        {
            andar = 0;
        }


        if (contar)
        {
            timer += Time.deltaTime;
            if (timer>=1)
            {
                contar = false;
            }
        }

        if (check && !contar && Input.GetKeyDown(cima))
        {
            if(andar >= 0 && andar <=2)
            {
                andar++; 
                this.transform.position = new Vector2(porta[andar].transform.position.x+3, porta[andar].transform.position.y);
                contar = true;
            }
        }

        if (check && !contar && Input.GetKeyDown(baixo))
        {
            if (andar <=3 && andar >= 1)
            {
                andar--;
                this.transform.position = new Vector2(porta[andar].transform.position.x + 3, porta[andar].transform.position.y);
                contar = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Porta")
        {
            check = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        check= false;
    }
}
