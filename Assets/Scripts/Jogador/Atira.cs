using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Atira : MonoBehaviour
{

    [SerializeField] private Rigidbody2D tiro;
    [SerializeField] public Rigidbody2D Imune;
    private Rigidbody2D t;
    [SerializeField] private Movimento _Mov;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
        if(Input.GetButtonDown("Fire1")){
             //Cria uma rota��o
            UnityEngine.Quaternion rotacao = new UnityEngine.Quaternion();
            //Define a rota��o em fun��o de graus (�)
            
            rotacao.eulerAngles = new UnityEngine.Vector3(0, 0, 0);

            //define o lado que tiro vai sair com base na direcao q o personagem esta olhando
            
            if(!_Mov.FacingRight()){
                rotacao.eulerAngles = new UnityEngine.Vector3(0, 0, 180);
                t =  (Rigidbody2D)Instantiate(tiro, transform.position , rotacao);
            }else{
                
                t =  (Rigidbody2D)Instantiate(tiro, transform.position , rotacao);
            }

            
            Physics2D.IgnoreCollision(t.GetComponent<Collider2D>(), Imune.GetComponent<Collider2D>());
           
        }


    }
}
