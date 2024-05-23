using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoSegue : MonoBehaviour
{

    [SerializeField]public float velocidade;
    [SerializeField]public float campoDeVisao;
    [SerializeField]public float DistanciaTiro;

    [SerializeField] public Rigidbody2D Imune;

    //Prefab para criar
    [SerializeField] private Rigidbody2D FlechaPrefab;
    
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
    }

    // Update is called once per frame
    void Update()
    {
        float distanciaJogador = Vector2.Distance(jogador.position,transform.position);
        if(distanciaJogador<campoDeVisao && distanciaJogador>DistanciaTiro){
            transform.position = Vector2.MoveTowards(this.transform.position, jogador.position, velocidade * Time.deltaTime);
        }else if (distanciaJogador<=DistanciaTiro){
            if(Time.time >= Intervalo + UltimoTiro){

            Vector3 direcaoAlvo = jogador.position - transform.position;
            float angulo = Mathf.Atan2(direcaoAlvo.y,direcaoAlvo.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angulo, Vector3.forward);

            //Instancia a flecha apontando para o jogador
            tiro = (Rigidbody2D)Instantiate(FlechaPrefab, transform.position, q);
            Physics2D.IgnoreCollision(tiro.GetComponent<Collider2D>(), Imune.GetComponent<Collider2D>());

            //Salva o momento do tiro
            UltimoTiro = Time.time;

        }
        }
    }
}
