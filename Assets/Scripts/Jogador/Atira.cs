using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;


public class Atira : MonoBehaviour
{

    [SerializeField] private Rigidbody2D arma1;
    [SerializeField] private Rigidbody2D arma2;
    [SerializeField] private Movimento _Mov;
    [SerializeField] private float TempoEntreDisparos1 = 1;
    [SerializeField] private float TempoEntreDisparos2 = 4;
    [SerializeField] public AudioClip Tiro1;
    [SerializeField] public AudioClip Tiro2;
    [SerializeField] public AudioClip Troca1;
    [SerializeField] public AudioClip Troca2;





    private bool isArma1;


    private Rigidbody2D t,t1,t2,t3;
    private float ultimoTiro;


    public UnityEvent PuxarArma1;
    public UnityEvent PuxarArma2;



    // Start is called before the first frame update
    void Start(){
        ultimoTiro = Time.time;
        isArma1 = true;
        PuxarArma1?.Invoke();
    }

    // Update is called once per frame
    void Update(){
        ultimoTiro -= Time.deltaTime;

        if(isArma1){
            PuxarArma1?.Invoke();
            atirar1();
        }else{
            PuxarArma2?.Invoke();
            atirar2();
        }

        if(Input.GetButtonDown("SwitchGuns")){
            isArma1 = !isArma1;

            if(isArma1){
                AudioSource.PlayClipAtPoint(Troca1, transform.position);
            }else{
                AudioSource.PlayClipAtPoint(Troca2, transform.position);

            }
        }
        
    }

    public void atirar1(){
         if(Input.GetButtonDown("Fire1")&&Time.time >= TempoEntreDisparos1 + ultimoTiro){
             //Cria uma rota��o
            UnityEngine.Quaternion rotacao = new UnityEngine.Quaternion();
            //Define a rota��o em fun��o de graus (�)
            
            

            //define o lado que tiro vai sair com base na direcao q o personagem esta olhando
            
            if(!_Mov.FacingRight()){
                rotacao.eulerAngles = new UnityEngine.Vector3(0, 0, 180);
                t =  (Rigidbody2D)Instantiate(arma1, transform.position , rotacao);
            }else{
                rotacao.eulerAngles = new UnityEngine.Vector3(0, 0, 0);
                t =  (Rigidbody2D)Instantiate(arma1, transform.position , rotacao);
            }

            
            Physics2D.IgnoreCollision(t.GetComponent<Collider2D>(), _Mov.getCorpo().GetComponent<Collider2D>());
            ultimoTiro = Time.time;


            AudioSource.PlayClipAtPoint(Tiro1, transform.position);
        }
    }

    public void atirar2(){

        if(Input.GetButtonDown("Fire1")&&Time.time >= TempoEntreDisparos2 + ultimoTiro){
             //Cria uma rota��o
            UnityEngine.Quaternion rotacao = new UnityEngine.Quaternion();
            //Define a rota��o em fun��o de graus (�)
            
            

            //define o lado que tiro vai sair com base na direcao q o personagem esta olhando
            
            if(!_Mov.FacingRight()){
                rotacao.eulerAngles = new UnityEngine.Vector3(0, 0, 170);
                t1 =  (Rigidbody2D)Instantiate(arma2, transform.position , rotacao);
                rotacao.eulerAngles = new UnityEngine.Vector3(0, 0, 180);
                t2 =  (Rigidbody2D)Instantiate(arma2, transform.position , rotacao);
                rotacao.eulerAngles = new UnityEngine.Vector3(0, 0, 190);
                t3 =  (Rigidbody2D)Instantiate(arma2, transform.position , rotacao);


                


            }else{
                rotacao.eulerAngles = new UnityEngine.Vector3(0, 0, -10);
                t1 =  (Rigidbody2D)Instantiate(arma2, transform.position , rotacao);
                rotacao.eulerAngles = new UnityEngine.Vector3(0, 0, 0);
                t2 =  (Rigidbody2D)Instantiate(arma2, transform.position , rotacao);
                rotacao.eulerAngles = new UnityEngine.Vector3(0, 0, 10);
                t3 =  (Rigidbody2D)Instantiate(arma2, transform.position , rotacao);

        
            }
            //Impede a bala de colidir com o jogador e as outras balas do jogador
            Physics2D.IgnoreCollision(t1.GetComponent<Collider2D>(), _Mov.getCorpo().GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(t1.GetComponent<Collider2D>(), t2.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(t1.GetComponent<Collider2D>(), t3.GetComponent<Collider2D>());

            Physics2D.IgnoreCollision(t2.GetComponent<Collider2D>(), _Mov.getCorpo().GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(t2.GetComponent<Collider2D>(), t3.GetComponent<Collider2D>());

            Physics2D.IgnoreCollision(t3.GetComponent<Collider2D>(), _Mov.getCorpo().GetComponent<Collider2D>());
            ultimoTiro = Time.time;

            AudioSource.PlayClipAtPoint(Tiro2, transform.position);

        }
    }
}
/*




*/