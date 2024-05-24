using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleItens : MonoBehaviour
{

    private int qtdEstrelas;
    [SerializeField]private int maxEstrelas;
    private int qtdPots;
    [SerializeField]private int maxPots;

    // Start is called before the first frame update
    void Start()
    {
        qtdEstrelas = 0;
        qtdPots = 0;
        maxEstrelas = 4;
        maxPots = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addEstrelas(){
        qtdEstrelas++;
    }

    public void RemoveEstrelas(){
        qtdEstrelas--;
    }

    public int getMaxEstrelas(){
        return maxEstrelas;
    }
    public int getqtdEstrelas(){
        return qtdEstrelas;
    }
    public void addPots(){
        qtdPots++;
    }

    public void RemovePots(){
        qtdPots--;
    }

    public int getMaxPots(){
        return maxPots;
    }
    public int getqtdPots(){
        return qtdPots;
    }
}
