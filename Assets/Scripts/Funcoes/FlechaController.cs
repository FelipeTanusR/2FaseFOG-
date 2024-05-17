using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaController : MonoBehaviour
{
    //Velocidade da flecha
    [SerializeField] private float Velocidade;

    void Update()
    {
        //Move a flecha na dire��o � sua direita
        //O Time.deltaTime faz a velocidade adaptar � taxa de fps do jogo,
        //assim mantendo a velocidade constante em computadores de desempenho diferentes
        transform.transform.position += transform.right * Velocidade * Time.deltaTime;
    }

    //Ao colidir
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //verifica se o objeto possui o atributo "vida"
        if(collision.gameObject.TryGetComponent<Vida>(out var Vida)){

            //cause dano
            Vida.Dano(20);
            OnBecameInvisible();

        }
        
        
    }

    //Ao sair do campo de vis�o de todas as c�meras
    private void OnBecameInvisible()
    {
        //Destr�i a flecha
        Destroy(this.gameObject);
    }
}
