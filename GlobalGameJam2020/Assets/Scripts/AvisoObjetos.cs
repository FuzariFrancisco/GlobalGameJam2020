using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvisoObjetos : MonoBehaviour
{
    float timer = 0, velocidade = 0.05f;

    void Update()
    {
        this.transform.Translate(Vector3.up * velocidade);

        timer += Time.deltaTime;

        if (timer >= 0.1)
        {
            velocidade = velocidade * -1;
            timer = 0;
        }
    }
}
