using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugadorSC : MonoBehaviour
{
    [Header("Carriles")]
    public Transform[] Carriles;
    [Space(5)]

    [Header("Variables")]
    public bool saltando = false;

    [Header("DEBUGS")]
    public int carrilActual = 1; //Carril centro
    public float velocidadMovimiento = 1.0f;
    public float alturaSalto;
    public Animator animsJugador;

    private void Awake()
    {
        animsJugador = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mover hacia el carril especificado
        Vector3 _pos = Vector3.Lerp(transform.position, Carriles[carrilActual].position, velocidadMovimiento);
        transform.position = _pos;
    }

    //Llamado desde los swipes de LeanTouch
    public void Mover(int _carril)
    {
        
            carrilActual -= _carril;
            carrilActual = Mathf.Clamp(carrilActual, 0, 2);
        
    }

    public void Saltar()
    {
        if (!saltando)
        {
            saltando = true;
            animsJugador.SetTrigger("Saltar");
            Invoke("FinalSalto", 1);
        }
    }

    public void FinalSalto()
    {
        saltando = false;
    }
}
