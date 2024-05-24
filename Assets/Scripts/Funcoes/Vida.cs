using UnityEngine;
using UnityEngine.Events;

public class Vida : MonoBehaviour
{
    //Informações da entidade
    [SerializeField] public int _maxHp = 100;
    [SerializeField] private int _Hp;

    [SerializeField] private int pontos;

    //Bools para triggers
    private bool tomouDano = false;
    private bool curou = false;


    
    public int VidaMaxima => _maxHp;

    //eventos para indentificar status
    public UnityEvent<int> curado;
    public UnityEvent<int> atacado;
    public UnityEvent morto;
    
    
    //atualiza as bools
    public void setTomouDano(bool status){
        tomouDano = status;
    }
    public void setCurou(bool status){
        curou = status;
    }

    public float getVida(){
        return _Hp;
    }

    
    
    void Start(){
        _Hp = _maxHp;
    }


    //funcoes de manipulacao de vida
    public void Dano(int quantidade) =>_Hp -= quantidade;

    public void Cura(int quantidade) =>_Hp += quantidade;

    public void CuraCompleta() =>_Hp = _maxHp;

    public void IK() =>_Hp = 0;

    public void Ajuste(int quantidade) =>_Hp = quantidade;

    public int getPontos(){
        return pontos;
    }

    
    //verifica qual status invocar com base na mudanca da vida
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
