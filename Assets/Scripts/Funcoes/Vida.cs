using UnityEngine;
using UnityEngine.Events;

public class Vida : MonoBehaviour
{
    [SerializeField] public int _maxHp = 100;
    
    
    [SerializeField] private int _Hp;

    private bool tomouDano = false;
    private bool curou = false;


    
    public int VidaMaxima => _maxHp;

    public UnityEvent<int> curado;
    public UnityEvent<int> atacado;
    public UnityEvent morto;
    
    
    public void setTomouDano(bool status){
        tomouDano = status;
    }
    public void setCurou(bool status){
        curou = status;
    }

    
    
    void Awake()
    {
        _Hp = _maxHp;
    }


    public void Dano(int quantidade) =>_Hp -= quantidade;

    public void Cura(int quantidade) =>_Hp += quantidade;

    public void CuraCompleta() =>_Hp = _maxHp;

    public void IK() =>_Hp = 0;

    public void Ajuste(int quantidade) =>_Hp = quantidade;

    
    void Update(){
        if(tomouDano){
            tomouDano = false;
            atacado?.Invoke(_Hp);

        }
        if(curou){
            curou = false;
            curado?.Invoke(_Hp);
        }
        if(_Hp<=0){
            morto?.Invoke();
        }
    }    
}
