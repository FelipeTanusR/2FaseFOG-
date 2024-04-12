using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    [SerializeField] private float Velocidade, AlturaPulo;
    //O corpo do jogador
    [SerializeField] private Rigidbody2D Corpo;
    //Para ele n�o pular infinitamente
    private bool PodePular = true;

    void Update()
    {
        //Se a barra de espa�o foi pressionada e o jogador pode pular
        if(Input.GetKeyDown(KeyCode.Space) && PodePular)
        {
            //Adiciona uma for�a para cima proporcional � AlturaPulo
            Corpo.AddForce(new Vector2(0, AlturaPulo));
            //Pro�be o jogador de pular
            PodePular = false;
        }
        //Define a velocidade do corpo baseada na tecla pressionada (Input.GetAxisRaw("Horizontal"))
        //A fun��o retorna 1 se a seta pra direita ou D foram pressionados
        //Retorna 0 se a seta da esquerda ou A foram pressionados
        //Neste caso, n�o se usa Time.deltaTime, porque RigidBody2D.velocity j� opera baseado na taxa de frames
        Corpo.velocity = new Vector2(Velocidade * Input.GetAxisRaw("Horizontal"), Corpo.velocity.y);
    }

    //Fun��o para ser chamada pela base
    public void PermitirPulo()
    {
        PodePular = true;
    }
}
