using UnityEngine;
using UnityEngine.Events;

public class Vida : MonoBehaviour
{
    [SerializeField] private int _maxHp = 100;
    
    
    [SerializeField] private int _Hp;


    
    public int VidaMaxima => _maxHp;

    public UnityEvent<int> curado;
    public UnityEvent<int> atacado;
    public UnityEvent morto;

    public int hp {
        get => _Hp;
        private set
            {
                var tomouDano = value < _Hp;
                _Hp = Mathf.Clamp(value,0,_maxHp);

                if(tomouDano){
                    atacado?.Invoke(_Hp);
                }else{
                    curado?.Invoke(_Hp);
                }

                if(_Hp <= 0){
                    morto?.Invoke();
                }
            }

    }
    

    void Awake()
    {
        _Hp=_maxHp;
    }


    public void Dano(int quantidade) =>_Hp -= quantidade;

    public void Cura(int quantidade) =>_Hp += quantidade;

    public void CuraCompleta() =>_Hp = _maxHp;

    public void IK() =>_Hp = 0;

    public void Ajuste(int quantidade) =>_Hp = quantidade;

    
    
    
}
