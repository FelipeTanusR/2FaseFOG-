using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estrela : MonoBehaviour
{

    [SerializeField] Rigidbody2D Corpo;
    [SerializeField] AudioClip Som;
    [SerializeField] Pontos pontos;
    [SerializeField] ControleItens itens;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    





     private void OnCollisionEnter2D(Collision2D collision){
        //verifica se o objeto possui o atributo "vida"
        if(collision.gameObject.TryGetComponent<Vida>(out var vida)&& collision.gameObject.tag == "Player"){

            //cause dano e desaparece
            pontos.ganhou(50);
            AudioSource.PlayClipAtPoint(Som, transform.position);
            Destroy(this.gameObject);
            itens.RemoveEstrelas();

        }
        
        
    }
}
