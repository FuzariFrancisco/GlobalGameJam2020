using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecaChao : MonoBehaviour
{
    GameObject Player;

    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }
    //CHECA SE O PLAYER ESTA COLIDINDO COM O CHÃO OU NÃO E PASSA PARA O SCRIPT PRINCIPAL DO PLAYER
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chao")
        {
            Player.GetComponent<Player>().noChao = true;
        }
    }
    //CHECA SE O PLAYER DEIXOU DE COLIDIR COM O CHÃO OU NÃO E PASSA PARA O SCRIPT PRINCIPAL DO PLAYER
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Chao")
        {
            Player.GetComponent<Player>().noChao = false;
        }
    }
}
