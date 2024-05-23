using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtiradorMira : MonoBehaviour
{
    
    //atributos para atirar
    public Transform alvo;
    public float DistAtaque;
    private float ultimoTiro;
    public float intervalo;

    private float distanciaJogador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        //Ataque
        
        //Verifica Distancia do Player
        distanciaJogador = Vector3.Distance(transform.position, alvo.position);

        if(distanciaJogador<DistAtaque){
            //virar para o alvo
            Vector3 direcaoAlvo = alvo.position - transform.position;
            float angulo = Mathf.Atan2(direcaoAlvo.y,direcaoAlvo.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angulo, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);
        }
    }
}
