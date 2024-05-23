using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{

    //classe vida
    [SerializeField] private Vida _Vida;
    //atributos da barra em si
    [SerializeField] private RectTransform _Barra;
    [SerializeField] RectMask2D _Mascara;
    private float _MaxMascaraDireita;
    private float _InicioMascaraDireita;




    // Start is called before the first frame update
    void Start(){
        //adiciona o padding inicial da barra de vida
        _MaxMascaraDireita = _Barra.rect.width - _Mascara.padding.x - _Mascara.padding.z;
        _InicioMascaraDireita = _Mascara.padding.z;
        
    }

    //atualiza a barra de vida com o novo valor, acrescentando padding para reduzir o tamanho da barra
    public void SetaValor(int Valor){
        var targetWidth = Valor * _MaxMascaraDireita / _Vida._maxHp;
        var novaMascara = _MaxMascaraDireita + _InicioMascaraDireita - targetWidth;
        var padding = _Mascara.padding;
        padding.z = novaMascara * 4;
        _Mascara.padding = padding;

    }

    void Update(){
        
    }
}
