using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleInimigos : MonoBehaviour
{

    private int qtdInimigos;
    [SerializeField]private int maxInimigos;

    // Start is called before the first frame update
    void Start()
    {
        qtdInimigos = 0;
        maxInimigos = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addInimigos(){
        qtdInimigos++;
    }

    public void RemoveInimigos(){
        qtdInimigos--;
    }

    public int getMaxInimigos(){
        return maxInimigos;
    }
    public int getqtdInimigos(){
        return qtdInimigos;
    }
}
