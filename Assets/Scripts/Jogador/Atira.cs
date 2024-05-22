using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Atira : MonoBehaviour
{

    [SerializeField] private GameObject tiro;
    [SerializeField] private Movimento _Mov;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
             //Cria uma rota��o
            UnityEngine.Quaternion rotacao = new UnityEngine.Quaternion();
            //Define a rota��o em fun��o de graus (�)
            
            rotacao.eulerAngles = new UnityEngine.Vector3(0, 0, 0);

            if(!_Mov.FacingRight()){
                rotacao.eulerAngles = new UnityEngine.Vector3(0, 0, 180);
                Instantiate(tiro, transform.position - transform.right , rotacao);
            }else{
                
                Instantiate(tiro, transform.position + transform.right , rotacao);
            }

           
        }


    }
}
