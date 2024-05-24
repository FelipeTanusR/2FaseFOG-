using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanhaPontos : MonoBehaviour
{
    // Start is called before the first frame update

    int quantidade = 30;
    private Pontos pontos;
    void Start()
    {
        pontos = GameObject.Find("Game Manager").GetComponent<Pontos>();
        pontos.ganhou(quantidade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
