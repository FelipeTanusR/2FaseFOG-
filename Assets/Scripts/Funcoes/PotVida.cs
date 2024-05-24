using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotVida : MonoBehaviour
{

    [SerializeField] Rigidbody2D Corpo;
    [SerializeField] AudioClip Som;
    [SerializeField] ControleItens Itens;




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
        if(collision.gameObject.TryGetComponent<Vida>(out var Vida) && collision.gameObject.tag == "Player"){

            //cause dano e desaparece
            Vida.CuraCompleta();
            AudioSource.PlayClipAtPoint(Som, transform.position);
            Itens.RemovePots();
            Destroy(this.gameObject);

        }
        
        
    }
}
