using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaLancamento : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]private float forca = 30;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){

        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * forca, ForceMode2D.Impulse);

    

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
