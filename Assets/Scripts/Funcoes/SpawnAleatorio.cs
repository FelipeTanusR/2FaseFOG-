using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAleatorio : MonoBehaviour
{

    [SerializeField] GameObject Prefab;
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] ControleItens itens;
    [SerializeField] float TempoMin;
    [SerializeField] float TempoMax;
    [SerializeField] float raio;


    private float TempoAtual;

    [SerializeField] int tipo;



    // Start is called before the first frame update
    void Start(){
        TempoAtual = 5;
    }

    // Update is called once per frame
    void Update(){
        TempoAtual -= Time.deltaTime;

        if(TempoAtual<=0 && itens.getqtdEstrelas() < itens.getMaxEstrelas()&&tipo==1){
            
            Vector3 Posicao = transform.position + Random.insideUnitSphere * raio;
            Instantiate(Prefab,Posicao, Quaternion.identity);
            itens.addEstrelas();     
            setTempoAtual();
        }
        if(TempoAtual<=0 && itens.getqtdPots() < itens.getMaxPots()&&tipo==2){
            
            Vector3 Posicao = transform.position + Random.insideUnitSphere * raio;
            Instantiate(Prefab,Posicao, Quaternion.identity);
            itens.addPots();     
            setTempoAtual();
        }

    }

    private void setTempoAtual(){
        TempoAtual = Random.Range(TempoMin,TempoMax);
    }
}
