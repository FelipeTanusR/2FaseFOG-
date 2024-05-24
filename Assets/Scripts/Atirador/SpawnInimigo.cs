using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigo : MonoBehaviour
{
    [SerializeField] GameObject SpawnPoint;
    [SerializeField] GameObject InimigoPrefab;
    [SerializeField] ControleInimigos cont;
    [SerializeField] float TempoMin;
    [SerializeField] float TempoMax;

    private float TempoAtual;



    // Start is called before the first frame update
    void Start(){
        setTempoAtual();
        TempoAtual = 1;
    }

    // Update is called once per frame
    void Update(){   
        TempoAtual -= Time.deltaTime;

        if(TempoAtual<=0 && cont.getqtdInimigos() < cont.getMaxInimigos()){
            
            GameObject inimigo = Instantiate(InimigoPrefab, transform.position, Quaternion.identity);
            InimigoSegue seguir = inimigo.GetComponent<InimigoSegue>();
            cont.addInimigos();
           
            setTempoAtual();
        }
        
    }

    
    


    private void setTempoAtual(){
        TempoAtual = Random.Range(TempoMin,TempoMax);
    }
}
