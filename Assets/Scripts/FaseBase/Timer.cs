using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;


public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI TempoUI;
    private float tempo = 0;

    private bool isRunning;



    // Start is called before the first frame update
    void Start()
    {
        TempoUI = GetComponent<TextMeshProUGUI>();
        isRunning = true;
        
    }

    // Update is called once per frame
    void Update(){
        if(!isRunning){
            return;
        }
        tempo += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(tempo);
        TempoUI.text = timeSpan.ToString(@"mm\:ss\:ff");
    }
    public void StopTimer(){
        isRunning = false;
    }
    public void StartTimer(){
        isRunning = true;
    }
    public void ResetTimer(){
        tempo = 0;
    }

    
}
