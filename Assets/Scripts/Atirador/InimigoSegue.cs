using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class InimigoSegue : MonoBehaviour
{

    [SerializeField]public float velocidade;
    [SerializeField]public float campoDeVisao;
    [SerializeField]public float DistanciaTiro;



    //variaveis para movimentar
    [SerializeField] Rigidbody2D corpo;
    private bool isFacingRight;
    private float distanciaJogador;
    private float TempoVirar;
    private int lado;



    //variaveis da flecha
    [SerializeField] public Rigidbody2D Imune;
    //Prefab para criar
    [SerializeField] private Rigidbody2D FlechaPrefab;
    [SerializeField] public AudioClip SomTiro;

    
    private Rigidbody2D tiro;
    
    //Intervalo entre as flehcasflehcas
    [SerializeField] private float Intervalo;
    //Para saber quando pode atirar
    private float UltimoTiro = 0;


    private Transform jogador;

    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
        isFacingRight = true;
        TempoVirar=0;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(TempoVirar <= 0){
            lado = Random.Range(1,3);

            TempoVirar = Random.Range(1,4);
        }

        distanciaJogador = Vector2.Distance(jogador.position,transform.position);


        if(distanciaJogador>campoDeVisao){
            andaPorAi();
        }else{
            PersegueJogador();
        }

        DirecaoOlhando();

        TempoVirar -= Time.deltaTime;

    }




    public void DirecaoOlhando(){
        Vector3 localScale = transform.localScale;
        if(isFacingRight){
            localScale.x = 1f;
            transform.localScale = localScale;
        }else{
            
            localScale.x = -1f;
            transform.localScale = localScale;
        }
    }

    public void PersegueJogador(){
        
        //Anda para a direcao do jogador
        if(distanciaJogador<campoDeVisao && distanciaJogador>DistanciaTiro){      
            transform.position = Vector2.MoveTowards(this.transform.position, jogador.position, velocidade * Time.deltaTime);
        }
        //atira
        else if (distanciaJogador<=DistanciaTiro){
            if(Time.time >= Intervalo + UltimoTiro){

                Vector3 direcaoAlvo = jogador.position - transform.position;
                float angulo = Mathf.Atan2(direcaoAlvo.y,direcaoAlvo.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angulo, Vector3.forward);

                //Instancia a flecha apontando para o jogador
                tiro = (Rigidbody2D)Instantiate(FlechaPrefab, transform.position, q);
                Physics2D.IgnoreCollision(tiro.GetComponent<Collider2D>(), Imune.GetComponent<Collider2D>());

                //Salva o momento do tiro
                UltimoTiro = Time.time;

                AudioSource.PlayClipAtPoint(SomTiro, transform.position);


            }
        }

        if(transform.position.x<jogador.position.x){
            isFacingRight = true;
        }else{
            isFacingRight = false;
        }

    }


    public void andaPorAi(){
        switch(lado){   
            case 1:
                transform.position = transform.position + new Vector3(velocidade*Time.deltaTime,0,0);
                isFacingRight = true;
            break;
            case 2:
                isFacingRight = false;
                transform.position = transform.position - new Vector3(velocidade*Time.deltaTime,0,0);
            break;
        }
        

    }




}
