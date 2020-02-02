using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controladorCenaTutorial : MonoBehaviour
{
    public bool prontoP1, prontoP2;
    string nomeCena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (prontoP1 == true && prontoP2 == true)
        {
            //SceneManager.LoadScene(nomeCena);
            Debug.Log("Trocou de cena (Começou o jogo)");
        }
    }
}
