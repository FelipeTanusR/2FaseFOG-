using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControladorDoJogo : MonoBehaviour
{
    //Pega o Canvas da UI de morte
    [SerializeField] GameObject Canvas;
    [SerializeField]


    public void Morreu()
    {
        //Para o tempo e ativa o Canvas
        Canvas.gameObject.SetActive(true);

        Time.timeScale = 0.0f;
    }

   
}
