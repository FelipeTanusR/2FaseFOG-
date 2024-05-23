using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Pontos : MonoBehaviour
{

    //atributos da UI
   [SerializeField] TextMeshProUGUI HighScore;
   [SerializeField] TextMeshProUGUI T_pontuacao;
   //Valor da pontuacao
    public int pontuacao = 0;

    //Evento de ganhar ponto
    public Boolean TriggerPonto = false;
    public UnityEvent ganhouPonto;

    // Start is called before the first frame update
    void Start()
    {   
        //Recupera o HighScore
        HighScore.text = $"Highscore: {PlayerPrefs.GetInt("HighScore",0)}";
        
    }

    // Update is called once per frame
    void Update()
    {
        //Atualiza a pontuacao
        T_pontuacao.text = "Pontuação: " + pontuacao;

        //Trigger no evento de ganhou ponto
        if(TriggerPonto){
            ganhouPonto?.Invoke();
        }


        
    }

    
    //funcoes de manipulacao de pontos
    public void ganhou(int quantidade) => pontuacao += quantidade;

    public void reseta() => pontuacao = 0;

    public int getPontos(){
        return pontuacao;
    }


    //confere se o player bateu seu recorde
    public void verificaHighScore(){
        if(pontuacao > PlayerPrefs.GetInt("HighScore",0)){
            PlayerPrefs.SetInt("HighScore",pontuacao);
        }
    }


}
