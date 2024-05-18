using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{

    [SerializeField] private Vida _Vida;
    [SerializeField] private RectTransform _Barra;
    [SerializeField] RectMask2D _Mascara;


    private float _MaxMascaraDireita;
    private float _InicioMascaraDireita;




    // Start is called before the first frame update
    void Start()
    {
        _MaxMascaraDireita = _Barra.rect.width - _Mascara.padding.x - _Mascara.padding.z;
        _InicioMascaraDireita = _Mascara.padding.z;
        
    }

    public void SetaValor(int Valor){
        var targetWidth = Valor * _MaxMascaraDireita / _Vida._maxHp;
        var novaMascara = _MaxMascaraDireita + _InicioMascaraDireita - targetWidth;
        var padding = _Mascara.padding;
        padding.z = novaMascara * 5;
        _Mascara.padding = padding;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
